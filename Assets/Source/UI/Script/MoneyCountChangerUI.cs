using TMPro;
using UnityEngine;
using Zenject;

public class MoneyCountChangerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    [Inject] private PlayerWallet _wallet;

    private void OnEnable()
    {
        _wallet.MoneyCountChanged += OnMoneyCountChanged;
    }

    private void OnDisable()
    {
        _wallet.MoneyCountChanged -= OnMoneyCountChanged;
    }

    private void OnMoneyCountChanged(int money)
    {
        _moneyText.text = $"$ {money},00";
    }
}
