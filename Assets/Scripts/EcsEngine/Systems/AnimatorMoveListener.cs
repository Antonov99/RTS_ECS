using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class AnimatorMoveListener : IEcsRunSystem
    {
        private EcsFilterInject<Inc<AnimatorView>, Exc<AttackEvent>> _filter;
        private static readonly int Attack = Animator.StringToHash("Attack");

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                Animator animator = _filter.Pools.Inc1.Get(entity).value;
                animator.SetBool(Attack, false);
            }
        }
    }
}