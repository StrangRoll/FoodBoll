using UnityEngine;
using Zenject;

public class VideoAddInstaller : MonoInstaller
{
    [SerializeField] private VideoAdd _video;

    public override void InstallBindings()
    {
        Container
            .Bind<VideoAdd>()
            .FromInstance(_video)
            .AsSingle();
    }
}