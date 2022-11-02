using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StickViewer : MonoBehaviour
{
    [SerializeField] private Image _circleImager;
    [SerializeField] private Image _borderImager;

    [Inject] private PlayerInputRoot _inputRoot;

    private void OnEnable()
    {
        _inputRoot.Touch += OnTouch;
    }

    private void OnDisable()
    {
        _inputRoot.Touch -= OnTouch;
    }

    private void OnTouch(bool isTouching, Vector2 touchPosition)
    {
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
