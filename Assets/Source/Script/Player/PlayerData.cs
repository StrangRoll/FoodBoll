using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerData : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;

    private Transform _sphereTransform;
    private float _startSize = 1.6f;

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
        Size += deltaSize;
        _sphereTransform.localScale = new Vector3(Size, Size, Size);
        SizeIncreased?.Invoke(deltaSize);
    }
}
