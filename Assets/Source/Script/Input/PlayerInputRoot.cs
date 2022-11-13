using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputRoot : MonoBehaviour
{
    private PlayerInput _playerInput;
    private bool _isTouching = false;
    private Vector2 _moveDirection;

    public event UnityAction<Vector2> Move;
    public event UnityAction<bool, Vector2> Touch;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Sphere.Move.performed += ctx => OnMove();
        _playerInput.Touch.Press.performed += ctx => OnPress();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void FixedUpdate()
    {
        if (_isTouching)
            Move?.Invoke(_moveDirection);
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnMove()
    {
        _moveDirection = _playerInput.Sphere.Move.ReadValue<Vector2>();
    }

    private void OnPress()
    {
        _isTouching = !_isTouching;

        if (_isTouching)
            _moveDirection = Vector2.zero;

        var touchPosition = Pointer.current.position.ReadValue();
        Touch?.Invoke(_isTouching, touchPosition);
    }

}
