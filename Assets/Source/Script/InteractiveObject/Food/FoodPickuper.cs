using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class FoodPickuper : MonoBehaviour
{
    [Inject] private Player _player;

    public event UnityAction FoodPickedUp;

    public bool TryPickup(Food food)
    {
        if (_player.TryPickUpFood(food))
        {
            PickUpFood(food);
            return true;
        }

        return false;
    }

    private void PickUpFood(Food food)
    {
        ChangeFoodParent(food.transform);
        FoodPickedUp?.Invoke();
    }

    private void ChangeFoodParent(Transform foodTransform)
    {
        foodTransform.SetParent(transform, true);
    }
}
