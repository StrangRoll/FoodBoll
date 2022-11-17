using UnityEngine;

public class ButtonsActivator : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buttonGroup;
    [SerializeField] private MonoBehaviour _platformContainer;

    private IPlatform _platform => (IPlatform)_platformContainer;

    private void OnValidate()
    {
        if (_platformContainer is IPlatform)
            return;

        Debug.LogError($"{_platformContainer.name} need to implement {nameof(IPlatform)}.");
        _platformContainer = null;
    }

    private void OnEnable()
    {
        _platform.PlayerEntered += OnPlayerEntered;
        _platform.PlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        _platform.PlayerEntered -= OnPlayerEntered;
        _platform.PlayerLeft -= OnPlayerLeft;
    }

    private void OnPlayerEntered()
    {
        _buttonGroup.alpha = 1;
        _buttonGroup.blocksRaycasts = true;
        _buttonGroup.interactable = true;
    }

    private void OnPlayerLeft()
    {
        _buttonGroup.alpha = 0;
        _buttonGroup.blocksRaycasts = false;
        _buttonGroup.interactable = false;
    }
}
