using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class InteractiveObject : MonoBehaviour
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
            OnPlayerEnter(player);
        }
    }

    protected abstract void OnPlayerEnter(Player player);
}
