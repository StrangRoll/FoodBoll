using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour, IPlatform
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
