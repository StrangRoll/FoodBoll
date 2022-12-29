using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] private PlayerData _data;

    private Queue<Food> _food = new Queue<Food>();
    private float _currentPrice;

    public event UnityAction<Food> SellFood;
    public event UnityAction<float, float> CurrentOccupancyChanged;
    public event UnityAction PlayerFull;
    public event UnityAction PlayerNotFullMore;

    public bool IsEmpy
    {
        get
        {
            return _food.Count == 0;
        }
    }

    public bool TryPickUpFood(Food food)
    {
        if (_currentPrice < _data.Capacity)
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
        if (_currentPrice == _data.Capacity && deltaPrice < 0)
            PlayerNotFullMore?.Invoke();

        _currentPrice += deltaPrice;

        if (_currentPrice < 0)
            _currentPrice = 0;

        if (_currentPrice > _data.Capacity)
            _currentPrice = _data.Capacity;

        if (_currentPrice == _data.Capacity)
            PlayerFull?.Invoke();

        CurrentOccupancyChanged?.Invoke(_currentPrice, _data.Capacity);
    }
}
