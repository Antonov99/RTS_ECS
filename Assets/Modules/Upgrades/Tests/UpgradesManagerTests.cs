using System;
using Data;
using DefaultNamespace;
using Money;
using NUnit.Framework;
using Sample;

namespace Modules.Upgrades.Tests
{
    public class UpgradesManagerTests
    {
        private MoneyStorage _moneyStorage;
        private Action<int> _levelUp;

        [Test]
        public void Instantiate()
        {
            //Arrange:
            _moneyStorage = new MoneyStorage();
            _moneyStorage.SetupMoney(5);

            var priceTable = new PriceTable();
            priceTable.OnValidate(2);
        
            var upgrades = new Upgrade[]
            {
                new UpgradeMock(priceTable,2,UpgradeType.POWER_UPGRADE),
                new UpgradeMock(priceTable,2,UpgradeType.HEALTH_UPGRADE),
                new UpgradeMock(priceTable,2,UpgradeType.SPEED_UPGRADE)
            };

            var upgradesManager = new UpgradesManager(_moneyStorage, upgrades);
            upgradesManager.LevelUp(UpgradeType.HEALTH_UPGRADE);
            
            //Assert
            Assert.IsTrue(upgradesManager.CanLevelUp(UpgradeType.POWER_UPGRADE));
            Assert.IsFalse(upgradesManager.CanLevelUp(UpgradeType.HEALTH_UPGRADE));
        }
    }
}