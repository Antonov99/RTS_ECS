using Data;
using DefaultNamespace;

namespace Sample.Implementations
{
    public class HealthUpgrade:Upgrade
    {
        private readonly HealthUpgradeConfig _config;
        private readonly UnitStats _stats;
        
        public HealthUpgrade(HealthUpgradeConfig config, UnitStats stats) : base(config)
        {
            _config = config;
            _stats = stats;
        }

        protected override void LevelUp(int lvl)
        {
            var arcehrHealth = _stats.GetStat(StatsData.ARCHER_HEALTH) + 1;
            _stats.SetStat(StatsData.ARCHER_HEALTH, arcehrHealth);
            
            var warriorHealth = _stats.GetStat(StatsData.WARRIOR_HEALTH) + 1;
            _stats.SetStat(StatsData.WARRIOR_HEALTH, warriorHealth);
            
            var wiazrdHealth = _stats.GetStat(StatsData.WIZARD_HEALTH) + 1;
            _stats.SetStat(StatsData.WIZARD_HEALTH, wiazrdHealth);
        }
    }
}