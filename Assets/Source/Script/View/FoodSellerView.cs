using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.Events;

public class FoodSellerView : MonoBehaviour
{
    [SerializeField] private Transform _sellPoint;
    [SerializeField] private float _sellAnimationDuration;
    [SerializeField] private float _reducedFoodSize;
    [SerializeField] private float _jumpPower;

    [Inject] private Player _player;

    private int _jumpCount = 1;

    public event UnityAction<float> FoodSell;

    private void OnEnable()
    {
        _player.SellFood += OnSellFood;
    }

    private void OnDisable()
    {
        _player.SellFood -= OnSellFood;
    }

    private void OnSellFood(Food food)
    {
        food.transform.DOJump(_sellPoint.position, _jumpPower, _jumpCount, _sellAnimationDuration);
        food.transform.DOScale(_reducedFoodSize, _sellAnimationDuration).OnComplete(() => OnAnimationCompelte(food));
    }

    private void OnAnimationCompelte(Food food)
    {
        var price = food.Price;
        Destroy(food.gameObject);
        FoodSell?.Invoke(food.Price);
    }
}
