using System;
using Data;
using DefaultNamespace;
using Sirenix.OdinInspector;

namespace Sample
{
    public abstract class Upgrade
    {
        public event Action<int> OnLevelUp;

        [ShowInInspector, ReadOnly] 
        public UpgradeType[] Dependencies { get; set; }

        [ShowInInspector, ReadOnly] 
        public UpgradeType ID { get; set; }

        [ShowInInspector, ReadOnly]
        public int Level => _currentLevel;

        [ShowInInspector, ReadOnly]
        public int MaxLevel { get; set; }

        public bool IsMaxLevel => _currentLevel == MaxLevel;

        [ShowInInspector, ReadOnly]
        public float Progress => (float) _currentLevel / MaxLevel;

        [ShowInInspector, ReadOnly] 
        public int NextPrice { get; set; }

        private int _currentLevel=1;

        protected Upgrade(UpgradeConfig config)
        {
            NextPrice = config.GetPrice(Level + 1);
            MaxLevel = config.maxLevel;
            ID = config.id;
            Dependencies = config.dependencies;
        }

        protected Upgrade(PriceTable table, int maxLevel, UpgradeType id, UpgradeType[] dependencies)
        {
            NextPrice = table.GetPrice(Level + 1);
            MaxLevel = maxLevel;
            ID = id;
            Dependencies = dependencies;
        }

        public void SetupLevel(int lvl)
        {
            _currentLevel = lvl;
        }

        public void LevelUp()
        {
            if (Level >= MaxLevel)
            {
                throw new Exception($"Can not increment level for upgrade {ID}!");
            }

            var nextLevel = Level + 1;
            _currentLevel = nextLevel;
            LevelUp(nextLevel);
            OnLevelUp?.Invoke(nextLevel);
        }

        protected abstract void LevelUp(int lvl);
    }
}