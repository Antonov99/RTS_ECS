using System;
using Data;
using DefaultNamespace;
using Sample;

namespace Modules.Upgrades.Tests
{
    public class UpgradeMock:Upgrade
    {
        private readonly Action<int> _levelUp;
        
        public UpgradeMock(
            PriceTable table,
            int maxLevel, 
            UpgradeType id, 
            UpgradeType[] dependencies=null, 
            Action<int> levelUp=null
            ) : base(table, maxLevel, id,dependencies)
        {
            _levelUp = levelUp;
        }

        protected override void LevelUp(int lvl)
        {
            _levelUp?.Invoke(lvl);
        }
    }
}