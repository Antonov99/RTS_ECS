using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    internal sealed class TransformViewSystem:IEcsPostRunSystem
    {
        private EcsFilterInject<Inc<TransformView,Position,Rotation>> _filter;
        public void PostRun(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref TransformView transform = ref _filter.Pools.Inc1.Get(entity);
                Position position = _filter.Pools.Inc2.Get(entity);
                Rotation rotation = _filter.Pools.Inc3.Get(entity);

                transform.value.position = position.value;
                transform.value.rotation = rotation.value;
            }
        }
    }
}