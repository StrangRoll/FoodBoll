using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using System.Linq;
using NTC.Global.Pool;

public class MoneyCreator : MonoBehaviour
{
    [SerializeField] private FoodSellerView _foodSellerView;
    [SerializeField] private Money _moneyPrefab;

    [Inject] private readonly IEnumerable<MoneyCell> _moneyCells;

    private Quaternion _moneyRotation;

    public event UnityAction<Vector3, Money> MoneyCreated;

    private void Awake()
    {
        _moneyRotation = _moneyPrefab.transform.rotation;
    }

    private void OnEnable()
    {
        _foodSellerView.FoodSell += OnFoodSell;
    }

    private void OnDisable()
    {
        _foodSellerView.FoodSell -= OnFoodSell;
    }

    private void OnFoodSell(float moneyCount)
    {
        for (int i = 0; i < moneyCount; i++)
        {
            var moneyCell = _moneyCells.FirstOrDefault(moneyCell => moneyCell.IsEmpty);

            if (moneyCell != null)
            {
                var newMoney = NightPool.Spawn(_moneyPrefab, Vector3.zero, _moneyRotation);

                var moneyPosition = moneyCell.GetPositionAndAddMoney(newMoney);
                MoneyCreated?.Invoke(moneyPosition, newMoney);

            }
        }
    }
}
