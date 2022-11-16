using UnityEngine;
using Zenject;

public class FoodPickuper : MonoBehaviour
{
    [Inject] private Player _player;

    public bool TryPickup(Food food)
    {
        if (_player.TryPickUpFood(food))
        {
            ChangeFoodParent(food.transform);
            return true;
        }

        return false;
    }

    private void ChangeFoodParent(Transform foodTransform)
    {
        foodTransform.SetParent(transform, true);
    }
}
