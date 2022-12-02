using TMPro;
using UnityEngine;

public class UpgradeButtonPriceChanger : MonoBehaviour
{
    [SerializeField] private UpgradeButton _upgradeButton;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _levelText;

    private string _levelEnWord = "Level";

    private void OnEnable()
    {
        _upgradeButton.ButtonInfoChanged += OnPriceChanged;
    }

    private void Start()
    {
        SetFirstLevel();
    }

    private void OnDisable()
    {
        _upgradeButton.ButtonInfoChanged -= OnPriceChanged;
    }

    private void OnPriceChanged(int price, int level)
    {
        _priceText.text = $"${price},00";
        var levelWord = Lean.Localization.LeanLocalization.GetTranslationText(_levelEnWord);
        _levelText.text = $"{levelWord} {level}";
    }

    private void SetFirstLevel()
    {
        var levelWord = Lean.Localization.LeanLocalization.GetTranslationText(_levelEnWord);
        var level = 1;
        _levelText.text = $"{levelWord} {level}";
    }
}
