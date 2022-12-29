using NTC.Global.Pool;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour, IPoolItem
{
    [SerializeField] private float _price;

    private Collider _collider;
    private Vector3 _normalSize;
    private Quaternion _normalRotation;
    private float _normalY;
    private int _jumpCount = 1;

    public Food Prefab { get; private set; }
    public float Price { get; private set; }

    private void Awake()
    {
        Price = _price;
        _collider = GetComponent<Collider>();

        if (_normalSize == Vector3.zero)
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

    public void Init(Vector3 foodPosition, float jumpPower, float jumpDuration, Vector3 startScale, Food prefab)
    {
        Prefab = prefab;
        transform.DOJump(foodPosition, jumpPower, _jumpCount, jumpDuration);
        transform.localScale = startScale;
        transform.DOScale(_normalSize, jumpDuration).OnComplete(OnAnimationEnded);
    }

    public void OnDespawn()
    {
        transform.localRotation = _normalRotation;
        transform.position = Vector3.up * _normalY;
        transform.localScale = _normalSize;
    }

    public void OnSpawn()
    {
        _collider.enabled = false;
    }

    private void OnAnimationEnded()
    {
        _normalSize = transform.localScale;
        _normalRotation = transform.localRotation;
        _normalY = transform.position.y;
        _collider.enabled = true;
    }
}
