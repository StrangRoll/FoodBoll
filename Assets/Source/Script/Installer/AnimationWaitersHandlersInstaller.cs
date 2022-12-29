using UnityEngine;
using Zenject;

public class AnimationWaitersHandlersInstaller : MonoInstaller
{
    [SerializeField] private StartAnimationHandler _startAnimationHandler;
    [SerializeField] private ExitAnimationHandler _exitAnimationHandler;

    public override void InstallBindings()
    {
        Container
            .Bind<StartAnimationHandler>()
            .FromInstance(_startAnimationHandler)
            .AsSingle();        
        
        Container
            .Bind<ExitAnimationHandler>()
            .FromInstance(_exitAnimationHandler)
            .AsSingle();
    }
}