using DefaultNamespace;
using DefaultNamespace.GameSystems;
using Leopotam.EcsLite.Entities;
using Money;
using Units;
using UnityEngine;
using Upgrades;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private UnitsCatalogView catalogView;

    [SerializeField]
    private UnitsUpgradeView upgradeView;
    
    [SerializeField]
    private TeamData enemyTeam;
    
    [SerializeField]
    private TeamData myTeam;
    
    [SerializeField]
    private Transform parent;
    
    public override void InstallBindings()
    {
        Container.Bind<EntityManager>().AsSingle().NonLazy();
        
        Container.Bind<MoneyStorage>().AsCached().WithArguments(enemyTeam).NonLazy();
        Container.Bind<MoneyStorage>().AsCached().WithArguments(myTeam).NonLazy();
        
        Container.Bind<UnitStats>().AsSingle().NonLazy();
        
        Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<UnitsCatalogPresenter>().AsSingle().WithArguments(catalogView).NonLazy();
        Container.BindInterfacesAndSelfTo<UnitsUpgradePresenter>().AsSingle().WithArguments(upgradeView).NonLazy();

        Container.BindInterfacesAndSelfTo<MoneyFarmingSystem>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EcsStatsController>().AsSingle().NonLazy();
        Container.Bind<UnitsSpawner>().AsSingle().WithArguments(parent).NonLazy();

    }
}