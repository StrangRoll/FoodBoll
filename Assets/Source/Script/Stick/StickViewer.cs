using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StickViewer : MonoBehaviour, IPauseHandler, IExitAnimationWaiter
{
    [SerializeField] private Image _circleImager;
    [SerializeField] private Image _borderImager;

    [Inject] private PlayerInputRoot _inputRoot;
    [Inject] private PauseManager _pauseManager;
    [Inject] private StartAnimationHandler _startAnimation;
    [Inject] private ExitAnimationHandler _exitAnimation;

    private void OnEnable()
    {
        _inputRoot.Touch += OnTouch;
        _pauseManager.Register(this);
        _exitAnimation.Register(this);
    }

    private void OnDisable()
    {
        _inputRoot.Touch -= OnTouch;
        _pauseManager.UnRegister(this);
        _exitAnimation.UnRegister(this);
    }

    public void OnPause(bool isPause)
    {
        if (isPause == false)
            ChangeVisible(false);
    }

    public void OnExitAnimation(bool _isGoing)
    {
        if (_isGoing)
            ChangeVisible(false);
    }

    private void OnTouch(bool isTouching, Vector2 touchPosition)
    {
        if (_startAnimation.IsGoing || _exitAnimation.IsGoing)
            return;

        if (_pauseManager.IsPaused)
            return;

        if (isTouching)
            ChangePosition(touchPosition);

        ChangeVisible(isTouching);
    }

    private void ChangeVisible(bool isVisible)
    {
        _circleImager.enabled = isVisible;
        _borderImager.enabled = isVisible;
    }

    private void ChangePosition(Vector2 position)
    {
        transform.position = position;
    }
}
