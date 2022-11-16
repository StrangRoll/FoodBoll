using UnityEngine;
using Zenject;

public class MoneyPickuperInstaller : MonoInstaller
{
    [SerializeField] private MoneyPickuper _pickuper;

    public override void InstallBindings()
    {
        Container
            .Bind<MoneyPickuper>()
            .FromInstance(_pickuper)
            .AsSingle();
    }
}