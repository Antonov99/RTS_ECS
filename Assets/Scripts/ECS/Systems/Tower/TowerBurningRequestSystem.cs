using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public class TowerBurningRequestSystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<TowerBurningRequest>, Exc<TowerBurningEvent>> _filter;
        private EcsPoolInject<TowerBurningEvent> _eventPool;
        private EcsPoolInject<BurningTag> _burningTagPool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                _burningTagPool.Value.Add(entity) = new BurningTag();
                _filter.Pools.Inc1.Del(entity);
                _eventPool.Value.Add(entity) = new TowerBurningEvent();
            }
        }
    }
}