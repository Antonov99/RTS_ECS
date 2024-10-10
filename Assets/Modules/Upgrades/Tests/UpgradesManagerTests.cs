using Money;
using NUnit.Framework;
using Sample;
using UnityEngine;

namespace Modules.Upgrades.Tests
{
    public class UpgradesManagerTests
    {
        private MoneyStorage _moneyStorage;
        
        [Test]
        public void Instantiate()
        {
           //Arrange:
           _moneyStorage = new MoneyStorage();
          
           /*var upgrades = new Upgrade[]
           {
               new Upgrade()
           };
           
           
           var upgradesManager = new UpgradesManager(_moneyStorage, upgrades );
            
            Assert.IsTrue(success);*/
        }
    }
}