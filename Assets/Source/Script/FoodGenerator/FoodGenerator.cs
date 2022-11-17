using UnityEngine;
using Zenject;

public class FoodGenerator : MonoBehaviour
{
    [SerializeField] private Food[] _foodPrefabs;
    [SerializeField] private Transform _foodParent;

    [Inject (Id = ZenjectId.FoodPosition)] private readonly Vector2[] _startPositions;
    [Inject (Id = ZenjectId.FoodPosition)] private readonly Vector2 _blockDimensions;

    private float _blockWidth;
    private float _blockHeight;

    private void Awake()
    {
        _blockWidth = _blockDimensions.x;
        _blockHeight = _blockDimensions.y;
        GenerateFood();
    }

    private void GenerateFood()
    {
        foreach (var position in _startPositions)
        {
            var foodIndex = Random.Range(0, _foodPrefabs.Length);
            var food = _foodPrefabs[foodIndex];
            var foodInLine = (int)(_blockWidth / food.RequiredSpace);
            var foodInColumn = (int)(_blockHeight / food.RequiredSpace);

            for (int i = 0; i < foodInLine; i++)
            {
                for (int j = 0; j < foodInColumn; j++)
                {
                    var xFoodPosition = position.x + food.RequiredSpace * i;
                    var zFoodPosition = position.y - food.RequiredSpace * j;
                    var foodPosition = new Vector3(xFoodPosition, food.transform.position.y, zFoodPosition);
                    Instantiate(food, foodPosition, food.transform.rotation, _foodParent);
                }
            }
        }
    }
}
