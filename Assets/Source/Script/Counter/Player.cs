using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereMovier))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _priceCapacity;
    [SerializeField] private float _size;

    private Queue<Food> _food = new Queue<Food>();
    private float _currentPrice;

    public event UnityAction<Food> SellFood;

    public bool TryPickUp(Food food)
    {
        if (food.RequiredSize <= _size && _currentPrice + food.Price <= _priceCapacity)
        {
            _currentPrice += food.Price;
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
            _currentPrice -= food.Price;
            SellFood?.Invoke(food);
            return true;
        }

        return false;
    }
}
