using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class VideoAdd : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _rewardButton;

    [Inject] private SizeUpgradeButton _sizeUpgrade;
    [Inject] private SpeedUpgradeButton _speedUpgrade;
    [Inject] private CapacityUpgradeButton _capacityUpgrade;

    public event UnityAction<int> VideoAdShowed;

    private void OnEnable()
    {
        _rewardButton.ButtonClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _rewardButton.ButtonClicked += OnButtonClicked;

    }

    private void OnButtonClicked()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show();
        var addedMoney = (int)((_sizeUpgrade.Price + _speedUpgrade.Price + _capacityUpgrade.Price) / 3 * 1.5f);
        VideoAdShowed?.Invoke(addedMoney);
#endif

    }
}
