using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class AnimatorDeathListener:IEcsRunSystem
    {
        private EcsFilterInject<Inc<AnimatorView, DeathEvent>> _filter;
        private static readonly int Death = Animator.StringToHash("Death");

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                Animator animator = _filter.Pools.Inc1.Get(entity).value;
                animator.SetTrigger(Death);
            }
        }
    }
}