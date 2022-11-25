using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class FoodGenerator : MonoBehaviour
{
    [SerializeField] private Food[] _foodPrefabs;
    [SerializeField] private Transform _foodParent;
    [SerializeField] private ButtonClickReader _button;

    [Inject (Id = ZenjectId.FoodPosition)] private readonly Vector2[] _startPositions;
    [Inject (Id = ZenjectId.FoodPosition)] private readonly Vector2 _blockDimensions;

    private float _blockWidth;
    private float _blockHeight;

    public event UnityAction<int> FoodGenerated;

    private void OnEnable()
    {
        _button.ButtonClicked += OnButtonClicked;
    }

    private void Start()
    {
        _blockWidth = _blockDimensions.x;
        _blockHeight = _blockDimensions.y;
        GenerateFood();
    }

    private void OnDisable()
    {
        _button.ButtonClicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        GenerateFood();
    }

    private void GenerateFood()
    {
        var foodCount = 0;

        foreach (var position in _startPositions)
        {
            var foodIndex = Random.Range(0, _foodPrefabs.Length);
            var food = _foodPrefabs[foodIndex];
            var foodInLine = (int)(_blockWidth / food.RequiredSpace) - 1;
            var foodInColumn = (int)(_blockHeight / food.RequiredSpace) - 1;
            var halfSpace = food.RequiredSpace / 2;

            for (int i = 0; i < foodInLine; i++)
            {
                for (int j = 0; j < foodInColumn; j++)
                {
                    var xFoodPosition = position.x + food.RequiredSpace * i + halfSpace;
                    var zFoodPosition = position.y - food.RequiredSpace * j - halfSpace;
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
