using UnityEngine;
using Zenject;

public class FoodPickuperInstaller : MonoInstaller
{
    [SerializeField] private FoodPickuper _foodPickuper;

    public override void InstallBindings()
    {
        Container
            .Bind<FoodPickuper>()
            .FromInstance(_foodPickuper)
            .AsSingle();
    }
}