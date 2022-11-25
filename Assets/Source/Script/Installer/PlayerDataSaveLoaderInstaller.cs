using UnityEngine;
using Zenject;

public class PlayerDataSaveLoaderInstaller : MonoInstaller
{
    [SerializeField] private PlayerDataLoader _saveLoader;

    public override void InstallBindings()
    {
        Container
            .Bind<PlayerDataLoader>()
            .FromInstance(_saveLoader)
            .AsSingle();
    }
}