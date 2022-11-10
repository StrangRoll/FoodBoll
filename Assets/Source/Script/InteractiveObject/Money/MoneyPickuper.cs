using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class MoneyPickuper : MonoBehaviour
{
    [SerializeField] private float _pickupDuration;

    public event UnityAction MoneyPickedUp;

    public void Pickup(Money money)
    {
        money.transform.DOMove(transform.position, _pickupDuration).OnComplete(() => OnPickupComplete(money));
    }

    private void OnPickupComplete(Money money)
    {
        MoneyPickedUp?.Invoke();
        Destroy(money.gameObject);
    }
}
