using System;
using Sample;

namespace Modules.Upgrades.Tests
{
    public class UpgradeMock:Upgrade
    {
        private readonly Action<int> _levelUp;
        
        public UpgradeMock(UpgradeConfig config, Action<int> levelUp=null) : base(config)
        {
            _levelUp = levelUp;
        }

        protected override void LevelUp(int lvl)
        {
            _levelUp?.Invoke(lvl);
        }
    }
}