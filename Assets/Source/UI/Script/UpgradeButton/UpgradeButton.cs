using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public abstract class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Inject] private PlayerWallet _wallet;

    private int _price = 5;
    private int _currentLevel = 1;

    public event UnityAction<int, int> ButtinInfoChanged;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void Start()
    {
        ButtinInfoChanged?.Invoke(_price, _currentLevel);
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
        _price++;
        _currentLevel++;
        ButtinInfoChanged?.Invoke(_price, _currentLevel);
    }
}
