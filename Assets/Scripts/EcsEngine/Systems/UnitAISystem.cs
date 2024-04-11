using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class UnitAISystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<Target, MoveDirection, Position,AttackDistance>,Exc<Inactive,AttackRequest>> _filter;
        private EcsPoolInject<Position> _positionPool;
        private EcsPoolInject<AttackRequest> _attackRequestPool;
        private EcsPoolInject<TowerTag> _towerTagPool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                int targetID = _filter.Pools.Inc1.Get(entity).value;
                ref Vector3 direction = ref _filter.Pools.Inc2.Get(entity).value;
                Vector3 position = _filter.Pools.Inc3.Get(entity).value;
                float attackDistance = _filter.Pools.Inc4.Get(entity).value;
                
                if (targetID < 0) return;
                
                if (_towerTagPool.Value.Has(targetID)) attackDistance += 5f;
                
                Vector3 targetPosition = _positionPool.Value.Get(targetID).value;
                
                if (Vector3.Distance(targetPosition, position) > attackDistance)
                {
                    direction = (targetPosition - position).normalized;
                }
                else
                {
                    direction = Vector3.zero;
                    _attackRequestPool.Value.Add(entity) = new AttackRequest();
                }
            }
        }
    }
}