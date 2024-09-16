using System;
using System.Collections.Generic;
using Data;
using DefaultNamespace;
using Money;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Upgrades;
using Zenject;

namespace Sample
{
    public sealed class UpgradesManager : MonoBehaviour
    {
        public event Action<Upgrade> OnLevelUp;

        [ReadOnly, ShowInInspector]
        private Dictionary<UpgradeType, Upgrade> _upgrades = new();

        private MoneyStorage[] moneyStorages;

        private MoneyStorage playerMoneyStorage;
        
        private MoneyStorage enemyMoneyStorage;

        private UnitsUpgradePresenter _upgradePresenter;

        [FormerlySerializedAs("configs")]
        [SerializeField]
        private UpgradeCatalog upgradeConfigs;

        [SerializeField]
        private StatsConfig statsConfig;

        [FormerlySerializedAs("_stats")]
        [SerializeField]
        private UnitStats stats;

        private void Awake()
        {
            var configs = upgradeConfigs.GetAllUpgrades();
            var upgrades = new Upgrade[configs.Length];
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i]=configs[i].InstantiateUpgrade(stats);
            }
            SetupUpgrades(upgrades);
            SetupStats();
        }

        private void SetupStats()
        {
            foreach (var stat in statsConfig.Stats)
            {
                AddStat(stat.Key,stat.Value);
            }
        }

        [Inject]
        public void Construct(MoneyStorage[] storages, UnitStats unitStats, UnitsUpgradePresenter upgradePresenter)
        {
            moneyStorages = storages;
            stats = unitStats;

            foreach (var storage in moneyStorages)
            {
                if (storage.team == TeamData.BLUE)
                    playerMoneyStorage = storage;
                else
                    enemyMoneyStorage = storage;
            }

            _upgradePresenter = upgradePresenter;
            _upgradePresenter.OnUpgradeUnit += LevelUp;
        }

        [Button]
        public void AddStat(StatsData statName, int value)
        {
            stats.AddStat(statName, value);
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

        private bool CanLevelUp(Upgrade upgrade, TeamData team)
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
            
            if (team == TeamData.BLUE)
                return playerMoneyStorage.CanSpendMoney(price);
            else
                return enemyMoneyStorage.CanSpendMoney(price);
        }

        private void LevelUp(Upgrade upgrade, TeamData team)
        {
            if (!CanLevelUp(upgrade, team))
            {
                throw new Exception($"Can not level up {upgrade.id}");
            }

            var price = upgrade.nextPrice;
            
            if(team==TeamData.BLUE)
                playerMoneyStorage.SpendMoney(price);
            else
                enemyMoneyStorage.SpendMoney(price);

            upgrade.LevelUp();
            OnLevelUp?.Invoke(upgrade);
        }

        [Title("Methods")]
        [Button]
        public bool CanLevelUp(UpgradeType id, TeamData team)
        {
            var upgrade = _upgrades[id];
            return CanLevelUp(upgrade, team);
        }

        [Button]
        public void LevelUp(UpgradeType id, TeamData team)
        {
            var upgrade = _upgrades[id];
            LevelUp(upgrade, team);
        }

        private void OnDestroy()
        {
            _upgradePresenter.OnUpgradeUnit -= LevelUp;
        }
    }
}