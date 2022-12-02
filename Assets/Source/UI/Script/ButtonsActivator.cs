using UnityEngine;
using Zenject;

public class ButtonsActivator : MonoBehaviour
{
    [Inject] private Player _player;

    [SerializeField] private CanvasGroup _buttonGroup;
    [SerializeField] private Warning _warning;
    [SerializeField] private MonoBehaviour _platformContainer;

    private GameObject _foodWarning;

    private IPlatform _platform => (IPlatform)_platformContainer;

    private void OnValidate()
    {
        if (_platformContainer is IPlatform)
            return;

        Debug.LogError($"{_platformContainer.name} need to implement {nameof(IPlatform)}.");
        _platformContainer = null;
    }

    private void Awake()
    {
        _foodWarning = _warning.gameObject;
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
        if (_player.IsEmpy)
        {
            _buttonGroup.alpha = 1;
            _buttonGroup.blocksRaycasts = true;
            _buttonGroup.interactable = true;
        }
        else
        {
            _foodWarning.SetActive(true);
        }
    }

    private void OnPlayerLeft()
    {
        _buttonGroup.alpha = 0;
        _buttonGroup.blocksRaycasts = false;
        _buttonGroup.interactable = false;
        _foodWarning.SetActive(false);
    }
}
