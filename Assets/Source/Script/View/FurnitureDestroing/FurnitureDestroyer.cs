using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDestroyer : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _selfParts;
    [SerializeField] private Collider[] _selfPartColliders;
    [SerializeField] private Rigidbody[] _meals;

    private void Start()
    {
        foreach (var part in _selfParts)
        {
            part.Sleep();
        }

        foreach (var meal in _meals)
        {
            meal.Sleep();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier sphereMovier))
        {
            foreach (var part in _selfParts)
            {
                part.WakeUp();
            }

            foreach (var meal in _meals)
            {
                meal.WakeUp();
            }

            StartCoroutine(ToTrigger());
        }
    }

    private IEnumerator ToTrigger()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();

        foreach (var collider in _selfPartColliders)
        {
            collider.isTrigger = true;
        }
    }
}
