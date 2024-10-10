using NUnit.Framework;

namespace Modules.MoneyStorage.Tests
{
    public class MoneyStorageTests
    {
        private Money.MoneyStorage _moneyStorage;
        
        [SetUp]
        public void Setup()
        {
            _moneyStorage = new Money.MoneyStorage();
        }
        
        [Test]
        public void EarnMoneyTest()
        {
            _moneyStorage.EarnMoney(100);

            var success = _moneyStorage.Money == 100;
            Assert.IsTrue(success);
        }
    }
}