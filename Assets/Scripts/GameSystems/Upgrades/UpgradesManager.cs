using System;
using System.Collections.Generic;
using Data;
using DI;
using Money;
using Sirenix.OdinInspector;
using Zenject;

namespace Sample
{
    public sealed class UpgradesManager
    {
        public event Action<Upgrade> OnLevelUp;

        private Dictionary<UpgradeType, Upgrade> _upgrades = new();

        private readonly MoneyStorage _moneyStorage;

        public UpgradesManager(MoneyStorage storage, UpgradesFactory upgradesFactory)
        {
            _moneyStorage = storage;
            
            SetupUpgrades(upgradesFactory.InstantiateUpgrades());
        }

        private void SetupUpgrades(Upgrade[] upgrades)
        {
            _upgrades = new Dictionary<UpgradeType, Upgrade>();
            for (int i = 0, count = upgrades.Length; i < count; i++)
            {
                var upgrade = upgrades[i];
                _upgrades[upgrade.id] = upgrade;
            }
        }

        private Upgrade GetUpgrade(UpgradeType id)
        {
            return _upgrades[id];
        }

        private bool CanLevelUp(Upgrade upgrade)
        {
            if (upgrade.isMaxLevel)
            {
                return false;
            }

            var dependencies = upgrade.dependencies;
            foreach (var dependency in dependencies)
            {
                if (GetUpgrade(dependency).level <= upgrade.level)
                    return false;
            }

            var price = upgrade.nextPrice;

            return _moneyStorage.CanSpendMoney(price);
        }

        private void LevelUp(Upgrade upgrade)
        {
            if (!CanLevelUp(upgrade))
            {
                throw new Exception($"Can not level up {upgrade.id}");
            }

            var price = upgrade.nextPrice;

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