using DefaultNamespace;
using Units;
using UnityEngine;
using Upgrades;
using Zenject;

namespace DI
{
    public class UIInstaller:MonoInstaller
    {
        [SerializeField]
        private UnitsCatalogView catalogView;

        [SerializeField]
        private UnitsUpgradeView upgradeView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UnitsCatalogPresenter>().AsSingle().WithArguments(catalogView).NonLazy();
            Container.BindInterfacesAndSelfTo<UnitsUpgradePresenter>().AsSingle().WithArguments(upgradeView).NonLazy();
        }
    }
}