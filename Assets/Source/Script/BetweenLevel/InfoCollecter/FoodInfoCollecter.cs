using UnityEngine;
using Zenject;

public class FoodInfoCollecter : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;

    private Food[] _food;

    public FoodInformation[] CollectFoodInfod()
    {
        _food = _sphere.GetComponentsInChildren<Food>();
        var foodInformation = new FoodInformation[_food.Length];

        for (int i = 0; i < _food.Length; i++)
        {
            foodInformation[i] = new FoodInformation(_food[i].Prefab, _food[i].transform.localPosition, _food[i].transform.rotation, _food[i].transform.localScale);
        }

        return foodInformation;
    }
}
