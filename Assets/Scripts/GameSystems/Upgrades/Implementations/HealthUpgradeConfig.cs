using DefaultNamespace;
using UnityEngine;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "HealthUpgrade",
        menuName = "Upgrades/New HealthUpgrade"
    )]
    public class HealthUpgradeConfig:UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade(UnitStats stats)
        {
            return new HealthUpgrade(this, stats);
        }
    }
}