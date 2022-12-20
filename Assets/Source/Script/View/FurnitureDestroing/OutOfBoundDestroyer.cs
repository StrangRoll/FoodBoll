using NTC.Global.Pool;
using UnityEngine;

public class OutOfBoundDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SetActive(false);
    }
}
