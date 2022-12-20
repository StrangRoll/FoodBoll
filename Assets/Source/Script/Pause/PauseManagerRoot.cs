using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PauseManagerRoot : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _pauseButton;

    [Inject] private PauseManager _pauseManager;

    private PlayerInput _playerInput;

    public event UnityAction<bool> Pause;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.World.Pause.performed += ctx => OnPause();
    }

    private void OnEnable()
    {
        _pauseButton.ButtonClicked += OnPauseButtonClicked;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _pauseButton.ButtonClicked += OnPauseButtonClicked;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        _playerInput.Disable();
    }

    private void OnPauseButtonClicked()
    {
        Pause?.Invoke(true);
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if (inBackground)
            Pause?.Invoke(true);
    }

    private void OnPause()
    {
        Pause?.Invoke
            (!_pauseManager.IsPaused);
    }
}
