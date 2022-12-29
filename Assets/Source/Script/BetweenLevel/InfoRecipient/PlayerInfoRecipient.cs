using UnityEngine;
using Zenject;

public class PlayerInfoRecipient : MonoBehaviour
{
    [Inject] private PlayerData _playerData;

    private PlayerInformation _information = null;
    private int _capacity;

    private void Start()
    {

        if (_information == null)
            return;

        _playerData.IncreaseCapacity(_information.Capacity - _playerData.Capacity);
        _playerData.IncreaseSpeed(_information.Speed - _playerData.Speed);
        Debug.Log(_playerData.Speed);
        _playerData.IncreaseSize(_information.Size - _playerData.Size);
        Debug.Log(_playerData.Size);
        _information = null;
    }

    public void GetInfo(PlayerInformation playerInfo)
    {
        _information = playerInfo;
    }
}
