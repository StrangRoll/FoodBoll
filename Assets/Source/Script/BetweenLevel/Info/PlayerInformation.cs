using UnityEngine;

public class PlayerInformation 
{
    public Vector3 Size { get; private set; }
    public float Speed { get; private set; }
    public int Capacity { get; private set; }

    public PlayerInformation(Vector3 size, float speed, int capacity)
    {
        Size = size;
        Speed = speed;
        Capacity = capacity;
    }
}
