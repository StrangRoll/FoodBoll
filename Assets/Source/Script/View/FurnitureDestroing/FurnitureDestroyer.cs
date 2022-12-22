using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FurnitureDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private Rigidbody[] _selfParts;
    [SerializeField] private Collider[] _selfPartColliders;
    [SerializeField] private Rigidbody _meal;
    [SerializeField] private bool _isFalling;
    [SerializeField] private Collider[] _selfColliders;

    public event UnityAction FurnitureDestroyed;

    private void Awake()
    {
        foreach (var part in _selfParts)
        {
            part.isKinematic = true;
        }

        if (_meal != null)
            _meal.isKinematic = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SphereMovier>(out SphereMovier sphereMovier))
        {
            foreach (var part in _selfParts)
            {
                part.isKinematic = false;
            }

            foreach (var selfCollider in _selfColliders)
            {
                selfCollider.enabled = false;
            }

            _view.SetActive(false);

            if (_meal != null)
            {
                _meal.isKinematic = false;
                FurnitureDestroyed?.Invoke();
            }

            if (_isFalling)
            {
                StartCoroutine(ToTrigger());
            }
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
