using NTC.Global.Pool;
using UnityEngine;

public class MoneyPlusView : MonoBehaviour
{
    [SerializeField] private MoneyCreator _creator;
    [SerializeField] private MoneyPlus _moneyPlus;
    [SerializeField] private Transform _parent;

    private void OnEnable()
    {
        _creator.MoneyPlusCreated += OnMoneyPlusCreated;
    }

    private void OnDisable()
    {
        _creator.MoneyPlusCreated -= OnMoneyPlusCreated;
    }

    private void OnMoneyPlusCreated()
    {
        var newPlus = NightPool.Spawn(_moneyPlus, _parent);
        newPlus.transform.rotation = _moneyPlus.transform.rotation;
    }
}
