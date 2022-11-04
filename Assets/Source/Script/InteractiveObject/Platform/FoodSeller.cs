using System.Collections;
using UnityEngine;
using Zenject;

public class FoodSeller : Platform
{
    [SerializeField] private float _timeBetweenSell;

    [Inject] private Player _player;

    private bool _canSellFood = false;
    private WaitForSeconds _whaitNextSell;

    private void OnEnable()
    {
        _player.SellFood += OnSellFood;
        _whaitNextSell = new WaitForSeconds(_timeBetweenSell);
    }

    private void OnDisable()
    {
        _player.SellFood -= OnSellFood;
    }

    protected override void OnPlayerEnter(Player player)
    {
        _canSellFood = true;
        StartCoroutine(FoodSelling(player));
    }

    protected override void OnPlayerExit()
    {
        _canSellFood = false;
    }

    private IEnumerator FoodSelling(Player player)
    {
        while (_canSellFood)
        {
            if (player.TrySellFood() == false)
            {
                _canSellFood = false;
            }

            yield return _whaitNextSell;
        }
    }

    private void OnSellFood(Food food)
    {
        Destroy(food.gameObject);
    }
}
