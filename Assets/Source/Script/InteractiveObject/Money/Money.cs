using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour
{
    public event UnityAction MoneyRemoved;

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
        gameObject.SetActive(false);
    }
}
