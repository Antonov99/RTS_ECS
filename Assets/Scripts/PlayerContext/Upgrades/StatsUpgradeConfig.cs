using Data;
using DefaultNamespace;
using DefaultNamespace.GameSystems.Upgrades;
using UnityEngine;
using Zenject;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "StatsUpgrade",
        menuName = "Upgrades/New StatsUpgrade"
    )]
    public class StatsUpgradeConfig:UpgradeConfig
    {
        [SerializeField]
        private StatsType[] statTypes;
        
        public override Upgrade InstantiateUpgrade(DiContainer container)
        {
            var unitStats = container.Resolve<UnitStats>();
            return new StatsUpgrade(this, unitStats, statTypes);
        }
    }
}