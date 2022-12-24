using UnityEngine;
using UnityEngine.Events;

public class ExitController : MonoBehaviour
{
    public event UnityAction SphereEntred;
    public event UnityAction SphereExited;

    private void OnTriggerEnter(Collider collider)
    {
        SphereEntred?.Invoke();
    }
    private void OnTriggerExit(Collider collider)
    {
        SphereExited?.Invoke();
    }
}
