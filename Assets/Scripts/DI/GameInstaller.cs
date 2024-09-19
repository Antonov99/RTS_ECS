using EcsEngine;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private Transform parent;

    public override void InstallBindings()
    {
        Container.Bind<EntityManager>().AsSingle().NonLazy();
        
        BindSystems();
    }

    private void BindSystems()
    {
        Container.Bind<UnitsSpawner>().AsSingle().WithArguments(parent).NonLazy();
        Container.Bind<EcsSystemsInstaller>().AsSingle();
    }
}