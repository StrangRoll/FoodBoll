using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDataLoader : MonoBehaviour
{
    public event UnityAction<int> LevelNomberLoaded;
    public event UnityAction<int> SpeedButtonLevelLoaded;
    public event UnityAction<int> SizeButtonLevelLoaded;
    public event UnityAction<int> CapacityButtonLevelLoaded;
    public event UnityAction AllDataSent;

    private void Awake()
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
            string playerDataString = null;
            PlayerAccount.GetPlayerData((data) => playerDataString = data);

            Dictionary<string, int> playerData;

            if (playerDataString == null)
            {
                playerData = new Dictionary<string, int>();
                playerData.Add(PlayerDataKey.LevelNomber, 1);
                playerData.Add(PlayerDataKey.SpeedButton, 1);
                playerData.Add(PlayerDataKey.SizeButton, 1);
                playerData.Add(PlayerDataKey.CapacityButton, 1);
            }
            else
            {
                playerData = new Dictionary<string, int>();
                string dataString = new string(playerDataString.Where(symbol => CheckSymbol(symbol)).ToArray());
                string[] dataPairs = dataString.Split(",");

                foreach (var pair in dataPairs)
                {
                    var data = pair.Split(":");

                    if (int.TryParse(data[1], out int valume) == false)
                    {
                        valume = 1;
                    }

                    playerData.Add(data[0], valume);
                }
            }

            LevelNomberLoaded?.Invoke(playerData[PlayerDataKey.LevelNomber]);
            SpeedButtonLevelLoaded?.Invoke(playerData[PlayerDataKey.SpeedButton]);
            SizeButtonLevelLoaded?.Invoke(playerData[PlayerDataKey.SizeButton]);
            CapacityButtonLevelLoaded?.Invoke(playerData[PlayerDataKey.CapacityButton]);

            AllDataSent?.Invoke();
        }
    }

    private bool CheckSymbol(char symbol)
    {
        return (symbol != '"' && symbol != '{' && symbol != '}' && symbol != ' ');
    }
}