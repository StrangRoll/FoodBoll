using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Level[] _levels;
    [SerializeField] private ButtonClickReader _button;

    private List<Level> _futureLevels = new List<Level>();
    private Level _currentLevel = null;

    public event UnityAction<int[]> LevelChanged; 

    private void Awake()
    {
        foreach (var level in _levels)
        {
            level.gameObject.SetActive(false);
            _futureLevels.Add(level);
        }
    }

    private void OnEnable()
    {
        _button.ButtonClicked += OnNextLevelButtonClicked;
    }

    private void Start()
    {
        OnNextLevelButtonClicked();
    }

    private void OnDisable()
    {
        _button.ButtonClicked -= OnNextLevelButtonClicked;
    }

    private void OnNextLevelButtonClicked()
    {
        if (_futureLevels.Count == 0)
            ResetFutureLevels();

        var index = Random.Range(0, _futureLevels.Count);

        if (_currentLevel != null)
            _currentLevel.gameObject.SetActive(false);

        _currentLevel = _futureLevels[index];
        _currentLevel.gameObject.SetActive(true);
        var positionIndexes = _futureLevels[index].ParticipatingStartPositions;
        _futureLevels.RemoveAt(index);
        LevelChanged(positionIndexes);
    }

    private void ResetFutureLevels()
    {
        _futureLevels = new List<Level>();

        foreach (var level in _levels)
        {
            _futureLevels.Add(level);
        }
    }
}
