using IJunior.TypedScenes;
using UnityEngine;
using Zenject;

public class InfoTransfer : MonoBehaviour, ISceneLoadHandler<InformationToSend>
{
    [SerializeField] private FoodInfoRecipient _foodInfoRecipient;

    [Inject] private PauseManager _pause;

    public void OnSceneLoaded(InformationToSend argument)
    {
        _foodInfoRecipient.GetInfo(argument.FoodInfo);

        _pause.OnPause(false);
    }
}
