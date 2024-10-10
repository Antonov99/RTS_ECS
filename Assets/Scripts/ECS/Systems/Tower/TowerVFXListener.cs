using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public class TowerVFXListener:IEcsRunSystem
    {
        private EcsFilterInject<Inc<TowerBurningEvent, FireParticle>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var fire = _filter.Pools.Inc2.Get(entity).value;
                fire.Play();
            }
        }
    }
}