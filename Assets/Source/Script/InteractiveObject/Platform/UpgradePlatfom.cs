using UnityEngine;
using UnityEngine.Events;

public class UpgradePlatfom : MonoBehaviour, IPlatform
{
    public event UnityAction PlayerEntered;
    public event UnityAction PlayerLeft;

    public void OnTriggerEnter(Collider collider)
    { 
        PlayerEntered?.Invoke();
    }

    public void OnTriggerExit(Collider collider)
    {
        PlayerLeft?.Invoke();
    }
}
