using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class NextLevelPlatform : MonoBehaviour, IPlatform
{
    [SerializeField] private Canvas _platformCanvas;
    [SerializeField] private GameObject _nextLevelSign;

    [Inject] private OldFoodGenerator _generator;
    [Inject] private LevelProgress _progress;

    private bool _isAllFoodPickedUp = false;

    public event UnityAction PlayerEntered;
    public event UnityAction PlayerLeft;

    private void OnEnable()
    {
        _generator.FoodGenerated += OnFoodGenerated;
        _progress.AllFoodPickedUp += OnAllFoodPickedUp;
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
        _progress.AllFoodPickedUp -= OnAllFoodPickedUp;
    }

    private void OnFoodGenerated(int count)
    {
        _isAllFoodPickedUp = false;
        _platformCanvas.enabled = false;
        _nextLevelSign.SetActive(false);
        PlayerLeft?.Invoke();
    }

    private void OnAllFoodPickedUp()
    {
        _isAllFoodPickedUp = true;
        _platformCanvas.enabled = true;
        _nextLevelSign.SetActive(true);
    }
}
