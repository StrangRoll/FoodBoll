using UnityEngine;

public abstract class Platform : InteractiveObject
{
    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            OnPlayerExit();
        }
    }

    protected abstract void OnPlayerExit();
}
