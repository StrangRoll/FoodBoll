using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public abstract class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Inject] private PlayerWallet _wallet;

    private int _priceIncrease = 25;
    private int _currentLevel = 1;

    public event UnityAction<int, int> ButtonInfoChanged;

    public int Price { get; private set; } = 75;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void Start()
    {
        ButtonInfoChanged?.Invoke(Price, _currentLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    protected abstract void GetUpgrade();

    private void OnButtonClicked()
    {
        if (_wallet.IsEnoughMoney(Price))
        {
            _wallet.DoPurchase();
            GetUpgrade();
            UpdateButtonInfo();
        }
    }

    private void UpdateButtonInfo()
    {
        Price += _priceIncrease;
        _currentLevel++;
        ButtonInfoChanged?.Invoke(Price, _currentLevel);
    }
}
