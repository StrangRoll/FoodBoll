using UnityEngine;
using UnityEngine.UI;

public class WayFinderActivator : MonoBehaviour
{
    [SerializeField] private RawImage _wayImage;
    [SerializeField] private WayFinderUpdator _updator;
    [SerializeField] private WayFinderAnimation _animation;

    public void Activate()
    {
        _wayImage.enabled = true;
        _updator.enabled = true;
        _animation.enabled = true;
    }

    public void Deactivate()
    {
        _wayImage.enabled = false;
        _updator.enabled = false;
        _animation.enabled = false;
    }
}
