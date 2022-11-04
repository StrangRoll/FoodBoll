using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Food))]
public class FoodPickUpper : InteractiveObject
{
    private Food _food;

    private void Start()
    { 
        _food = GetComponent<Food>();
    }

    protected override void OnPlayerEnter(Player player)
    {
        if (player.TryPickUp(_food))
        {
            ChangeParent(player.transform);
        }
    }

    private void ChangeParent(Transform parent)
    {
        transform.SetParent(parent, true);
    }
}
