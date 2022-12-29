using IJunior.TypedScenes;
using UnityEngine;
using Zenject;

public class ToHubReturner : MonoBehaviour, IExitAnimationWaiter
{
    [SerializeField] private FoodInfoCollecter _foodInfoCollecter;
    [SerializeField] private PlayerInfoCollecter _playerInfoCollecter;

    [Inject] private ExitAnimationHandler _exitAnimation;

    private void OnEnable()
    {
        _exitAnimation.Register(this);
    }

    private void OnDisable()
    {
        _exitAnimation.UnRegister(this);
    }

    public void OnExitAnimation(bool _isGoing)
    {
       if (_isGoing == false)
        {   
            CollectInfo();
        }
    }

    private void CollectInfo()
    {
        var foodInformation = _foodInfoCollecter.CollectFoodInfod();
        var playerInfo = _playerInfoCollecter.CollectPlayerInfo();
        var info = new InformationToSend(foodInformation, playerInfo);
        LoadHub(info);
    }

    private void LoadHub(InformationToSend info)
    {
        Hub.Load(info);
    }
}
