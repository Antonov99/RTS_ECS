using System.Collections.Generic;
using JetBrains.Annotations;
using Money;
using Zenject;

namespace DefaultNamespace.GameSystems
{
    [UsedImplicitly]
    public class UnitBuyer : IInitializable
    {
        private UnitsCatalog _unitsCatalog;
        private PriceCatalog _priceCatalog;
        private MoneyStorage _moneyStorage;
        private UnitsSpawner _spawner;

        private readonly Dictionary<UnitsType, UnitConfig> _units = new();

        [Inject]
        public void Construct(
            MoneyStorage storage,
            UnitsSpawner spawner,
            UnitsCatalog unitsCatalog,
            PriceCatalog priceCatalog
        )
        {
            _moneyStorage = storage;
            _spawner = spawner;
            _unitsCatalog = unitsCatalog;
            _priceCatalog = priceCatalog;
        }

        void IInitializable.Initialize()
        {
            var unitConfigs = _unitsCatalog.GetAllUnits();

            foreach (var config in unitConfigs)
            {
                _units[config.id] = config;
            }
        }

        public void BuyUnit(UnitsType unitsType)
        {
            var price = _priceCatalog.GetPrice(unitsType);

            if (!_moneyStorage.CanSpendMoney(price)) return;

            _moneyStorage.SpendMoney(price);
            _spawner.SpawnUnit(_units[unitsType]);
        }
    }
}