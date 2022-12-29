using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AuthorizationCanvasActivator : MonoBehaviour
{
    [SerializeField] private Image _authorizationImage;
    [SerializeField] private ButtonClickReader _closeButton;
    [SerializeField] private ButtonClickReader _authorizationButton;

    [Inject] private Autorization _autorizationScript;

    private UnityEngine.GameObject _authorization;

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

    private void OnAuthorizationButtonClicked()
    {
        _autorizationScript.Autorizate();
        OnCloseButtonClicked();
    }

    private void OnCloseButtonClicked()
    {
        _authorization.SetActive(false);
    }

    private void OnAutorizationChecked()
    {
        if (_autorizationScript.IsAutorized == false)
            _authorization.SetActive(true);
    }
}
