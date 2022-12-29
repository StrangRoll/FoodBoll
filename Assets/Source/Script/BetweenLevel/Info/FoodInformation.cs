using UnityEngine;

public class FoodInformation 
{
    public Food Prefab { get; private set; }
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }
    public Vector3 Scale { get; private set; }

    public FoodInformation(Food food, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Prefab = food;
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }
}
