using UnityEngine;
using Zenject;

public class RectTransformByButtonActivator : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _button;
    [SerializeField] private RectTransform _transform;
    [SerializeField] private bool _isButtonActivate;

    [Inject] private PauseManager _pauseManager;

    private UnityEngine.GameObject _transformObject;

    private void Awake()
    {
        _transformObject = _transform.gameObject;
    }

    private void OnEnable()
    {
        _button.ButtonClicked += ButtonClicked;
    }

    private void OnDisable()
    {
        _button.ButtonClicked -= ButtonClicked;
    }

    private void ButtonClicked()
    {
        if (_pauseManager.IsPaused)
            return;

        _transformObject.SetActive(_isButtonActivate);
    }
}
