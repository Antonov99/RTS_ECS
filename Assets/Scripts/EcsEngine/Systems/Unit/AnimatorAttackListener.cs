using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class AnimatorAttackListener:IEcsRunSystem
    {
        private EcsFilterInject<Inc<AnimatorView, AttackEvent>> _filter;
        private static readonly int _attack = Animator.StringToHash("Attack");

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                Animator animator = _filter.Pools.Inc1.Get(entity).value;
                animator.SetBool(_attack,true);
            }
        }
    }
}