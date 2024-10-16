using System;
using Data;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Sample
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        private const float _SPACE_HEIGHT = 10.0f;

        [SerializeField]
        public UpgradeType[] dependencies;
        
        [SerializeField]
        public UpgradeType id;
        
        [Range(2, 99)]
        [SerializeField]
        public int maxLevel = 2;

        [Space(_SPACE_HEIGHT)]
        [SerializeField]
        private PriceTable priceTable;

        public abstract Upgrade InstantiateUpgrade(DiContainer container);

        private void OnValidate()
        {
            try
            {
                Validate();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void Validate()
        {
            priceTable.OnValidate(maxLevel);
        }
        
        
        public int GetPrice(int level)
        {
            return priceTable.GetPrice(level);
        }
    }
}