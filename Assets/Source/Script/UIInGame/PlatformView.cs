using UnityEngine;
using UnityEngine.UI;

public class PlatformView : MonoBehaviour
{
    [SerializeField] private Image _frontImage;
    [SerializeField] private Color _activateColor;
    [SerializeField] private MonoBehaviour _platformContainer = null;

    private IPlatform _platform => (IPlatform)_platformContainer;

    private Color _deactivateColor;

    private void OnValidate()
    {
        if (_platformContainer is IPlatform)
            return;

        if (_platformContainer == null)
            return;

        Debug.LogError($"{_platformContainer.name} need to implement {nameof(IPlatform)}.");
        _platformContainer = null;
    }

    private void Awake()
    {
        _deactivateColor = _frontImage.color;
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
        _frontImage.color = _activateColor;
    }

    private void OnPlayerLeft()
    {
        _frontImage.color = _deactivateColor;
    }
}
