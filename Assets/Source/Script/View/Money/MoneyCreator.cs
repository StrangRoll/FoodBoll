using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using System.Linq;

public class MoneyCreator : MonoBehaviour
{
    [SerializeField] private FoodSellerView _foodSellerView;
    [SerializeField] private Money _moneyPrefab;

    [Inject] private IEnumerable<MoneyCell> _moneyCells;

    public event UnityAction<Vector3, Money> MoneyCreated;

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
                var newMoney = Instantiate(_moneyPrefab);
                var moneyPosition = moneyCell.GetPositionAndAddMoney(newMoney);
                MoneyCreated?.Invoke(moneyPosition, newMoney);
            }
        }
    }
}
