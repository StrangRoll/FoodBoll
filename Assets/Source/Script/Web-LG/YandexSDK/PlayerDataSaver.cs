using Agava.YandexGames;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerDataSaver : MonoBehaviour
{
    [Inject] private LevelProgress _levelProgress;
    [Inject] private SizeUpgradeButton _sizeButton;
    [Inject] private SpeedUpgradeButton _speedButton;
    [Inject] private CapacityUpgradeButton _capacityButton;
    [Inject] private PlayerDataLoader _loader;

    private Dictionary<string, int> _playerData = new Dictionary<string, int>();
    private bool _allDataSent = false;

    private void Awake()
    {
        _playerData.Add(PlayerDataKey.LevelNomber, 1);
        _playerData.Add(PlayerDataKey.SpeedButton, 1);
        _playerData.Add(PlayerDataKey.SizeButton, 1);
        _playerData.Add(PlayerDataKey.CapacityButton, 1);
    }

    private void OnEnable()
    {
        _levelProgress.LevelChanged += OnLevelChanged;
        _speedButton.SpeedIncreased += OnSpeedIncreased;
        _sizeButton.SizeIncreased += OnSizeIncreased;
        _capacityButton.CapacityIncreased += OnCapacityIncreased;
        _loader.AllDataSent += OnAllDataSent;
    }

    private void OnDisable()
    {
        _levelProgress.LevelChanged += OnLevelChanged;
        _speedButton.SpeedIncreased -= OnSpeedIncreased;
        _sizeButton.SizeIncreased -= OnSizeIncreased;
        _capacityButton.CapacityIncreased -= OnCapacityIncreased;
        _loader.AllDataSent -= OnAllDataSent;
    }

    private void OnLevelChanged(int levelNomber, int nextLevelNomber)
    {
        _playerData[PlayerDataKey.LevelNomber] = levelNomber;
        SaveData();
    }

    private void OnSpeedIncreased(float deltaSpeed)
    {
        _playerData[PlayerDataKey.SpeedButton]++;
        SaveData();
    }

    private void OnSizeIncreased(float deltaSize)
    {
        _playerData[PlayerDataKey.SizeButton]++;
        SaveData();
    }

    private void OnCapacityIncreased(int deltaCapacity)
    {
        _playerData[PlayerDataKey.CapacityButton]++;
        SaveData();
    }

    private void OnAllDataSent()
    {
        _allDataSent = true;
    }

    private void SaveData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (_allDataSent)
        {
            var savedData = "{";
            var end = "";

            foreach (var pair in _playerData)
            {
                savedData += end;
                savedData += "\"" + pair.Key + "\"" + ":" + pair.Value.ToString();
                end = ", ";
            }

            savedData += "}";
            PlayerAccount.SetPlayerData(savedData);
        }
#endif
    }
}
