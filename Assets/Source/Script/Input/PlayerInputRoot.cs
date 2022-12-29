using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputRoot : MonoBehaviour
{
    [Inject] private StartAnimationHandler _startAnimation;
    [Inject] private ExitAnimationHandler _exitAnimation;

    private PlayerInput _playerInput;
    private bool _isTouching = false;
    private Vector2 _moveDirection;
    private bool _isMoving = false;

    public event UnityAction<Vector2> Move;
    public event UnityAction<bool, Vector2> Touch;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Sphere.Move.performed += ctx => OnMove();
        _playerInput.Sphere.Move.started += ctx => ChangeMovingState(true);
        _playerInput.Sphere.Move.canceled += ctx => ChangeMovingState(false);
        _playerInput.World.Press.performed += ctx => OnPress();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void FixedUpdate()
    {
        if (_startAnimation.IsGoing)
        {
            Move?.Invoke(Vector3.right);
            return;
        }

        if (_exitAnimation.IsGoing)
        {
            Move?.Invoke(Vector3.left);
            return;
        }

        if (_isMoving)
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
        var touchPosition = Pointer.current.position.ReadValue();
        Touch?.Invoke(_isTouching, touchPosition);
    }

    private void ChangeMovingState(bool newState)
    {
        _isMoving = newState;

        if (_isMoving == false)
            _moveDirection = Vector2.zero;
    }

}
