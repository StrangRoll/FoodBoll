using UnityEngine;
using Zenject;

public class FoodGeneratorParametersInstaller : MonoInstaller
{
    [SerializeField] private Food[] _foodPrefabs;
    [SerializeField] private float _minFoodCount;
    [SerializeField] private float _maxFoodCount;
    [SerializeField] private float _radius;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _startScale;
    [SerializeField] private ParticleSystem _particle;

    public override void InstallBindings()
    {
        Container
            .Bind<Food[]>()
            .FromInstance(_foodPrefabs);

        Container
            .Bind<float>()
            .WithId(FoodGeneratorParametersId.MinFood)
            .FromInstance(_minFoodCount);

        Container
            .Bind<float>()
            .WithId(FoodGeneratorParametersId.MaxFood)
            .FromInstance(_maxFoodCount);

        Container
            .Bind<float>()
            .WithId(FoodGeneratorParametersId.Radius)
            .FromInstance(_radius);        
        
        Container
            .Bind<float>()
            .WithId(FoodGeneratorParametersId.JumpPower)
            .FromInstance(_jumpPower);        
        
        Container
            .Bind<float>()
            .WithId(FoodGeneratorParametersId.JumpDuration)
            .FromInstance(_jumpDuration);

        var startScale = new Vector3(_startScale, _startScale, _startScale);

        Container
            .Bind<Vector3>()
            .WithId(FoodGeneratorParametersId.StartScale)
            .FromInstance(startScale);

        Container
            .Bind<ParticleSystem>()
            .WithId(FoodGeneratorParametersId.Particle)
            .FromInstance(_particle);
    }
}