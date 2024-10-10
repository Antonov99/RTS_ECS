using Data;
using Sample;

namespace DefaultNamespace.GameSystems.Upgrades
{
    public class StatsUpgrade:Upgrade
    {
        private readonly UnitStats _stats;
        private readonly StatsType[] _targetTypes;
        
        public StatsUpgrade(UpgradeConfig config, UnitStats stats, StatsType[] targetTypes) : base(config)
        {
            _stats = stats;
            _targetTypes = targetTypes;
        }

        protected override void LevelUp(int lvl)
        {
            foreach (var type in _targetTypes)
            {
                var stat = _stats.GetStat(type);
                _stats.SetStat(type,stat+1);
            }
        }
    }
}