using UnityEngine;
using Zenject;

public class FoodPickuper : MonoBehaviour
{
    [Inject] private Player _player;

    public void Pickup(Food food)
    {
        if (_player.TryPickUpFood(food))
        {
            ChangeFoodParent(food.transform);
        }
    }

    private void ChangeFoodParent(Transform foodTransform)
    {
        foodTransform.SetParent(transform, true);
    }
}
