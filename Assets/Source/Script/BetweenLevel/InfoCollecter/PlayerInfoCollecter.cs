using UnityEngine;

public class PlayerInfoCollecter : MonoBehaviour
{
    public PlayerInformation CollectPlayerInfo()
    {
        return new PlayerInformation(new Vector3(2, 2, 2), 2, 100);
    }
}
