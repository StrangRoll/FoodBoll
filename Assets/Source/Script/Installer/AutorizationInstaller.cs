using UnityEngine;
using Zenject;

public class AutorizationInstaller : MonoInstaller
{
    [SerializeField] private Autorization _autorization;

    public override void InstallBindings()
    {
        Container
            .Bind<Autorization>()
            .FromInstance(_autorization)
            .AsSingle();
    }
}