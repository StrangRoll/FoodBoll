using UnityEngine;
using UnityEngine.Events;

public class MoneyPickupPlatform : MonoBehaviour, IPlatform
{
    public event UnityAction PlayerEntered;
    public event UnityAction PlayerLeft;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<PlatformActivator>(out PlatformActivator activator))
            PlayerEntered?.Invoke();
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<PlatformActivator>(out PlatformActivator activator))
            PlayerLeft?.Invoke();
    }
}
