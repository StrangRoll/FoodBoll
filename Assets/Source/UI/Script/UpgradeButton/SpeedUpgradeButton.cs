using UnityEngine;
using UnityEngine.Events;

public class SpeedUpgradeButton : UpgradeButton
{
    [SerializeField] private float _deltaSpeed;

    public event UnityAction<float> SpeedIncreased;

    protected override void GetUpgrade()
    {
        SpeedIncreased?.Invoke(_deltaSpeed);
    }
}
