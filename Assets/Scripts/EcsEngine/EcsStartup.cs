using System;
using EcsEngine.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EntityManager _entityManager;
        private EcsWorld _world;
        private IEcsSystems _systems;

        private void Awake()
        {
            _entityManager = new EntityManager();
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems
                .Add(new MovementSystem())
                
                
                .Add(new TransformViewSystem())
                
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
        }

        void Start()
        {
            _entityManager.Initialize(_world);
            _systems.Inject();
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