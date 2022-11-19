using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WayFinderActivator : MonoBehaviour
{
    [SerializeField] private RawImage _wayImage;
    [SerializeField] private WayFinderUpdator _updator;
    [SerializeField] private WayFinderAnimation _animation;

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
        _wayImage.enabled = true;
        _updator.enabled = true;
        _animation.enabled = true;
    }

    private void OnPlayerNotFullMore()
    {
        _wayImage.enabled = false;
        _updator.enabled = false;
        _animation.enabled = false;
    }
}
