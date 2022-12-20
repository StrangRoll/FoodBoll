using UnityEngine;
using Zenject;

public class FoodGenerator : MonoBehaviour
{
    [Inject] private Food[] _foodPrefabs;
    [Inject(Id = ZenjectId.FoodGeneratorParametersMinFood)] private float _minFoodCount;
    [Inject(Id = ZenjectId.FoodGeneratorParametersMaxFood)] private float _maxFoodCount;
    [Inject(Id = ZenjectId.FoodGeneratorParametersRadius)] private float _radius;
    [Inject(Id = ZenjectId.FoodGeneratorParameters)] private ParticleSystem _particle;

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
            var newFood = Instantiate(food, foodPosition, food.transform.rotation);
        }

        var newParticle = Instantiate(_particle, transform.position + _particle.transform.position, _particle.transform.rotation);
        newParticle.Play();
    }
}
