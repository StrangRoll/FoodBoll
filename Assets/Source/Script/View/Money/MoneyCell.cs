using UnityEngine;

public class MoneyCell
{
    public bool IsEmpty { get; private set; }

    private Vector3 _position;
    private Money _money;

    public MoneyCell(Vector3 position)
    {
        _position = position;
        IsEmpty = true;
    }

    public Vector3 GetPositionAndAddMoney(Money money)
    {
        IsEmpty = false;
        _money = money;
        _money.MoneyRemoved += OnMoneyRemoved;
        return _position;
    }

    public void OnMoneyRemoved()
    {
        _money.MoneyRemoved -= OnMoneyRemoved;
        IsEmpty = true;
    }
}
