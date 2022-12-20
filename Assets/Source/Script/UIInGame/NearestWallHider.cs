using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NearestWallHider : MonoBehaviour
{
    [SerializeField] private Image _wallImage;
    [SerializeField] private Color _insideColor;
    [SerializeField] private Color _outsideColor;

    private float _animationDuration = 1;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier sphereMovier))
            _wallImage.DOColor(_insideColor, _animationDuration);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier sphereMovier))
            _wallImage.DOColor(_outsideColor, _animationDuration);  
    }
}
