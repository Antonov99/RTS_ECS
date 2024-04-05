using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class MovementSystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveDirection, MoveSpeed, Position>,Exc<Inactive>> _filter;
        
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            EcsPool<MoveDirection> moveDirectionPool = _filter.Pools.Inc1;
            EcsPool<MoveSpeed> moveSpeedPool = _filter.Pools.Inc2;
            EcsPool<Position> positionPool = _filter.Pools.Inc3;

            float deltaTime = Time.deltaTime;
            
            foreach (var entity in _filter.Value)
            {
                MoveDirection moveDirection = moveDirectionPool.Get(entity);
                MoveSpeed moveSpeed  = moveSpeedPool.Get(entity);
                ref Position position = ref positionPool.Get(entity);

                position.value += moveDirection.value * moveSpeed.value * deltaTime;
            }
        }
    }
}