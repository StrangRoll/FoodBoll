using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerDataLoader : MonoBehaviour
{
    public event UnityAction<int> LevelNomberLoaded;
    public event UnityAction<int> SpeedButtonLevelLoaded;
    public event UnityAction<int> SizeButtonLevelLoaded;
    public event UnityAction<int> CapacityButtonLevelLoaded;
    public event UnityAction<int> MoneyCountLoaded;

    private Dictionary<string, int> _playerData = new Dictionary<string, int>();

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        StartCoroutine(LoadProgress());
#endif
    }

    private IEnumerator LoadProgress()
    {
        yield return YandexGamesSdk.Initialize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.GetPlayerData((data) => PlayerDataHandler(data));
        }
        else
        {
            StandartStart();
        }
    }

    private void PlayerDataHandler(string playerData)
    {
        if (string.IsNullOrEmpty(playerData))
        {
            StandartStart();
            return;
        }

        string dataString = new string(playerData.Where(symbol => CheckSymbol(symbol)).ToArray());
        string[] dataPairs = dataString.Split(",");

        foreach (var pair in dataPairs)
        {
            var data = pair.Split(":");

            if (int.TryParse(data[1], out int valume) == false)
            {
                valume = 1;
            }

            _playerData.Add(data[0], valume);
        }

        SendAllEvents();
    }

    private void StandartStart()
    {
        _playerData.Add(PlayerDataKey.LevelNomber, 1);
        _playerData.Add(PlayerDataKey.SpeedButton, 1);
        _playerData.Add(PlayerDataKey.SizeButton, 1);
        _playerData.Add(PlayerDataKey.CapacityButton, 1);
        _playerData.Add(PlayerDataKey.Money, 122);

        SendAllEvents();
    }

    private void SendAllEvents()
    {
        SpeedButtonLevelLoaded?.Invoke(_playerData[PlayerDataKey.SpeedButton]);
        SizeButtonLevelLoaded?.Invoke(_playerData[PlayerDataKey.SizeButton]);
        CapacityButtonLevelLoaded?.Invoke(_playerData[PlayerDataKey.CapacityButton]);
        MoneyCountLoaded?.Invoke(_playerData[PlayerDataKey.Money]);
        LevelNomberLoaded?.Invoke(_playerData[PlayerDataKey.LevelNomber]);
    }

    private bool CheckSymbol(char symbol)
    {
        return (symbol != '"' && symbol != '{' && symbol != '}' && symbol != ' ');
    }
}