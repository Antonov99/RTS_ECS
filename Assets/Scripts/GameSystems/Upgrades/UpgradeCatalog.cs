using System;
using Data;
using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(
        fileName = "UpgradeCatalog",
        menuName = "Upgrades/New UpgradeCatalog"
    )]
    public sealed class UpgradeCatalog : ScriptableObject
    {
        [SerializeField]
        private UpgradeConfig[] configs;
        
        public UpgradeConfig[] GetAllUpgrades()
        {
            return configs;
        }

        public UpgradeConfig FindUpgrade(UpgradeType id)
        {
            var length = configs.Length;
            for (var i = 0; i < length; i++)
            {
                var config = configs[i];
                if (config.id == id)
                {
                    return config;
                }
            }

            throw new Exception($"Config with {id} is not found!");
        }
    }
}