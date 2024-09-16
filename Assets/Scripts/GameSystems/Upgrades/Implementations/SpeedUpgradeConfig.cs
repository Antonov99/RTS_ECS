using DefaultNamespace;
using UnityEngine;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "SpeedUpgrade",
        menuName = "Upgrades/New SpeedUpgrade"
    )]
    public class SpeedUpgradeConfig:UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade(UnitStats stats)
        {
            return new SpeedUpgrade(this, stats);
        }
    }
}