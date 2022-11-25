using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CapacityUpgradeButton : UpgradeButton
{
    [SerializeField] private int _deltaCapacity;

    [Inject] private PlayerDataLoader _loader;

    public event UnityAction<int> CapacityIncreased;

    private new void OnEnable()
    {
        base.OnEnable();
        _loader.CapacityButtonLevelLoaded += OnCapacityButtonLevelLoaded;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        _loader.CapacityButtonLevelLoaded -= OnCapacityButtonLevelLoaded;
    }

    protected override void GetUpgrade()
    {
        CapacityIncreased?.Invoke(_deltaCapacity);
    }

    private void OnCapacityButtonLevelLoaded(int buttonLevel)
    {
        var deltaLevel = buttonLevel-1;

        if (deltaLevel > 0)
        {
            CapacityIncreased?.Invoke(_deltaCapacity * deltaLevel);

            for (int i = 0; i < deltaLevel; i++)
            {
                UpdateButtonInfo();
            }
        }
    }
}
