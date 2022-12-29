using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CapacityUpgradeButton : UpgradeButton
{
    [SerializeField] private int _deltaCapacity;

    public event UnityAction<int> CapacityIncreased;

    private new void OnEnable()
    {
        base.OnEnable();
    }

    private new void OnDisable()
    {
        base.OnDisable();
    }

    protected override void GetUpgrade()
    {
        CapacityIncreased?.Invoke(_deltaCapacity);
    }

    private void CapacityButtonLevelLoaded(int buttonLevel)
    {
        var deltaLevel = buttonLevel - 1;

        if (deltaLevel > 0)
        { 
            for (int i = 0; i < deltaLevel; i++)
            {
                UpdateButtonInfo();
            }
        }
    }
}