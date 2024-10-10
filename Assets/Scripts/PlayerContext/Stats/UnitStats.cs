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
        private readonly Dictionary<StatsType, int> _stats = new();
        
        public event Action<StatsType, int> OnStatChanged;

        public void AddStat(StatsType name, int value)
        {
            _stats.Add(name, value);
        }

        public int GetStat(StatsType name)
        {
            return _stats[name];
        }

        public IReadOnlyDictionary<StatsType, int> GetStats()
        {
            return _stats;
        }

        public void RemoveStat(StatsType name)
        {
            _stats.Remove(name);
        }

        public void SetStat(StatsType name, int value)
        {
            _stats[name] = value;
            OnStatChanged?.Invoke(name,value);
        }
    }
}