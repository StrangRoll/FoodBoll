using UnityEngine;
using Zenject;

public class PlayerInputRootInstaller : MonoInstaller
{
    [SerializeField] private PlayerInputRoot _inputRoot;

    public override void InstallBindings()
    {
        Container
            .Bind<PlayerInputRoot>()
            .FromInstance(_inputRoot)
            .AsSingle();
    }
}