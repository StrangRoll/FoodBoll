using UnityEngine;
using Zenject;

public class UpgradeButtonsInstaller : MonoInstaller
{
    [SerializeField] private SpeedUpgradeButton _speedButton;
    [SerializeField] private SizeUpgradeButton  _sizeButton;
    [SerializeField] private CapacityUpgradeButton _capacityButton;

    public override void InstallBindings()
    {
        Container
            .Bind<SpeedUpgradeButton>()
            .FromInstance(_speedButton)
            .AsSingle();

        Container
            .Bind<SizeUpgradeButton>()
            .FromInstance(_sizeButton)
             .AsSingle();

        Container
             .Bind<CapacityUpgradeButton>()
             .FromInstance(_capacityButton)
             .AsSingle();
    }
}