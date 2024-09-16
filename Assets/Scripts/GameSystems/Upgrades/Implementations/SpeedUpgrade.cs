using Data;
using DefaultNamespace;

namespace Sample.Implementations
{
    public class SpeedUpgrade : Upgrade
    {
        private readonly SpeedUpgradeConfig _config;
        private readonly UnitStats _stats;

        public SpeedUpgrade(SpeedUpgradeConfig config, UnitStats stats) : base(config)
        {
            _config = config;
            _stats = stats;
        }

        protected override void LevelUp(int lvl)
        {
            var archerSpeed = _stats.GetStat(StatsData.ARCHER_SPEED) + 1;
            _stats.SetStat(StatsData.ARCHER_SPEED, archerSpeed);
            
            var warriorSpeed = _stats.GetStat(StatsData.WARRIOR_SPEED) + 1;
            _stats.SetStat(StatsData.WARRIOR_SPEED, warriorSpeed);
            
            var wizardSpeed = _stats.GetStat(StatsData.WIZARD_SPEED) + 1;
            _stats.SetStat(StatsData.WIZARD_SPEED, wizardSpeed);
        }
    }
}