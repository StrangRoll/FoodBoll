using UnityEngine;
using Zenject;

public class MoneyCreatorInstaller : MonoInstaller
{
    [SerializeField] private MoneyCreator _moneyCreator;

    public override void InstallBindings()
    {
        Container
            .Bind<MoneyCreator>()
            .FromInstance(_moneyCreator)
            .AsSingle();
    }
}