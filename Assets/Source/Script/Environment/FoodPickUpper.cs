using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Food))]
public class FoodPickUpper : MonoBehaviour
{
    private Food _food;

    private void Awake()
    {
        _food = GetComponent<Food>();
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            if (player.TryPickUp(_food))
            {
                ChangeParent(player.transform);
            }
        }
    }

    private void ChangeParent(Transform parent)
    {
        transform.SetParent(parent, true);
    }
}
