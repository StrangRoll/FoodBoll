using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AuthorizationCanvasActivator : MonoBehaviour
{
    [SerializeField] private Image _authorizationImage;
    [SerializeField] private ButtonClickReader _closeButton;

    [Inject] private Autorization _autorizationScript;

    private GameObject _authorization;

    private void Awake()
    {
        _authorization = _authorizationImage.gameObject;
    }

    private void OnEnable()
    {
        _closeButton.ButtonClicked += OnCloseButtonClicked;
        _autorizationScript.AutorizationChecked += OnAutorizationChecked;
    }

    private void OnDisable()
    {
        _closeButton.ButtonClicked -= OnCloseButtonClicked;
        _autorizationScript.AutorizationChecked -= OnAutorizationChecked;
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
