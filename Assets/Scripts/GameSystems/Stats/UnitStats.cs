using System;
using System.Collections.Generic;
using Data;
using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace DefaultNamespace
{
    [UsedImplicitly]
    [Serializable]
    public sealed class UnitStats
    {
        [ShowInInspector]
        private readonly Dictionary<StatsData, int> _stats = new();

        public void AddStat(StatsData name, int value)
        {
            _stats.Add(name, value);
        }

        public int GetStat(StatsData name)
        {
            return _stats[name];
        }

        public IReadOnlyDictionary<StatsData, int> GetStats()
        {
            return _stats;
        }

        public void RemoveStat(StatsData name)
        {
            _stats.Remove(name);
        }

        public void SetStat(StatsData name, int value)
        {
            _stats[name] = value;
        }
    }
}