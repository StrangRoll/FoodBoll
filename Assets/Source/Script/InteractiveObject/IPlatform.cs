using UnityEngine;
using UnityEngine.Events;

public interface IPlatform
{
    public event UnityAction PlayerEntered;
    public event UnityAction PlayerLeft;

    public void OnTriggerEnter(Collider collider);
    public void OnTriggerExit(Collider collider);
}
