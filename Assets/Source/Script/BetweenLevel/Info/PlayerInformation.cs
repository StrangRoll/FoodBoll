using UnityEngine;

public class PlayerInformation 
{
    public float Size { get; private set; }
    public float Speed { get; private set; }
    public int Capacity { get; private set; }

    public PlayerInformation(float size, float speed, int capacity)
    {
        Size = size;
        Speed = speed;
        Capacity = capacity;
    }
}
