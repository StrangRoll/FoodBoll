using UnityEngine;

[RequireComponent(typeof(SphereMovier))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _priceCapacity;
    [SerializeField] private float _size;

    private float _currentPrice;

    public bool TryPickUp(Food food)
    {
        if (food.RequiredSize <= _size && _currentPrice + food.Price <= _priceCapacity)
        {
            _currentPrice += food.Price;
            return true;
        }

        return false;
    }
}
