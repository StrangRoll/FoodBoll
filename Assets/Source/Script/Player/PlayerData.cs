using UnityEngine;
using Zenject;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _priceCapacity;
    [SerializeField] private float _speed;

    [Inject] private SpeedUpgradeButton _speedUpgrade;
    [Inject] private CapacityUpgradeButton _capacityUpgrade;

    public int PriceCapacity { get { return _priceCapacity; } }
    public float Speed { get { return _speed; } }

    private void OnEnable()
    {
        _speedUpgrade.SpeedIncreased += OnSpeedIncreased;
        _capacityUpgrade.CapacityIncreased += OnCapacityIncreased;
    }

    private void OnDisable()
    {
        _speedUpgrade.SpeedIncreased -= OnSpeedIncreased;
        _capacityUpgrade.CapacityIncreased -= OnCapacityIncreased;
    }

    private void OnSpeedIncreased(float deltaSpeed)
    {
        _speed += deltaSpeed;
    }

    private void OnCapacityIncreased(int deltaCapacity)
    {
        _priceCapacity += deltaCapacity;
    }
}
