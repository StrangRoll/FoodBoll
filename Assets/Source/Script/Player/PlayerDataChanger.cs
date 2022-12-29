using UnityEngine;
using Zenject;

public class PlayerDataChanger : MonoBehaviour
{
    [SerializeField] private PlayerData _data;

    [Inject] private SpeedUpgradeButton _speedUpgrade;
    [Inject] private CapacityUpgradeButton _capacityUpgrade;
    [Inject] private SizeUpgradeButton _sizeUpgrade;


    private void OnEnable()
    {
        _speedUpgrade.SpeedIncreased += OnSpeedIncreased;
        _capacityUpgrade.CapacityIncreased += OnCapacityIncreased;
        _sizeUpgrade.SizeIncreased += OnSizeIncreased;
    }

    private void OnDisable()
    {
        _speedUpgrade.SpeedIncreased -= OnSpeedIncreased;
        _capacityUpgrade.CapacityIncreased -= OnCapacityIncreased;
        _sizeUpgrade.SizeIncreased += OnSizeIncreased;
    }

    private void OnSpeedIncreased(float deltaSpeed)
    {
        _data.IncreaseSpeed(deltaSpeed);
    }

    private void OnCapacityIncreased(int deltaCapacity)
    {
        _data.IncreaseCapacity(deltaCapacity);
    }
    private void OnSizeIncreased(float deltaSize)
    {
        _data.IncreaseSize(deltaSize);
    }
}
