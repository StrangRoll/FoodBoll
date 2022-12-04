using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class MainMenuPause : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Image _mainMenuImage;
    [SerializeField] private ButtonClickReader _continueButton;

    [Inject] private PauseManager _paseManager;

    private GameObject _mainMenu;

    public event UnityAction GameContinued;

    private void Awake()
    {
        _mainMenu = _mainMenuImage.gameObject;
    }

    private void OnEnable()
    {
        _continueButton.ButtonClicked += OnButtonClicked;
        _paseManager.Register(this);
    }

    private void OnDisable()
    {
        _continueButton.ButtonClicked -= OnButtonClicked;
        _paseManager.UnRegister(this);
    }

    public void OnPause(bool isPause)
    {
        _mainMenu.SetActive(isPause);
    }

    private void OnButtonClicked()
    {
        GameContinued?.Invoke();
    }
}
