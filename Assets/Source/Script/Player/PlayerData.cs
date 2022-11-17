using UnityEngine;
using Zenject;

public class PlayerData : MonoBehaviour
{
    [Inject] private SpeedUpgradeButton _speedUpgrade;
    [Inject] private SizeUpgradeButton _sizeUpgrade;
    [Inject] private CapacityUpgradeButton _capacityUpgrade;

    public int PriceCapacity { get; private set; } = 20;
    public float Size { get; private set; } = 1;
    public float Speed { get; private set; } = 2f;

    private void OnEnable()
    {
        _speedUpgrade.SpeedIncreased += OnSpeedIncreased;
        _sizeUpgrade.SizeIncreased += OnSizeIncreased;
        _capacityUpgrade.CapacityIncreased += OnCapacityIncreased;
    }

    private void OnDisable()
    {
        _speedUpgrade.SpeedIncreased -= OnSpeedIncreased;
        _sizeUpgrade.SizeIncreased -= OnSizeIncreased;
        _capacityUpgrade.CapacityIncreased -= OnCapacityIncreased;
    }

    private void OnSpeedIncreased(float deltaSpeed)
    {
        Speed += deltaSpeed;
    }

    private void OnSizeIncreased(float deltaSize)
    {
        Size += deltaSize;
    }

    private void OnCapacityIncreased(int deltaCapacity)
    {
        PriceCapacity += deltaCapacity;
    }
}
