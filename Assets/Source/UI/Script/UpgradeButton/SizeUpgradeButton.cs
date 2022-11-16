using UnityEngine;
using UnityEngine.Events;

public class SizeUpgradeButton : UpgradeButton
{
    [SerializeField] private float _deltaSize;

    public event UnityAction<float> SizeIncreased;

    protected override void GetUpgrade()
    {
        SizeIncreased?.Invoke(_deltaSize);
    }
}
