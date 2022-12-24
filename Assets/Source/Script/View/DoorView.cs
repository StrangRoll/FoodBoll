using DG.Tweening;
using UnityEngine;

public class DoorView : MonoBehaviour
{
    [SerializeField] private Transform _parentAnimationTransform;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _rotationAngle;

    private Tween _animation;
    private Vector3 _startRotation;
    private Vector3 _endRotation;

    private void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        _endRotation = _startRotation + Vector3.back * _rotationAngle;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier movier))
            _animation = _parentAnimationTransform.DORotate(_endRotation, _animationDuration);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier movier))
            _animation = _parentAnimationTransform.DORotate(_startRotation, _animationDuration);
    }
}
