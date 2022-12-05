using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AuthorizationCanvasActivator : MonoBehaviour
{
    [SerializeField] private Image _authorizationImage;
    [SerializeField] private ButtonClickReader _closeButton;
    [SerializeField] private ButtonClickReader _authorizationButton;

    [Inject] private Autorization _autorizationScript;

    private GameObject _authorization;

    private void Awake()
    {
        _authorization = _authorizationImage.gameObject;
    }

    private void OnEnable()
    {
        _closeButton.ButtonClicked += OnCloseButtonClicked;
        _authorizationButton.ButtonClicked += OnAuthorizationButtonClicked;
        _autorizationScript.AutorizationChecked += OnAutorizationChecked;
    }

    private void OnDisable()
    {
        _closeButton.ButtonClicked -= OnCloseButtonClicked;
        _authorizationButton.ButtonClicked -= OnAuthorizationButtonClicked;
        _autorizationScript.AutorizationChecked -= OnAutorizationChecked;
    }

    private void OnCloseButtonClicked()
    {
        _authorization.SetActive(false);
    }

    private void OnAuthorizationButtonClicked()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (_autorizationScript.TryAutorize())
            OnCloseButtonClicked();
#endif
    }

    private void OnAutorizationChecked()
    {
        if (_autorizationScript.IsAutorized == false)
            _authorization.SetActive(true);
    }
}
