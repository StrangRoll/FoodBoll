using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class SphereMovier : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [Inject] private PlayerInputRoot _inputRoot;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
        _rigidbody.velocity = moveDirection * _moveSpeed;
    }
}
