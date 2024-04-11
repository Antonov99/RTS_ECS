using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class VictorySystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<TowerTag,Team>> _filter;
        private EcsPoolInject<Inactive> _inactivePool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                if (_inactivePool.Value.Has(entity)) Debug.Log($"{_filter.Pools.Inc2.Get(entity).value} tower destroyed");
            }
        }
    }
}