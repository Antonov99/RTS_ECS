using System;
using Data;
using Sirenix.OdinInspector;
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace Sample
{
    public abstract class Upgrade
    {
        public event Action<int> OnLevelUp;

        [ShowInInspector, ReadOnly]
        public UpgradeType[] dependencies => _config.dependencies;
        
        [ShowInInspector, ReadOnly]
        public UpgradeType id => _config.id;

        [ShowInInspector, ReadOnly]
        public int level => _currentLevel;

        [ShowInInspector, ReadOnly]
        public int maxLevel => _config.maxLevel;

        public bool isMaxLevel => _currentLevel == _config.maxLevel;

        [ShowInInspector, ReadOnly]
        public float progress => (float) _currentLevel / _config.maxLevel;

        [ShowInInspector, ReadOnly]
        public int nextPrice => _config.GetPrice(level + 1);

        private readonly UpgradeConfig _config;

        private int _currentLevel;

        protected Upgrade(UpgradeConfig config)
        {
            _config = config;
            _currentLevel = 1;
        }

        public void SetupLevel(int lvl)
        {
            _currentLevel = lvl;
        }

        public void LevelUp()
        {
            if (level >= maxLevel)
            {
                throw new Exception($"Can not increment level for upgrade {_config.id}!");
            }

            var nextLevel = level + 1;
            _currentLevel = nextLevel;
            LevelUp(nextLevel);
            OnLevelUp?.Invoke(nextLevel);
        }

        protected abstract void LevelUp(int lvl);
    }
}