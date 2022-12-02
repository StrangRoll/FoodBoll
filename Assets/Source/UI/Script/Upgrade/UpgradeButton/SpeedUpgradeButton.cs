using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class SpeedUpgradeButton : UpgradeButton
{
    [SerializeField] private float _deltaSpeed;

    [Inject] private PlayerDataLoader _loader;

    public event UnityAction<float> SpeedIncreased;

    private new void OnEnable()
    {
        base.OnEnable();
        _loader.SpeedButtonLevelLoaded += OnSpeedButtonLevelLoaded;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        _loader.SpeedButtonLevelLoaded -= OnSpeedButtonLevelLoaded;
    }

    protected override void GetUpgrade()
    {
        SpeedIncreased?.Invoke(_deltaSpeed);
    }

    private void OnSpeedButtonLevelLoaded(int buttonLevel)
    {
        var deltaLevel = buttonLevel - 1;

        if (deltaLevel > 0)
        {
            SpeedIncreased?.Invoke(_deltaSpeed * deltaLevel);

            for (int i = 0; i < deltaLevel; i++)
            {
                UpdateButtonInfo();
            }
        }
    }
}
