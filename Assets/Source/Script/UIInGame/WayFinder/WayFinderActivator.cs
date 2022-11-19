using UnityEngine;
using UnityEngine.UI;

public class WayFinderActivator : MonoBehaviour
{
    [SerializeField] private RawImage _wayImage;
    [SerializeField] private WayFinderUpdater _updater;
    [SerializeField] private WayFinderAnimation _animation;

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
}
