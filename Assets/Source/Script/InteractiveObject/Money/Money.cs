using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour, IPoolItem
{
    private MoneyPickuper _player;

    public event UnityAction MoneyRemoved;

    private Vector3 _startScale;

    private void Awake()
    {
        _startScale = transform.localScale;
    }

    public void Init(MoneyPickuper pickuper)
    {
        _player = pickuper;
    }

    public void Pickup()
    {
        _player.Pickup(this);
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
