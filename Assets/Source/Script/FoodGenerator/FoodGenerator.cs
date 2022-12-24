using NTC.Global.Pool;
using UnityEngine;
using Zenject;

public class FoodGenerator : MonoBehaviour
{
    [Inject] private Food[] _foodPrefabs;
    [Inject(Id = FoodGeneratorParametersId.MinFood)] private float _minFoodCount;
    [Inject(Id = FoodGeneratorParametersId.MaxFood)] private float _maxFoodCount;
    [Inject(Id = FoodGeneratorParametersId.Radius)] private float _radius;
    [Inject(Id = FoodGeneratorParametersId.JumpPower)] private float _jumpPower;
    [Inject(Id = FoodGeneratorParametersId.JumpDuration)] private float _jumpDuration;
    [Inject(Id = FoodGeneratorParametersId.StartScale)] private Vector3 _startScale;
    [Inject(Id = FoodGeneratorParametersId.Particle)] private ParticleSystem _particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Floor>(out Floor floor))
            GenerateFood();
    }

    private void GenerateFood()
    {
        var foodCount = Random.Range(_minFoodCount, _maxFoodCount + 1);

        for (int i = 0; i < foodCount; i++)
        {
            var foodIndex = Random.Range(0, _foodPrefabs.Length);
            var food = _foodPrefabs[foodIndex];
            var RandomCircle = _radius * Random.insideUnitCircle;
            Vector3 foodPosition = transform.position + new Vector3(RandomCircle.x, food.transform.position.y, RandomCircle.y);
            var newFood = NightPool.Spawn(food, transform.position, food.transform.rotation);
            newFood.Init(foodPosition, _jumpPower, _jumpDuration, _startScale);
        }

        var newParticle = NightPool.Spawn(_particle, transform.position + _particle.transform.position, _particle.transform.rotation);
        newParticle.Play();
        enabled = false;
    }
}
