using Leopotam.EcsLite.Entities;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EntityManager>().AsSingle().NonLazy();
    }
}