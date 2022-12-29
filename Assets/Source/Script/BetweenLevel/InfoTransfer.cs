using IJunior.TypedScenes;
using UnityEngine;
using Zenject;

public class InfoTransfer : MonoBehaviour, ISceneLoadHandler<InformationToSend>
{
    [SerializeField] private FoodInfoRecipient _foodInfoRecipient;
    [SerializeField] private PlayerInfoRecipient _playerInfoRecipient;

    [Inject] private PauseManager _pause;

    private void Start()
    {
        _pause.OnPause(false);
    }

    public void OnSceneLoaded(InformationToSend argument)
    {
        _foodInfoRecipient.GetInfo(argument.FoodInfo);
        _playerInfoRecipient.GetInfo(argument.PlayerInfo);
    }
}
