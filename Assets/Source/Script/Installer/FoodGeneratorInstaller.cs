using UnityEngine;
using Zenject;

public class FoodGeneratorInstaller : MonoInstaller
{
    [SerializeField] private OldFoodGenerator _generator;

    public override void InstallBindings()
    {
        Container
            .Bind<OldFoodGenerator>()
            .FromInstance(_generator)
            .AsSingle();
    }
}