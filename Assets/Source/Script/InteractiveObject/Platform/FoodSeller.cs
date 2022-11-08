using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class FoodSeller : MonoBehaviour, IPlatform
{
    [SerializeField] private float _timeBetweenSell;

    [Inject] private Player _player;

    private bool _canSellFood = false;
    private WaitForSeconds _whaitNextSell;

    public event UnityAction PlayerEntered;
    public event UnityAction PlayerLeft;

    private void OnEnable()
    {
        _player.SellFood += OnSellFood;
        _whaitNextSell = new WaitForSeconds(_timeBetweenSell);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<PlatformActivator>(out PlatformActivator activator))
        {
            PlayerEntered?.Invoke();
            _canSellFood = true;
            StartCoroutine(FoodSelling(_player));
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<PlatformActivator>(out PlatformActivator activator))
        {
            PlayerLeft?.Invoke();
            _canSellFood = false;
        }
    }

    private void OnDisable()
    {
        _player.SellFood -= OnSellFood;
    }

    private IEnumerator FoodSelling(Player player)
    {
        while (_canSellFood)
        {
            if (player.TrySellFood() == false)
            {
                _canSellFood = false;
            }

            yield return _whaitNextSell;
        }
    }

    private void OnSellFood(Food food)
    {
        Destroy(food.gameObject);
    }
}
