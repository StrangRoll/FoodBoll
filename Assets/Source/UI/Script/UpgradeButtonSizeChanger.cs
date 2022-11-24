using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonSizeChanger : MonoBehaviour
{
    [SerializeField] private RectTransform _buttonRect;
    [SerializeField] private float _pcWidth;
    [SerializeField] private float _pcHeight;
    [SerializeField] private float _phoneWidth;
    [SerializeField] private float _phoneHeight;

    private const string _desctop = "Desktop";
    private const string _phone = "Mobile";

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
StartCoroutine(ChangeButtonSize());
#endif
    }

    private IEnumerator ChangeButtonSize()
    {
        yield return YandexGamesSdk.Initialize();
        Vector2 buttonSize;

        switch (Device.Type.ToString())
        {
            case _phone:
                buttonSize = new Vector2(_phoneWidth, _phoneHeight);
                _buttonRect.sizeDelta = buttonSize;
                break;
            case _desctop:
                buttonSize = new Vector2(_pcWidth, _pcHeight);
                _buttonRect.sizeDelta = buttonSize;
                break;
            default:
                buttonSize = new Vector2(_phoneWidth, _phoneHeight);
                _buttonRect.sizeDelta = buttonSize;
                break;
        }
    }
}
