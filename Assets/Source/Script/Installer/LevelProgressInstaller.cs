using UnityEngine;
using Zenject;

public class LevelProgressInstaller : MonoInstaller
{
    [SerializeField] private LevelProgress _progress;
    public override void InstallBindings()
    {
        Container
            .Bind<LevelProgress>()
            .FromInstance(_progress);
    }
}