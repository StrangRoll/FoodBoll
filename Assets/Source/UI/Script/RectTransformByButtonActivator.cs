using UnityEngine;

public class RectTransformByButtonActivator : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _button;
    [SerializeField] private RectTransform _transform;
    [SerializeField] private bool _isButtonActivate;

    private GameObject _transformObject;

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
        _transformObject.SetActive(_isButtonActivate);
    }
}
