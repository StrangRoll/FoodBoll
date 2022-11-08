using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _requiredSize;
    [SerializeField] private float _price;

    public float RequiredSize { get; private set; }
    public float Price { get; private set; }

    private void Awake()
    {
        RequiredSize = _requiredSize;
        Price = _price;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<FoodPickuper>(out FoodPickuper component))
        {
            component.Pickup(this);
        }
    }
}
