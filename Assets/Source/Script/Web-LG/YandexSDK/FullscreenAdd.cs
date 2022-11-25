using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using Zenject;

public class FullscreenAdd : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _nextLevelButton;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        StartCoroutine(ShowStartAdd());
#endif
    }

    private void OnEnable()
    {
        _nextLevelButton.ButtonClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _nextLevelButton.ButtonClicked += OnButtonClicked;

    }

    private IEnumerator ShowStartAdd()
    {
        yield return YandexGamesSdk.Initialize();

        InterstitialAd.Show();
    }

    private void OnButtonClicked()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        InterstitialAd.Show();
#endif
    }
}
