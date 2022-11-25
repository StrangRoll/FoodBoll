using TMPro;
using UnityEngine;
using Zenject;

public class MoneyRewardView : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _buttonClickReader;
    [SerializeField] private TMP_Text _moneyTextField;
    [SerializeField] private RewardParent _parent;

    [Inject] private VideoAdd _videoAdd;


    private void OnEnable()
    {
        _videoAdd.VideoAddShowed += OnVideoAdShowed;
        _buttonClickReader.ButtonClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _videoAdd.VideoAddShowed -= OnVideoAdShowed;
        _buttonClickReader.ButtonClicked -= OnButtonClicked;
    }

    private void OnVideoAdShowed(int money)
    {
        _parent.gameObject.SetActive(true);
        _moneyTextField.text = $"+ {money} $";
    }

    private void OnButtonClicked()
    {
        _parent.gameObject.SetActive(false);
    }
}
