using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class SizeUpgradeButton : UpgradeButton
{
    [SerializeField] private float _deltaSize;

    [Inject] private PlayerDataLoader _loader;

    public event UnityAction<float> SizeIncreased;

    private new void OnEnable()
    {
        base.OnEnable();
        _loader.SizeButtonLevelLoaded += OnSizeButtonLevelLoaded;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        _loader.SizeButtonLevelLoaded -= OnSizeButtonLevelLoaded;
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
            SizeIncreased?.Invoke(_deltaSize * deltaLevel);

            for (int i = 0; i < deltaLevel; i++)
            {
                UpdateButtonInfo();
            }
        }
    }
}
