using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using Zenject;

namespace EcsEngine
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EntityManager _entityManager;
        private EcsWorld _world;
        private EcsWorld _events;
        private IEcsSystems _systems;
        private EcsSystemsInstaller _systemsInstaller;

        [Inject]
        public void Construct(EntityManager entityManager, EcsSystemsInstaller systemsInstaller)
        {
            _entityManager = entityManager;
            _systemsInstaller = systemsInstaller;
        }

        private void Awake()
        {
            _world = new EcsWorld();
            _events = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.AddWorld(_events, EcsWorlds.EVENTS);
            
            _systemsInstaller.Install(_systems);
        }

        private void Start()
        {
            _entityManager.Initialize(_world);
            _systems.Inject(_entityManager);
            _systems.Init();
        }

        private void Update()
        {
            // process systems here.
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy();
                _systems = null;
            }

            // cleanup custom worlds here.

            // cleanup default world.
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}