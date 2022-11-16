using UnityEngine;
using Zenject;

public class SphereSizeIncreaser : MonoBehaviour
{
    [Inject] private SizeUpgradeButton _sizeUpgrade;

    private void OnEnable()
    {
        _sizeUpgrade.SizeIncreased += OnSizeIncreased;
    }

    private void OnDisable()
    {
        _sizeUpgrade.SizeIncreased += OnSizeIncreased;
    }

    private void OnSizeIncreased(float deltaSize)
    {
        transform.localScale += new Vector3(deltaSize, deltaSize, deltaSize);
    }
}
