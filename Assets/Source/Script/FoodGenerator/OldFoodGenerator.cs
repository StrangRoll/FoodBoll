using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class OldFoodGenerator : MonoBehaviour
{
    [SerializeField] private Food[] _foodPrefabs;
    [SerializeField] private Transform _foodParent;
    [SerializeField] private LevelChanger _levelChanger;

    [Inject (Id = ZenjectId.FoodPosition)] private readonly Vector2[] _startPositions;
    [Inject (Id = ZenjectId.FoodPosition)] private readonly Vector2 _blockDimensions;

    private float _blockWidth;
    private float _blockHeight;

    public event UnityAction<int> FoodGenerated;

    private void Awake()
    {
        _blockWidth = _blockDimensions.x;
        _blockHeight = _blockDimensions.y;
    }

    private void OnEnable()
    {
        _levelChanger.LevelChanged += OnLevelChanged;
    }

    private void OnDisable()
    {
        _levelChanger.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged(int[] startPositionIndexes)
    {
        GenerateFood(startPositionIndexes);
    }

    private void GenerateFood(int[] startPositionIndexes)
    {
        var foodCount = 0;
        
        foreach (var index in startPositionIndexes)
        {
            var position = _startPositions[index];
            var foodIndex = Random.Range(0, _foodPrefabs.Length);
            var food = _foodPrefabs[foodIndex];
            var foodInLine = (int)(_blockWidth / food.RequiredSpace) - 1;
            var foodInColumn = (int)(_blockHeight / food.RequiredSpace) - 1;
            var halfSpace = food.RequiredSpace / 2;

            for (int i = 0; i < foodInLine; i++)
            {
                for (int j = 0; j < foodInColumn; j++)
                {
                    var xFoodPosition = position.x + food.RequiredSpace * i + halfSpace + halfSpace/2;
                    var zFoodPosition = position.y - food.RequiredSpace * j - halfSpace - halfSpace / 2;
                    var foodPosition = new Vector3(xFoodPosition, food.transform.position.y, zFoodPosition);
                    var newFood = NightPool.Spawn(food, foodPosition, food.transform.rotation);
                    newFood.transform.parent = _foodParent;
                    foodCount++;
                }
            }
        }

        FoodGenerated?.Invoke(foodCount);
    }
}
