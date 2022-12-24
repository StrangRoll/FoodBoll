using UnityEngine;
using Zenject;

public class SphereFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _deltaVector;

    [Inject] private SphereMovier _sphere;
    [Inject] private StartAnimationHandler _startAnimationHandler;

    private Vector3 _deltaPosition;

    private void Awake()
    {
        if (_deltaVector != Vector3.zero)
        {
            _deltaPosition = _deltaVector;
        }
        else
        {
            _deltaPosition = transform.position - _sphere.transform.position;
        }

        _deltaPosition.y = 0;
    }

    private void LateUpdate()
    {
        if (_startAnimationHandler.IsGoing)
            return;

        var newSpherePosition = new Vector3(_sphere.transform.position.x, transform.position.y, _sphere.transform.position.z);
        transform.position = newSpherePosition + _deltaPosition;
    }
}
