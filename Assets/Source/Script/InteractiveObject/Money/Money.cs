using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour, IPoolItem
{
    public event UnityAction MoneyRemoved;

    private Vector3 _startScale;

    private void Awake()
    {
        _startScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<MoneyPickuper>(out MoneyPickuper component))
        {
            component.Pickup(this);
        }
    }

    public void DestroyMoney()
    {
        MoneyRemoved?.Invoke();
        NightPool.Despawn(this);
    }

    public void OnSpawn()
    {
        transform.localScale = _startScale;
    }

    public void OnDespawn() { }
}
