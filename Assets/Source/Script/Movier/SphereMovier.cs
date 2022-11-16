using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class SphereMovier : MonoBehaviour
{
    [Inject] private PlayerData _data;
    [Inject] private PlayerInputRoot _inputRoot;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = Mathf.Infinity;
    }

    private void OnEnable()
    {
        _inputRoot.Move += OnMove;
    }

    private void OnDisable()
    {
        _inputRoot.Move -= OnMove;
    }

    private void OnMove(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        Vector3 moveAxis = new Vector3(moveDirection.z, 0 , -moveDirection.x);
        _rigidbody.AddTorque(moveAxis * _data.Speed, ForceMode.VelocityChange);
    }
}
