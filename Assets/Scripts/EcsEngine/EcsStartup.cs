using System;
using EcsEngine;
using EcsEngine.Components;
using EcsEngine.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using Zenject;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EntityManager _entityManager;
        private EcsWorld _world;
        private EcsWorld _events;
        private IEcsSystems _systems;

        [Inject]
        public void Construct(EntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        private void Awake()
        {
            _world = new EcsWorld();
            _events = new EcsWorld();
            _systems = new EcsSystems(_world);
            
            _systems.AddWorld(_events, EcsWorlds.EVENTS);

            _systems
                //Logic:
                .Add(new MovementSystem())
                .Add(new HealthEmptySystem())
                .Add(new DeathRequestSystem())
                .Add(new TargetExistSystem())
                .Add(new TargetRequestSystem())
                .Add(new UnitAISystem())
                
                //View:
                .Add(new TransformViewSystem())
                .Add(new AnimatorDeathListener())
                
                //Editor:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                
                //Clear:
                .DelHere<DeathEvent>();
        }

        void Start()
        {
            _entityManager.Initialize(_world);
            _systems.Inject(_entityManager);
            _systems.Init();
        }

        void Update()
        {
            // process systems here.
            _systems?.Run();
        }

        void OnDestroy()
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