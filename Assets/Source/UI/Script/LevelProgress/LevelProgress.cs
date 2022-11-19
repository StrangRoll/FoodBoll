using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelProgress : MonoBehaviour, ISliderCountChanger
{
    [Inject] private FoodGenerator _generator;
    [Inject] private FoodPickuper _pickuper;

    private int _pickedUpFoodCount;
    private int _allFoodCount;
    private int _currentLevel = 0;

    public event UnityAction<int, int> SliderCountChanged;
    public event UnityAction<int, int> LevelChanged;
    public event UnityAction AllFoodPickedUp;

    private void OnEnable()
    {
        _generator.FoodGenerated += OnFoodGenerated;
        _pickuper.FoodPickedUp += OnFoodPickedUp;
    }

    private void OnDisable()
    {
        _generator.FoodGenerated -= OnFoodGenerated;
        _pickuper.FoodPickedUp -= OnFoodPickedUp;
    }

    private void OnFoodGenerated(int count)
    {
        _allFoodCount = count;
        _pickedUpFoodCount = 0;
        SliderCountChanged?.Invoke(_pickedUpFoodCount, _allFoodCount);
        _currentLevel++;
        LevelChanged?.Invoke(_currentLevel, _currentLevel + 1);
    }

    private void OnFoodPickedUp()
    {
        _pickedUpFoodCount++;
        SliderCountChanged?.Invoke(_pickedUpFoodCount, _allFoodCount);

        if (_pickedUpFoodCount >= _allFoodCount)
            AllFoodPickedUp?.Invoke();
    }
}
