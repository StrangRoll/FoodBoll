using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerData : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;

    private Transform _sphereTransform;

    public event UnityAction<float> SizeIncreased;

    public float Speed { get; private set; } = 1.6f;
    public int Capacity { get; private set; } = 100;
    public float Size { get; private set; } = 1.6f;

    private void Awake()
    {
        _sphereTransform = _sphere.transform;
    }

    public void IncreaseSpeed (float deltaSpeed)
    {
        Speed += deltaSpeed;
    }

    public void IncreaseCapacity(int deltaCapacity)
    {
        Capacity += deltaCapacity;
    }

    public void IncreaseSize(float deltaSize)
    {
        _sphereTransform.localScale += new Vector3(deltaSize, deltaSize, deltaSize);
        SizeIncreased?.Invoke(deltaSize);
    }
}
