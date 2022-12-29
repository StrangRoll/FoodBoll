using UnityEngine;
using UnityEngine.Events;

public class SpeedUpgradeButton : UpgradeButton
{
    [SerializeField] private float _deltaSpeed;

    public event UnityAction<float> SpeedIncreased;

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
        SpeedIncreased?.Invoke(_deltaSpeed);
    }

    private void OnSpeedButtonLevelLoaded(int buttonLevel)
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