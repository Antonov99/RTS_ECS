using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class RotationSystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<MoveDirection,Rotation>,Exc<Inactive>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            EcsPool<MoveDirection> moveDirectionPool = _filter.Pools.Inc1;
            EcsPool<Rotation> rotationPool = _filter.Pools.Inc2;

            foreach (var entity in _filter.Value)
            {
                MoveDirection moveDirection = moveDirectionPool.Get(entity);
                ref Rotation rotation = ref rotationPool.Get(entity);

                if (moveDirection.value != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(moveDirection.value);
                    rotation.value = Quaternion.Slerp(rotation.value, targetRotation, 0.1f);
                }
            }
        }
    }
}