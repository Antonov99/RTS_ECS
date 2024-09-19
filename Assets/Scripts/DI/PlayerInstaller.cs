using Data;
using DefaultNamespace;
using DefaultNamespace.GameSystems;
using Money;
using Sample;
using Units;
using UnityEngine;
using Upgrades;
using Zenject;

namespace DI
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView view;

        [SerializeField]
        private UnitsCatalogView catalogView;

        [SerializeField]
        private UnitsUpgradeView upgradeView;

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
            Container.BindInterfacesAndSelfTo<UnitsUpgradePresenter>().AsSingle().WithArguments(upgradeView).NonLazy();
            Container.Bind<UpgradesFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<UnitBuyer>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnitsCatalogPresenter>().AsSingle().WithArguments(catalogView).NonLazy();
            
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