using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Money;
using Sirenix.OdinInspector;

namespace Sample
{
    public sealed class UpgradesManager
    {
        public event Action<Upgrade> OnLevelUp;

        private readonly Dictionary<UpgradeType, Upgrade> _upgrades;

        private readonly MoneyStorage _moneyStorage;

        public UpgradesManager(MoneyStorage storage, IEnumerable<Upgrade> upgrades)
        {
            _moneyStorage = storage ?? throw new ArgumentNullException(nameof(storage));
            
            _upgrades = upgrades?.ToDictionary(it=>it.ID) ?? throw new ArgumentNullException(nameof(upgrades));
        }

        private Upgrade GetUpgrade(UpgradeType id)
        {
            return _upgrades[id];
        }

        private bool CanLevelUp(Upgrade upgrade)
        {
            if (upgrade.IsMaxLevel)
            {
                return false;
            }

            var dependencies = upgrade.Dependencies;
            if (dependencies != null) 
                foreach (var dependency in dependencies)
                {
                    if (GetUpgrade(dependency).Level <= upgrade.Level)
                        return false;
                }

            var price = upgrade.NextPrice;

            return _moneyStorage.CanSpendMoney(price);
        }

        private void LevelUp(Upgrade upgrade)
        {
            if (!CanLevelUp(upgrade))
            {
                throw new Exception($"Can not level up {upgrade.ID}");
            }

            var price = upgrade.NextPrice;

            _moneyStorage.SpendMoney(price);

            upgrade.LevelUp();
            OnLevelUp?.Invoke(upgrade);
        }

        [Title("Methods")]
        [Button]
        public bool CanLevelUp(UpgradeType id)
        {
            var upgrade = _upgrades[id];
            return CanLevelUp(upgrade);
        }

        [Button]
        public void LevelUp(UpgradeType id)
        {
            var upgrade = _upgrades[id];
            LevelUp(upgrade);
        }
    }
}