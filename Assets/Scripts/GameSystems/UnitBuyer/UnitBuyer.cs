using System.Collections.Generic;
using Money;
using Sirenix.OdinInspector;
using Units;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.GameSystems
{
    public class UnitBuyer:MonoBehaviour
    {
        [SerializeField]
        private UnitsCatalog unitsCatalog;

        [SerializeField]
        private PriceCatalog priceCatalog;
        
        [SerializeField]
        private MoneyStorage[] moneyStorage;

        private UnitsSpawner _spawner;

        private UnitsCatalogPresenter _catalogPresenter;
        
        [ReadOnly, ShowInInspector]
        private Dictionary<UnitsData, UnitConfig> _units = new();

        [Inject]
        public void Construct(MoneyStorage[] storage, UnitsCatalogPresenter catalogPresenter, UnitsSpawner spawner)
        {
            moneyStorage = storage;
            _catalogPresenter = catalogPresenter;
            _spawner = spawner;
            
            _catalogPresenter.OnBuyUnit += BuyUnit;
        }

        private void Awake()
        {
            var unitConfigs = unitsCatalog.GetAllUnits();
            
            foreach (var config in unitConfigs)
            {
                _units[config.id] = config;
            }
        }

        [Button]
        private void BuyUnit(UnitsData unitsData, TeamData teamData)
        {
            var price = priceCatalog.GetPrice(unitsData);

            foreach (var storage in moneyStorage)
            {
                if (storage.team == teamData)
                    if (storage.CanSpendMoney(price))
                    {
                        storage.SpendMoney(price);
                        _spawner.SpawnUnit(_units[unitsData]);
                    }
            }
        }
    }
}