using UnityEngine;
using Zenject;

public class PlayerInfoCollecter : MonoBehaviour
{
    [Inject] private PlayerData _playerData;

    public PlayerInformation CollectPlayerInfo()
    {
        return new PlayerInformation(_playerData.Size, _playerData.Speed, _playerData.Capacity);
    }
}
