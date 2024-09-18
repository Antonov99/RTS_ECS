using System;
using Data;
using EcsEngine.Components;
using JetBrains.Annotations;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Zenject;

namespace DefaultNamespace
{
    [UsedImplicitly]
    public class EcsStatsController:IInitializable,IDisposable
    {
        private EcsWorld _world;

        private UnitStats _stats;

        private EntityManager _entityManager;
        
        private readonly EcsFilterInject<Inc<Health>, Exc<TowerTag>> _filter;
        
        [Inject]
        public void Construct(UnitStats stats, EntityManager entityManager)
        {
            _stats = stats;
            _entityManager = entityManager;
            _world = entityManager.world;
        }

        void IInitializable.Initialize()
        {
            _stats.OnStatChanged += UpdateStats;
        }
        
        private void UpdateStats(StatsData data, int value)
        {
            /*foreach (var entity in _filter.Value)
            {
                ref int health = ref _filter.Pools.Inc1.Get(entity).value;
                health = value;
            }*/
        }

        void IDisposable.Dispose()
        {
            _stats.OnStatChanged -= UpdateStats;
        }
    }
}