using UnityEngine;
using Zenject;

public class CameraMovier : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;

    private Vector3 _deltaPosition;

    private void Awake()
    {
        _deltaPosition = transform.position - _sphere.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _sphere.transform.position + _deltaPosition;
    }
}
