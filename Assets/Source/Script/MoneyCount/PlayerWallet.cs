using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerWallet : MonoBehaviour
{
    [Inject] private MoneyPickuper _pickuper;

    private int _money = 10000;
    private int _reservedMoney = 0;
    private int _oneDollarCount = 1;

    public event UnityAction<int> MoneyCountChanged;

    private void OnEnable()
    {
        _pickuper.MoneyPickedUp += OnMoneyPickedUp;
    }

    private void OnDisable()
    {
        _pickuper.MoneyPickedUp -= OnMoneyPickedUp;
    }

    private void Start()
    {
        MoneyCountChanged?.Invoke(_money);
    }

    public bool IsEnoughMoney(int price)
    {
        if (price <= _money)
        {
            _reservedMoney = price;
            return true;
        }

        return false;
    }

    public void DoPurchase()
    {
        ChangeMoneyCount(-_reservedMoney);
        _reservedMoney = 0;
    }

    private void OnMoneyPickedUp()
    {
        ChangeMoneyCount(_oneDollarCount);
    }

    private void ChangeMoneyCount(int deltaMoney)
    {
        _money += deltaMoney;

        if (_money < 0)
            Debug.LogError("Money count less then zero");

        MoneyCountChanged?.Invoke(_money);
    }
}
