using UnityEngine;
using UnityEngine.UI;

public class WayFinderActivator : MonoBehaviour
{
    [SerializeField] private FoodInfoRecipient _foodInfoRecipient;
    [SerializeField] private RawImage _wayImage;
    [SerializeField] private WayFinderUpdater _updater;
    [SerializeField] private WayFinderAnimation _animation;
    [SerializeField] private bool _isActivateOnStart;

    private void OnEnable()
    {
        _foodInfoRecipient.PlayerNotEmpty += OnPlayerNotEmpty;
    }

    private void OnDisable()
    {
        _foodInfoRecipient.PlayerNotEmpty -= OnPlayerNotEmpty;
    }

    public void Activate()
    {
        _wayImage.enabled = true;
        _updater.enabled = true;
        _animation.enabled = true;
    }

    public void Deactivate()
    {
        _wayImage.enabled = false;
        _updater.enabled = false;
        _animation.enabled = false;
    }

    private void OnPlayerNotEmpty()
    {
        if (_isActivateOnStart)
            Activate();
    }
}
