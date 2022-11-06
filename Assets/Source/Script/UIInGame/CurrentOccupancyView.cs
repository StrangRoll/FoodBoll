using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CurrentOccupancyView : MonoBehaviour
{
    [SerializeField] private Image _occupancyRateImage;

    [Inject] private Player _player;

    private void OnEnable()
    {
        _player.CurrentOccupancyChanged += OnCurrentOccupancyChanged;
    }

    private void OnDisable()
    {
        _player.CurrentOccupancyChanged -= OnCurrentOccupancyChanged;
    }

    private void OnCurrentOccupancyChanged(float currentValue, float maxValue)
    {
        _occupancyRateImage.fillAmount = currentValue / maxValue;
    }
}
