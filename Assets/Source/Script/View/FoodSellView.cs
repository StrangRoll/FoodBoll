using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.Events;

public class FoodSellView : MonoBehaviour
{
    [SerializeField] private Transform _sellPoint;
    [SerializeField] private float _sellAnimationDuration;
    [SerializeField] private float _reducedFoodSize;

    [Inject] private Player _player;

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
        food.transform.DOMove(_sellPoint.position, _sellAnimationDuration);
        food.transform.DOScale(_reducedFoodSize, _sellAnimationDuration).OnComplete(() => OnAnimationCompelte(food));
    }

    private void OnAnimationCompelte(Food food)
    {
        FoodSell?.Invoke(food.Price);
        Destroy(food.gameObject);
    }
}
