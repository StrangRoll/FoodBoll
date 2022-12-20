using UnityEngine;
using Zenject;

public class FoodGeneratorParametersInstaller : MonoInstaller
{
    [SerializeField] private Food[] _foodPrefabs;
    [SerializeField] private float _minFoodCount;
    [SerializeField] private float _maxFoodCount;
    [SerializeField] private float _radius;
    [SerializeField] private ParticleSystem _particle;

    public override void InstallBindings()
    {
        Container
            .Bind<Food[]>()
            .FromInstance(_foodPrefabs);

        Container
            .Bind<float>()
            .WithId(ZenjectId.FoodGeneratorParametersMinFood)
            .FromInstance(_minFoodCount);

        Container
            .Bind<float>()
            .WithId(ZenjectId.FoodGeneratorParametersMaxFood)
            .FromInstance(_maxFoodCount);

        Container
            .Bind<float>()
            .WithId(ZenjectId.FoodGeneratorParametersRadius)
            .FromInstance(_radius);

        Container
            .Bind<ParticleSystem>()
            .WithId(ZenjectId.FoodGeneratorParameters)
            .FromInstance(_particle);
    }
}