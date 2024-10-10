using JetBrains.Annotations;
using Sample;
using Zenject;

namespace PlayerContext.Upgrades
{
    [UsedImplicitly]
    public class UpgradesInstaller:Installer<UpgradeCatalog,UpgradesInstaller>
    {
        [Inject]
        private UpgradeCatalog _upgradeCatalog;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UpgradesManager>().AsSingle();
            Container.Bind<Upgrade>().FromMethodMultiple(InstantiateUpgrades).AsSingle();
            
            Container.Bind<UpgradeCatalog>().FromInstance(_upgradeCatalog).AsSingle();
        }
        
        private Upgrade[] InstantiateUpgrades(InjectContext context)
        {
            var configs = _upgradeCatalog.GetAllUpgrades();
            var upgrades = new Upgrade[configs.Length];
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i] = configs[i].InstantiateUpgrade(context.Container);
            }

            return upgrades;
        }
    }
}