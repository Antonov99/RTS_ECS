using Data;
using DefaultNamespace;

namespace Sample.Implementations
{
    public class PowerUpgrade:Upgrade
    {
        private readonly PowerUpgradeConfig _config;
        private readonly UnitStats _stats;

        public PowerUpgrade(PowerUpgradeConfig config, UnitStats stats) : base(config)
        {
            _config = config;
            _stats = stats;
        }

        protected override void LevelUp(int lvl)
        {
            var archerPower = _stats.GetStat(StatsData.ARCHER_POWER) + 1;
            _stats.SetStat(StatsData.ARCHER_POWER, archerPower);
            
            var warriorPower = _stats.GetStat(StatsData.WARRIOR_POWER) + 1;
            _stats.SetStat(StatsData.WARRIOR_POWER, warriorPower);
            
            var wizardPower = _stats.GetStat(StatsData.WIZARD_POWER) + 1;
            _stats.SetStat(StatsData.WIZARD_POWER, wizardPower);
        }
    }
}