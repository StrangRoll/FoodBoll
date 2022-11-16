using UnityEngine;
using UnityEngine.Events;

public class CapacityUpgradeButton : UpgradeButton
{
    [SerializeField] private int _deltaCapacity;

    public event UnityAction<int> CapacityIncreased;

    protected override void GetUpgrade()
    {
        CapacityIncreased?.Invoke(_deltaCapacity);
    }
}
