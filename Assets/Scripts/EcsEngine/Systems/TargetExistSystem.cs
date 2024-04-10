using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public class TargetExistSystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<Target>, Exc<Inactive,TargetRequest>> _filter;
        private EcsPoolInject<TargetRequest> _targetPool;
        private EcsPoolInject<Inactive> _inactivePool;
            
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var target=_filter.Pools.Inc1.Get(entity).value;
                
                if (target is null || _inactivePool.Value.Has(target.Id)) 
                    _targetPool.Value.Add(entity) = new TargetRequest();
            }
        }
    }
}