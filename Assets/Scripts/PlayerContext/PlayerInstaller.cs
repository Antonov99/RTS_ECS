using Data;
using DefaultNamespace;
using DefaultNamespace.GameSystems;
using Money;
using PlayerContext.Upgrades;
using Sample;
using UnityEngine;
using Zenject;

namespace DI
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView moneyView;

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
            UpgradesInstaller.Install(Container,upgradesCatalog);
            
            BindConfigs();

            Container.Bind<MoneyStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().WithArguments(moneyView);
            Container.BindInterfacesAndSelfTo<MoneyFarmingSystem>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<UnitBuyer>().AsSingle();
            
            Container.Bind<UnitStats>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StatsInstaller>().AsSingle();
        }

        private void BindConfigs()
        {
            Container.Bind<UnitsCatalog>().FromInstance(unitsCatalog).AsSingle();
            Container.Bind<PriceCatalog>().FromInstance(priceCatalog).AsSingle();
            Container.Bind<StatsConfig>().FromInstance(statsConfig).AsSingle();
        }


    }
}