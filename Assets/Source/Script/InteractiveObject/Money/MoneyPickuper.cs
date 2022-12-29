using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class MoneyPickuper : MonoBehaviour
{
    [SerializeField] private float _pickupDuration;
    [SerializeField] private float _timeBetweenPickups;
    [SerializeField] private float _scaler;
    [SerializeField] private MoneyPickupPlatform _moneyPlatform;

    [Inject] private MoneyCreator _moneyCreator;
    [Inject] private readonly IEnumerable<MoneyCell> _moneyCells;

    private bool _isMoneyPickingUp = false;
    private WaitForSeconds _waitNextMoneyAnimation;

    public event UnityAction MoneyPickedUp;

    private void OnEnable()
    {
        _moneyPlatform.PlayerEntered += OnPlayerEntered;
        _moneyPlatform.PlayerLeft += OnPlayerleft;
    }

    private void Awake()
    {
        _waitNextMoneyAnimation = new WaitForSeconds(_timeBetweenPickups);
    }

    private void OnDisable()
    {
        _moneyPlatform.PlayerEntered -= OnPlayerEntered;
        _moneyPlatform.PlayerLeft -= OnPlayerleft;
    }

    public void Pickup(Money money)
    {
        money.transform.DOScale(_scaler, _pickupDuration);
        money.transform.DOMove(transform.position, _pickupDuration).OnComplete(() => OnPickupComplete(money));
    }

    private void OnPlayerleft()
    {
        _isMoneyPickingUp = false;
    }

    private void OnPickupComplete(Money money)
    {
        MoneyPickedUp?.Invoke();
        money.DestroyMoney();
    }

    private void OnPlayerEntered()
    {
        _isMoneyPickingUp = true;
        StartCoroutine(MoneyPickUp());
    }

    private IEnumerator MoneyPickUp()
    {
        while (_isMoneyPickingUp)
        {
            //var moneyCell = _moneyCells.LastOrDefault(moneyCell => moneyCell.IsEmpty == false);

            if (_moneyCreator.FilledMoneyCells.Count > 0)
            {
                var money = _moneyCreator.FilledMoneyCells.Pop();
                money.Pickup();
                yield return _waitNextMoneyAnimation;
            }
            else
            {
                _isMoneyPickingUp = false;
            }
        }
    }
}
