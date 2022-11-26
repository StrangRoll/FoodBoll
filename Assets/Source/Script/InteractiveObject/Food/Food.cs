using NTC.Global.Pool;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour, IPoolItem
{
    [SerializeField] private float _price;
    [SerializeField] private float _requiredSpace;

    private Collider _collider;
    private Vector3 _startSize;

    public float RequiredSpace
    {
        get { return _requiredSpace; }
    }
    public float Price { get; private set; }

    private void Awake()
    {
        Price = _price;
        _collider = GetComponent<Collider>();
        _startSize = transform.localScale;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<FoodPickuper>(out FoodPickuper component))
        {
            if (component.TryPickup(this))
                _collider.enabled = false;
        }
    }   

    public void OnDespawn() { return; }

    public void OnSpawn()
    {
        _collider.enabled = true;
        transform.localScale = _startSize;

    }
}
