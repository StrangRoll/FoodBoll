using UnityEngine;
using Zenject;

public class WayToSeller : MonoBehaviour
{
    [SerializeField] private WayFinderActivator _activator;

    [Inject] private Player _player;

    private void Awake()
    {
        OnPlayerNotFullMore();
    }

    private void OnEnable()
    {
        _player.PlayerFull += OnPlayerFull;
        _player.PlayerNotFullMore += OnPlayerNotFullMore;
    }

    private void OnDisable()
    {
        _player.PlayerFull -= OnPlayerFull;
        _player.PlayerNotFullMore -= OnPlayerNotFullMore;
    }

    private void OnPlayerFull()
    {
        _activator.Activate();
    }

    private void OnPlayerNotFullMore()
    {
        _activator.Deactivate();
    }
}
