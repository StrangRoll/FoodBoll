using UnityEngine;
using UnityEngine.Events;

public class ExitController : MonoBehaviour
{
    public event UnityAction SphereEntered;
    public event UnityAction SphereExited;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier sphere))
            SphereEntered?.Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier sphere))
            SphereExited?.Invoke();
    }
}
