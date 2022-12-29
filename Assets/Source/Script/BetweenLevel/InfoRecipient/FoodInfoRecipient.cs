using NTC.Global.Pool;
using UnityEngine;
using Zenject;

public class FoodInfoRecipient : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;
    [Inject] private Player _player;

    private FoodInformation[] _foodInfo;

    private void Awake()
    {
        if (_foodInfo == null)
            return;

        var sphereTransform = _sphere.transform;

        foreach (var argument in _foodInfo)
        {
            var newFood = NightPool.Spawn(argument.Prefab, argument.Position, argument.Rotation);
            newFood.transform.SetParent(sphereTransform, false);
            _player.TryPickUpFood(newFood);
        }

        _foodInfo = null;
    }

    public void GetInfo(FoodInformation[] foodInfo)
    {
        _foodInfo = new FoodInformation[foodInfo.Length];

        for (int i = 0; i < foodInfo.Length; i++)
        {
            _foodInfo[i] = foodInfo[i];
        }
    }
}
