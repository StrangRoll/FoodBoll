using TMPro;
using UnityEngine;
using Zenject;

public class MoneyRewardView : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _videoShowedButton;
    [SerializeField] private ButtonClickReader _offerShowButton;
    [SerializeField] private TMP_Text _moneyCountTextField;
    [SerializeField] private TMP_Text _moneyAddedTextField;
    [SerializeField] private RewardParent _parent;

    [Inject] private VideoAdd _videoAdd;
    [Inject] private PauseManager _pauseManager;

    private string _firstPart = "FirstVideoOfferPhrase";
    private string _secondPart = "SecondVideoOfferPhrase";

    private void OnEnable()
    {
        _videoAdd.VideoAddShowed += OnVideoAdShowed;
        _videoShowedButton.ButtonClicked += OnVideoShowedButtonClicked;
        _offerShowButton.ButtonClicked += OnOfferShowButtonClicked;
    }

    private void OnDisable()
    {
        _videoAdd.VideoAddShowed -= OnVideoAdShowed;
        _videoShowedButton.ButtonClicked -= OnVideoShowedButtonClicked;
        _offerShowButton.ButtonClicked -= OnOfferShowButtonClicked;
    }

    private void OnVideoAdShowed(int money)
    {
        _parent.gameObject.SetActive(true);
        _moneyAddedTextField.text = $"+ {money} $";
    }

    private void OnVideoShowedButtonClicked()
    {
        if (_pauseManager.IsPaused)
            return;
            
        _parent.gameObject.SetActive(false);
    }

    private void OnOfferShowButtonClicked()
    {
        if (_pauseManager.IsPaused)
            return;

        var text = Lean.Localization.LeanLocalization.GetTranslationText(_firstPart);
        text += " ";
        text += _videoAdd.AddedMoney.ToString();
        text += Lean.Localization.LeanLocalization.GetTranslationText(_secondPart);
        _moneyCountTextField.text = text;
    }
}
