using TMPro;
using UnityEngine;

public class UpgradeButtonPriceChanger : MonoBehaviour
{
    [SerializeField] private UpgradeButton _upgradeButton;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _levelText;

    private void OnEnable()
    {
        _upgradeButton.ButtinInfoChanged += OnPriceChanged;
    }

    private void OnDisable()
    {
        _upgradeButton.ButtinInfoChanged -= OnPriceChanged;
    }

    private void OnPriceChanged(int price, int level)
    {
        _priceText.text = $"${price},00";
        _levelText.text = $"Level {level}";
    }
}
