using Agava.YandexGames;
using UnityEngine;

public class YandexSDKinitializer : MonoBehaviour
{
    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        YandexGamesSdk.Initialize();
#endif
    }
}
