using UnityEngine;


[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour
{
    [SerializeField] private float _price;
    [SerializeField] private float _requiredSpace;

    private Collider _collider;

    public float RequiredSpace
    {
        get { return _requiredSpace; }
    }
    public float Price { get; private set; }

    private void Awake()
    {
        Price = _price;
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<FoodPickuper>(out FoodPickuper component))
        {
            if (component.TryPickup(this))
                _collider.enabled = false;
        }
    }
}
