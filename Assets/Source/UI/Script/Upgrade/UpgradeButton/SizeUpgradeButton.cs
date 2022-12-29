using UnityEngine;
using UnityEngine.Events;

public class SizeUpgradeButton : UpgradeButton
{
    [SerializeField] private float _deltaSize;

    public event UnityAction<float> SizeIncreased;

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
        SizeIncreased?.Invoke(_deltaSize);
    }

    private void OnSizeButtonLevelLoaded(int buttonLevel)
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