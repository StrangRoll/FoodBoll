using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class NextLevelPlatform : MonoBehaviour, IPlatform
{
    [SerializeField] private Canvas _platformCanvas;

    [Inject] private FoodGenerator _generator;
    [Inject] private FoodPickuper _pickuper;

    private int _foodCount;
    private bool _isAllFoodPickedUp = false;

    public event UnityAction PlayerEntered;
    public event UnityAction PlayerLeft;

    private void OnEnable()
    {
        _generator.FoodGenerated += OnFoodGenerated;
        _pickuper.FoodPickedUp += OnFoodPickedUp;
        _platformCanvas.enabled = false;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (_isAllFoodPickedUp)
            PlayerEntered?.Invoke();
    }

    public void OnTriggerExit(Collider collider)
    {
        PlayerLeft?.Invoke();
    }

    private void OnDisable()
    {
        _generator.FoodGenerated -= OnFoodGenerated;
        _pickuper.FoodPickedUp -= OnFoodPickedUp;
    }

    private void OnFoodGenerated(int count)
    {
        _foodCount = count;
    }

    private void OnFoodPickedUp()
    {
        _foodCount--;

        if (_foodCount == 0)
        {
            _isAllFoodPickedUp = true;
            _platformCanvas.enabled = true;
        }

        if (_foodCount < 0)
            Debug.LogError("Leftover food count less than zero");
    }
}
