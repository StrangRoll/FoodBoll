using DG.Tweening;
using UnityEngine;

public class MoneyCreatiorView : MonoBehaviour
{
    [SerializeField] private MoneyCreator _moneyCreator;
    [SerializeField] private Transform _moneyCreatePosition;
    [SerializeField] private Transform _moneyParent;
    [SerializeField] private float _animationDuration;

    private void OnEnable()
    {
        _moneyCreator.MoneyCreated += OnMoneyCreated;
    }

    private void OnDisable()
    {
        _moneyCreator.MoneyCreated -= OnMoneyCreated;
    }

    private void OnMoneyCreated(Vector3 position, Money newMoney)
    {
        newMoney.transform.SetParent(transform);
        newMoney.transform.position = _moneyCreatePosition.position;
        newMoney.transform.SetParent(_moneyParent);
        newMoney.transform.DOMove(position, _animationDuration);
    }
}