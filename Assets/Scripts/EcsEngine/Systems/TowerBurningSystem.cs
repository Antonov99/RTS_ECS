using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public class TowerBurningSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Health, TowerTag>, Exc<TowerBurningRequest, BurningTag>> _filter;
        private EcsPoolInject<TowerBurningRequest> _burningPool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                Health health = _filter.Pools.Inc1.Get(entity);
                if (health.value < 10) _burningPool.Value.Add(entity) = new TowerBurningRequest();
            }
        }
    }
}