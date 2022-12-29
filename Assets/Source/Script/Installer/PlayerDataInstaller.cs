using UnityEngine;
using Zenject;

public class PlayerDataInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _data;

    public override void InstallBindings()
    {
        Container
            .Bind<PlayerData>()
            .FromInstance(_data)
            .AsSingle();    
    }
}