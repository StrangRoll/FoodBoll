using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CurrentOccupancyView : MonoBehaviour
{
    [SerializeField] private Image _occupancyRateImage;
    [SerializeField] private RectTransform _iamgeRectTransform;

    [Inject] private Player _player;
    [Inject] private SizeUpgradeButton _sizeUpgrade;

    private void OnEnable()
    {
        _player.CurrentOccupancyChanged += OnCurrentOccupancyChanged;
        _sizeUpgrade.SizeIncreased += OnSizeIncreased;
    }

    private void OnDisable()
    {
        _player.CurrentOccupancyChanged -= OnCurrentOccupancyChanged;
        _sizeUpgrade.SizeIncreased -= OnSizeIncreased;
    }

    private void OnCurrentOccupancyChanged(float currentValue, float maxValue)
    {
        _occupancyRateImage.fillAmount = currentValue / maxValue;
    }

    private void OnSizeIncreased(float deltaSphereSize)
    {
        var deltaSize = deltaSphereSize * 2;
        var newSize = new Vector2(_iamgeRectTransform.sizeDelta.x + deltaSize, _iamgeRectTransform.sizeDelta.y + deltaSize);
        _iamgeRectTransform.sizeDelta = newSize;
    }
}
