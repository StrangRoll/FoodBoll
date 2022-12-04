using UnityEngine;
using Zenject;

public class PauseManagerInstaller : MonoInstaller
{
    [SerializeField] private PauseManager _pauseManager;

    public override void InstallBindings()
    {
        Container
            .Bind<PauseManager>()
            .FromInstance(_pauseManager)
            .AsSingle();
    }
}