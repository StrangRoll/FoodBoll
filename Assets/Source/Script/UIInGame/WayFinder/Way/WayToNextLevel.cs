using UnityEngine;
using Zenject;

public class WayToNextLevel : MonoBehaviour
{
    [SerializeField] private WayFinderActivator _activator;

    [Inject] private LevelProgress _progress;
    [Inject] private OldFoodGenerator _generator;

    private void OnEnable()
    {
        _progress.AllFoodPickedUp += OnAllFoodPickedUp;
        _generator.FoodGenerated += OnFoodGenerated;
    }

    private void OnDisable()
    {
        _progress.AllFoodPickedUp -= OnAllFoodPickedUp;
        _generator.FoodGenerated -= OnFoodGenerated;
    }

    private void OnFoodGenerated(int count)
    {
        _activator.Deactivate();
    }

    private void OnAllFoodPickedUp()
    {
        _activator.Activate();
    }
}
