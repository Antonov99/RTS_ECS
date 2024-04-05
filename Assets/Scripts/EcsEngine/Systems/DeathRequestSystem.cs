using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public class DeathRequestSystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<DeathRequest>, Exc<Inactive>> _filter;
        private EcsPoolInject<DeathEvent> _eventPool;
        private EcsPoolInject<Inactive> _tagPool;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                _filter.Pools.Inc1.Del(entity);
                _tagPool.Value.Add(entity) = new Inactive();
                _eventPool.Value.Add(entity) = new DeathEvent();
            }
        }
    }
}