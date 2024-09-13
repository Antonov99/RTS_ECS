using DefaultNamespace;
using DefaultNamespace.GameSystems;
using Leopotam.EcsLite.Entities;
using Money;
using Units;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private UnitsCatalogView catalogView;

    [SerializeField]
    private TeamData enemyTeam;
    
    [SerializeField]
    private TeamData myTeam;
    
    public override void InstallBindings()
    {
        Container.Bind<EntityManager>().AsSingle().NonLazy();
        
        Container.Bind<MoneyStorage>().AsCached().WithArguments(enemyTeam).NonLazy();
        Container.Bind<MoneyStorage>().AsCached().WithArguments(myTeam).NonLazy();
        
        Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<UnitsCatalogPresenter>().AsSingle().WithArguments(catalogView).NonLazy();

        Container.BindInterfacesAndSelfTo<MoneyFarmingSystem>().AsSingle().NonLazy();
    }
}