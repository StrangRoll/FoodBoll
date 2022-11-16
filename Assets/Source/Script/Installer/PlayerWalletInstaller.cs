using UnityEngine;
using Zenject;

public class PlayerWalletInstaller : MonoInstaller
{
    [SerializeField] private PlayerWallet _wallet;

    public override void InstallBindings()
    {
        Container
            .Bind<PlayerWallet>()
            .FromInstance(_wallet)
            .AsSingle();
    }
}