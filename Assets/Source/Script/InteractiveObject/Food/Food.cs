using UnityEngine;


[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour
{
    [SerializeField] private float _requiredSize;
    [SerializeField] private float _price;

    private Collider _collider;

    public float RequiredSize { get; private set; }
    public float Price { get; private set; }

    private void Awake()
    {
        RequiredSize = _requiredSize;
        Price = _price;
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<FoodPickuper>(out FoodPickuper component))
        {
            component.Pickup(this);
            _collider.enabled = false;

        }
    }
}
