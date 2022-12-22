using NTC.Global.Pool;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour, IPoolItem
{
    [SerializeField] private float _price;
    [SerializeField] private float _requiredSpace;

    private Collider _collider;
    private Vector3 _normalSize;
    private int _jumpCount = 1;

    public float RequiredSpace
    {
        get { return _requiredSpace; }
    }
    public float Price { get; private set; }

    private void Awake()
    {
        Price = _price;
        _collider = GetComponent<Collider>();
        _normalSize = transform.localScale;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<FoodPickuper>(out FoodPickuper component))
        {
            if (component.TryPickup(this))
                _collider.enabled = false;
        }
    }   

    public void Init(Vector3 foodPosition, float jumpPower, float jumpDuration, Vector3 startScale)
    {
        transform.DOJump(foodPosition, jumpPower, _jumpCount, jumpDuration);
        transform.localScale = startScale;
        transform.DOScale(_normalSize, jumpDuration).OnComplete(OnAnimationEnded);
    }

    public void OnDespawn() { return; }

    public void OnSpawn()
    {
        _collider.enabled = false;
    }

    private void OnAnimationEnded()
    {
        _collider.enabled = true;
    }
}
