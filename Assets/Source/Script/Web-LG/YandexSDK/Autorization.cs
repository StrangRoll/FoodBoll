using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Autorization : MonoBehaviour
{
    public event UnityAction AutorizationChecked;

    public bool IsAutorized { get; private set; } = false;
    public string PlayerName { get; private set; }

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        StartCoroutine(CheckAutorization());
#endif
    }

    public void Autorizate()
    {
        PlayerAccount.Authorize();
        PlayerAccount.RequestPersonalProfileDataPermission();
    }

    private void GetPlayerInfo()
    {
        PlayerAccount.GetProfileData((result) =>
        {
            string name = result.publicName;
            if (string.IsNullOrEmpty(name))
                name = $"Player{Random.Range(100000, 999999)}";

            PlayerName = name;
        });
    }

    private IEnumerator CheckAutorization()
    {
        yield return YandexGamesSdk.Initialize();

        if (PlayerAccount.HasPersonalProfileDataPermission)
        {
            IsAutorized = true;
            GetPlayerInfo();
        }

        AutorizationChecked?.Invoke();
    }
}
