using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class AttackRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<AttackRequest, Target, Damage, DamageDelay>, Exc<Inactive>> _filter;
        private readonly EcsPoolInject<AttackEvent> _eventPool;

        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Health> _healthPool;
        private readonly EcsPoolInject<DamageDelay> _damageDelayPool;
        private readonly EcsPoolInject<LastAttackDate> _lastDamageTimePool;

        public void Run(IEcsSystems systems)
        {
            foreach (var @event in _filter.Value)
            {
                int target = _filter.Pools.Inc2.Get(@event).value;
                int damage = _filter.Pools.Inc3.Get(@event).value;
                float damageDelay = _damageDelayPool.Value.Get(@event).value;
                ref float lastDamageTime = ref _lastDamageTimePool.Value.Get(@event).value;

                if (Time.time - lastDamageTime >= damageDelay)
                {
                    if (_world.Value.IsEntityAlive(target) && _healthPool.Value.Has(target))
                    {
                        ref int health = ref _healthPool.Value.Get(target).value;
                        health = Mathf.Max(0, health - damage);
                        lastDamageTime = Time.time;
                    }
                }

                _filter.Pools.Inc1.Del(@event);
                _eventPool.Value.Add(@event) = new AttackEvent();
            }
        }
    }
}