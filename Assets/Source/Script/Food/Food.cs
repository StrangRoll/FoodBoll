using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour
{
    private void Awake()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            ChangeParent(player.transform);
        }
    }

    private void ChangeParent(Transform parent)
    {
        transform.SetParent(parent, true);
    }
}
