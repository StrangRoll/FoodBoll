using UnityEngine;
using Zenject;

public abstract class LevelChanger : MonoBehaviour, IExitAnimationWaiter
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

    protected abstract void LoadLevel(InformationToSend information);

    private void CollectInfo()
    {
        var foodInformation = _foodInfoCollecter.CollectFoodInfod();
        var playerInfo = _playerInfoCollecter.CollectPlayerInfo();
        var info = new InformationToSend(foodInformation, playerInfo);
        LoadLevel(info);
    }
}
