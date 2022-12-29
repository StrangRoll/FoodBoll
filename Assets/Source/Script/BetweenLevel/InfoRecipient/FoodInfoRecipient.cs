using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class FoodInfoRecipient : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;
    [Inject] private Player _player;

    private FoodInformation[] _foodInfo;

    public event UnityAction PlayerNotEmpty;

    private void Start()
    {
        if (_foodInfo == null)
            return;

        var sphereTransform = _sphere.transform;

        foreach (var argument in _foodInfo)
        {
            var newFood = NightPool.Spawn(argument.Prefab , _sphere.transform, argument.Rotation, false);
            newFood.transform.localScale = argument.Scale;
            newFood.transform.localPosition = argument.Position;
            newFood.InitWithoutAnimation(argument.Prefab);
            _player.TryPickUpFood(newFood);
        }

        if (_foodInfo.Length > 0)
            PlayerNotEmpty?.Invoke();

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
