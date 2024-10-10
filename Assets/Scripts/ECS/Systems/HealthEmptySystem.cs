using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public sealed class HealthEmptySystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<Health>, Exc<DeathRequest,Inactive>> _filter;
        private EcsPoolInject<DeathRequest> _deathPool;
       
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                Health health = _filter.Pools.Inc1.Get(entity);
                if (health.value <= 0) _deathPool.Value.Add(entity) = new DeathRequest();
            }
        }
    }
}