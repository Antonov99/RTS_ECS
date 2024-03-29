using EcsEngine.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class MovementSystem:IEcsRunSystem
    {
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<MoveDirection>().Inc<MoveSpeed>().Inc<Position>().End();

            EcsPool<MoveDirection> moveDirectionPool = world.GetPool<MoveDirection>();
            EcsPool<MoveSpeed> moveSpeedPool = world.GetPool<MoveSpeed>();
            EcsPool<Position> positionPool = world.GetPool<Position>();

            float deltaTime = Time.deltaTime;
            
            foreach (var entity in filter)
            {
                ref MoveDirection moveDirection = ref moveDirectionPool.Get(entity);
                ref MoveSpeed moveSpeed  = ref moveSpeedPool.Get(entity);
                ref Position position = ref positionPool.Get(entity);

                position.value += moveDirection.value * moveSpeed.value * deltaTime;
            }
        }
    }
}