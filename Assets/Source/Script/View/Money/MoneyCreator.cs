using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using System.Linq;

public class MoneyCreator : MonoBehaviour
{
    [SerializeField] private FoodSellerView _foodSellerView;
    [SerializeField] private Money _moneyPrefab;

    [Inject] private readonly IEnumerable<MoneyCell> _moneyCells;

    private Money[] _money;

    public event UnityAction<Vector3, Money> MoneyCreated;

    private void Awake()
    {
        _money = new Money[_moneyCells.Count()];

        for (int i = 0; i < _moneyCells.Count(); i++)
        {
            var newMoney = Instantiate(_moneyPrefab);
            _money[i] = newMoney;
            newMoney.gameObject.SetActive(false);
        }
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
                var newMoney = _money.FirstOrDefault(money => money.gameObject.activeSelf == false);

                if (newMoney != null)
                {
                    newMoney.gameObject.SetActive(true);
                    var moneyPosition = moneyCell.GetPositionAndAddMoney(newMoney);
                    MoneyCreated?.Invoke(moneyPosition, newMoney);
                }
            }
        }
    }
}
