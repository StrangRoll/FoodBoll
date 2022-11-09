using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _priceCapacity;
    [SerializeField] private float _size;

    private Queue<Food> _food = new Queue<Food>();
    private float _currentPrice;

    public event UnityAction<Food> SellFood;
    public event UnityAction<float, float> CurrentOccupancyChanged;
    public event UnityAction PlayerFull;
    public event UnityAction PlayerNotFullMore;

    public bool TryPickUpFood(Food food)
    {
        if (food.RequiredSize <= _size && _currentPrice + food.Price <= _priceCapacity)
        {
            ChangeCurrentPrice(food.Price);
            _food.Enqueue(food);
            return true;
        }

        return false;
    }

    public bool TrySellFood()
    {
        if (_food.Count > 0)
        {
            var food = _food.Dequeue();
            ChangeCurrentPrice(food.Price * -1);
            SellFood?.Invoke(food);

            return true;
        }

        return false;
    }

    private void ChangeCurrentPrice(float deltaPrice)
    {
        if (_currentPrice == _priceCapacity && deltaPrice < 0)
            PlayerNotFullMore?.Invoke();

        _currentPrice += deltaPrice;

        if (_currentPrice < 0 || _currentPrice > _priceCapacity)
            Debug.LogError($"Incorrent player's current price! Current value = {_currentPrice}");

        if (_currentPrice == _priceCapacity)
            PlayerFull?.Invoke();

        CurrentOccupancyChanged?.Invoke(_currentPrice, _priceCapacity);
    }
}
