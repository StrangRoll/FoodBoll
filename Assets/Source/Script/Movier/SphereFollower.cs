using UnityEngine;
using Zenject;

public class SphereFollower : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;

    private Vector3 _deltaPosition;

    private void Awake()
    {
        _deltaPosition = transform.position - _sphere.transform.position;
        _deltaPosition.y = 0;
    }

    private void LateUpdate()
    {
        var newPosition = new Vector3(_sphere.transform.position.x, transform.position.y, _sphere.transform.position.z);
        transform.position = newPosition + _deltaPosition;
    }
}
