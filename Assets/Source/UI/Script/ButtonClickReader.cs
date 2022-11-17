using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonClickReader : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event UnityAction ButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        ButtonClicked?.Invoke();
    }
}
