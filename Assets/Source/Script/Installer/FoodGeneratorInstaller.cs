using UnityEngine;
using Zenject;

public class FoodGeneratorInstaller : MonoInstaller
{
    [SerializeField] private FoodGenerator _generator;

    public override void InstallBindings()
    {
        Container
            .Bind<FoodGenerator>()
            .FromInstance(_generator)
            .AsSingle();
    }
}