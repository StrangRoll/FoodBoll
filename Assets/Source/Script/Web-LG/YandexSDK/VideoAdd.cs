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
    [Inject] private PauseManager _pauseManager;

    public event UnityAction<int> VideoAddShowed;

    public int AddedMoney
    {
        get
        {
            return (int)((_sizeUpgrade.Price + _speedUpgrade.Price + _capacityUpgrade.Price) / 3 * 1.5f);
        }
    }

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
        if (_pauseManager.IsPaused)
            return;

#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show(() => OnVideoStart(), () => OnRewardGot());
#endif

#if UNITY_EDITOR
        OnRewardGot();
#endif
    }

    private void OnVideoStart() { }

    private void OnRewardGot()
    {
        VideoAddShowed?.Invoke(AddedMoney);
    }
}
