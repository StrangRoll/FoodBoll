using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SaverPlayerData : MonoBehaviour
{
    [Inject] private PlayerData _sizeButton;
    [Inject] private SpeedUpgradeButton _speedButton;
    [Inject] private CapacityUpgradeButton _capacityButton;
    [Inject] private PlayerWallet _wallet;
    [Inject] private Autorization _autorization;


    private Dictionary<string, int> _playerData = new Dictionary<string, int>();
    private Coroutine _moneyCoroutine;
    private WaitForSeconds _waitFewSecond = new WaitForSeconds(1);

    private void Awake()
    {
        _playerData.Add(PlayerDataKey.LevelNomber, 1);
        _playerData.Add(PlayerDataKey.SpeedButton, 1);
        _playerData.Add(PlayerDataKey.SizeButton, 1);
        _playerData.Add(PlayerDataKey.CapacityButton, 1);
        _playerData.Add(PlayerDataKey.Money, 0);
    }

    private void OnEnable()
    {
        _speedButton.SpeedIncreased += OnSpeedIncreased;
        _sizeButton.SizeIncreased += OnSizeIncreased;
        _capacityButton.CapacityIncreased += OnCapacityIncreased;
        _wallet.MoneyCountChanged += OnMoneyCountChanged;
    }

    private void OnDisable()
    {
        _speedButton.SpeedIncreased -= OnSpeedIncreased;
        _sizeButton.SizeIncreased -= OnSizeIncreased;
        _capacityButton.CapacityIncreased -= OnCapacityIncreased;
        _wallet.MoneyCountChanged -= OnMoneyCountChanged;
    }

    private void OnLevelChanged(int levelNomber, int nextLevelNomber)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        NewRecord(levelNomber);
#endif
        _playerData[PlayerDataKey.LevelNomber] = levelNomber;
        SaveData();
    }

    private void NewRecord(int levelNomber)
    {
        if (_autorization.IsAutorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderBoardName.World, (result) =>
        {
            if (result == null)
            {
                Agava.YandexGames.Leaderboard.SetScore(LeaderBoardName.World, levelNomber);
            }
            else if (result.score < levelNomber)
            {
                Agava.YandexGames.Leaderboard.SetScore(LeaderBoardName.World, levelNomber);
            }
        });
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

    private void OnMoneyCountChanged(int money)
    {
        _playerData[PlayerDataKey.Money] = money;

        if (_moneyCoroutine != null)
            StopCoroutine(_moneyCoroutine);

        _moneyCoroutine = StartCoroutine(MoneyWaiting());
    }

    private IEnumerator MoneyWaiting()
    {
        yield return _waitFewSecond;
        SaveData();
        _moneyCoroutine = null;
    }

    private void SaveData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (_autorization.IsAutorized == false)
            return;

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
#endif
    }
}
