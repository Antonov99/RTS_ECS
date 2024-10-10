using Data;
using JetBrains.Annotations;
using Zenject;

namespace DefaultNamespace
{
    [UsedImplicitly]
    public class StatsInstaller:IInitializable
    {
        private readonly StatsConfig _statsConfig;

        private readonly UnitStats _stats;

        public StatsInstaller(StatsConfig statsConfig,UnitStats stats)
        {
            _statsConfig = statsConfig;
            _stats = stats;
        }

        void IInitializable.Initialize()
        {
            SetupStats();
        }
        
        private void SetupStats()
        {
            foreach (var stat in _statsConfig.stats)
            {
                AddStat(stat.Key, stat.Value);
            }
        }

        private void AddStat(StatsType statName, int value)
        {
            _stats.AddStat(statName, value);
        }
    }
}