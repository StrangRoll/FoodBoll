using UnityEngine;
using Zenject;

public class SphereMovierInstaller : MonoInstaller
{
    [SerializeField] private SphereMovier _sphere; 
    public override void InstallBindings()
    {
        Container
            .Bind<SphereMovier>()
            .FromInstance(_sphere)
            .AsSingle();
    }
}