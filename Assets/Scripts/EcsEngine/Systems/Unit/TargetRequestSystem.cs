using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class TargetRequestSystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<TargetRequest, Target, Team, Position>,Exc<Inactive>> _filterUnit;
        private EcsFilterInject<Inc<Team, Position>,Exc<Inactive>> _filterAllUnits;
            
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filterUnit.Value)
            {
                UpdateTarget(entity);
            }
        }

        private void UpdateTarget(int entity)
        {
            var myTeam = _filterUnit.Pools.Inc3.Get(entity).value;
            var myPosition = _filterUnit.Pools.Inc4.Get(entity).value;
            var minDistance = float.MaxValue;

            foreach (var enemy in _filterAllUnits.Value)
            {
                var enemyTeam = _filterAllUnits.Pools.Inc1.Get(enemy).value;

                if (myTeam == enemyTeam) continue;
                
                var enemyPosition = _filterAllUnits.Pools.Inc2.Get(enemy).value;
                float distance = Vector3.Distance(myPosition, enemyPosition);

                if (!(distance < minDistance)) continue;
                
                minDistance = distance;
                var targetEntity = enemy;
                
                if (targetEntity != -1)
                {
                    _filterUnit.Pools.Inc2.Get(entity).value = targetEntity;
                }
            }
            _filterUnit.Pools.Inc1.Del(entity);
        }
    }
}