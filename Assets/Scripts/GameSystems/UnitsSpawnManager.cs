using System.Collections.Generic;
using Leopotam.EcsLite.Entities;
using Money;
using Sirenix.OdinInspector;
using Units;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.GameSystems
{
    public class UnitsSpawnManager:MonoBehaviour
    {
        [SerializeField]
        private UnitsCatalog unitsCatalog;

        [SerializeField]
        private PriceCatalog priceCatalog;
        
        [SerializeField]
        private MoneyStorage[] moneyStorage;

        private UnitsSpawnSystem _spawnSystem;

        private UnitsCatalogPresenter _catalogPresenter;
        
        [SerializeField]
        private Transform parent;
        
        [ReadOnly, ShowInInspector]
        private Dictionary<UnitsData, UnitConfig> _units = new();

        [Inject]
        public void Construct(MoneyStorage[] storage, UnitsCatalogPresenter catalogPresenter, EntityManager entityManager)
        {
            moneyStorage = storage;
            _catalogPresenter = catalogPresenter;

            _catalogPresenter.OnBuyUnit += BuyUnit;
            
            _spawnSystem = new UnitsSpawnSystem(entityManager, parent);
        }

        private void Awake()
        {
            var unitConfigs = unitsCatalog.GetAllUnits();
            
            foreach (var config in unitConfigs)
            {
                _units[config.id] = config;
            }
        }

        private void BuyUnit(UnitsData unitsData, TeamData teamData)
        {
            var price = priceCatalog.GetPrice(unitsData);

            foreach (var storage in moneyStorage)
            {
                if (storage.team == teamData)
                    if (storage.CanSpendMoney(price))
                    {
                        storage.SpendMoney(price);
                        _spawnSystem.SpawnUnit(_units[unitsData]);
                    }
            }
        }
    }
}