using Data;
using DefaultNamespace;
using DefaultNamespace.GameSystems;
using Money;
using Sample;
using UnityEngine;
using Zenject;

namespace DI
{
    public class EnemyInstaller:MonoInstaller
    {
        [SerializeField]
        private MoneyView view;
        
        [SerializeField]
        private UnitsCatalog unitsCatalog;
        
        [SerializeField]
        private PriceCatalog priceCatalog;

        [SerializeField]
        private StatsConfig statsConfig;

        [SerializeField]
        private UpgradeCatalog upgradesCatalog;
        
        public override void InstallBindings()
        {
            BindConfigs();
            
            Container.Bind<MoneyStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().WithArguments(view);
            Container.BindInterfacesAndSelfTo<MoneyFarmingSystem>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<UpgradesManager>().AsSingle();
            Container.Bind<UpgradesFactory>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<UnitBuyer>().AsSingle();
            
            Container.Bind<UnitStats>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StatsInstaller>().AsSingle();
        }

        private void BindConfigs()
        {
            Container.Bind<UnitsCatalog>().FromInstance(unitsCatalog).AsSingle();
            Container.Bind<PriceCatalog>().FromInstance(priceCatalog).AsSingle();
            Container.Bind<StatsConfig>().FromInstance(statsConfig).AsSingle();
            Container.Bind<UpgradeCatalog>().FromInstance(upgradesCatalog).AsSingle();
        }
    }
}