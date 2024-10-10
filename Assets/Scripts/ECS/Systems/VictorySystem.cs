using DefaultNamespace.GameSystems;
using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsEngine.Systems
{
    public class VictorySystem:IEcsRunSystem
    {
        private EcsFilterInject<Inc<TowerTag,Team,DeathEvent>> _filter;
        private EcsPoolInject<Inactive> _inactivePool;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                if (_inactivePool.Value.Has(entity)) 
                    GameManager.gameManager.OnFinish();
            }
        }
    }
}