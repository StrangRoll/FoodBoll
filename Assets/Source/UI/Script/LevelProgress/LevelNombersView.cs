using TMPro;
using UnityEngine;

public class LevelNombersView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _nextLevelText;
    [SerializeField] private LevelProgress _progressBar;

    private void OnEnable()
    {
        _progressBar.LevelChanged += OnFoodGenerated;
    }

    private void OnDisable()
    {
        _progressBar.LevelChanged -= OnFoodGenerated;
    }

    private void OnFoodGenerated(int currentLevel, int nextLevel)
    {
        _currentLevelText.text = currentLevel.ToString();
        _nextLevelText.text = nextLevel.ToString();
    }
}
