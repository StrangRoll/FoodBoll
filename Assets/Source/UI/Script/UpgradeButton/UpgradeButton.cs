using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public abstract class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Inject] private PlayerWallet _wallet;

    private int _price = 75;
    private int _priceIncrease = 25;
    private int _currentLevel = 1;

    public event UnityAction<int, int> ButtonInfoChanged;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void Start()
    {
        ButtonInfoChanged?.Invoke(_price, _currentLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    protected abstract void GetUpgrade();

    private void OnButtonClicked()
    {
        if (_wallet.IsEnoughMoney(_price))
        {
            _wallet.DoPurchase();
            GetUpgrade();
            UpdateButtonInfo();
        }
    }

    private void UpdateButtonInfo()
    {
        _price += _priceIncrease;
        _currentLevel++;
        ButtonInfoChanged?.Invoke(_price, _currentLevel);
    }
}
