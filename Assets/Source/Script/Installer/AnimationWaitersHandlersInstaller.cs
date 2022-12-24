using UnityEngine;
using Zenject;

public class AnimationWaitersHandlersInstaller : MonoInstaller
{
    [SerializeField] private StartAnimationHandler _startAnimationHandler;

    public override void InstallBindings()
    {
        Container
            .Bind<StartAnimationHandler>()
            .FromInstance(_startAnimationHandler)
            .AsSingle();
    }
}