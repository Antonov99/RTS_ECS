using DefaultNamespace;
using UnityEngine;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "PowerUpgrade",
        menuName = "Upgrades/New PowerUpgrade"
    )]
    public class PowerUpgradeConfig:UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade(UnitStats stats)
        {
            return new PowerUpgrade(this, stats);
        }
    }
}