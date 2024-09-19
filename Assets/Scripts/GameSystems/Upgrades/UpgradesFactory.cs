using DefaultNamespace;
using JetBrains.Annotations;
using Sample;

namespace DI
{
    [UsedImplicitly]
    public class UpgradesFactory
    {
        private readonly UpgradeCatalog _upgradeConfigs;

        private readonly UnitStats _stats;

        public UpgradesFactory(UpgradeCatalog upgradeConfigs, UnitStats stats)
        {
            _upgradeConfigs = upgradeConfigs;
            _stats = stats;
        }

        public Upgrade[] InstantiateUpgrades()
        {
            var configs = _upgradeConfigs.GetAllUpgrades();
            var upgrades = new Upgrade[configs.Length];
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i] = configs[i].InstantiateUpgrade(_stats);
            }

            return upgrades;
        }
    }
}