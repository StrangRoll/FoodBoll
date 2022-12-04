using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour, IPauseHandler
{
    [SerializeField] private ButtonClickReader _pauseButton;

    private List<IPauseHandler> _pauseHandlers = new List<IPauseHandler>();

    public bool IsPaused { get; private set; }

    private void OnEnable()
    {
        _pauseButton.ButtonClicked += OnButtonClicked; 
    }

    private void OnDisable()
    {
        _pauseButton.ButtonClicked -= OnButtonClicked;
    }

    public void Register(IPauseHandler pauseHandler)
    {
        _pauseHandlers.Add(pauseHandler);
    }

    public void UnRegister(IPauseHandler pauseHandler)
    {
        if (_pauseHandlers.Contains(pauseHandler))
        {
            _pauseHandlers.Remove(pauseHandler);
        }
        else
        {
            Debug.LogError("Trying to remove IPauseHandler that does not contain");
        }
    }

    public void OnPause(bool isPause)
    {
        if (isPause == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        IsPaused = isPause;

        foreach (var pauseHandler in _pauseHandlers)
        {
            pauseHandler.OnPause(isPause);
        }
    }

    private void OnButtonClicked()
    {
        IsPaused = !IsPaused;
        OnPause(IsPaused);
    }
}
