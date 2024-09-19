using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Leopotam.EcsLite.Entities
{
    [UsedImplicitly]
    public sealed class EntityManager
    {
        public EcsWorld _world;

        private readonly Dictionary<int, Entity> _entities = new();
        
        public void Initialize(EcsWorld world)
        {
            Entity[] entities = Object.FindObjectsOfType<Entity>();
            for (int i = 0, count = entities.Length; i < count; i++)
            {
                Entity entity = entities[i];
                entity.Initialize(world);
                _entities.Add(entity.Id, entity);
            }
            
            _world = world;
        }

        public Entity Create(Entity prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Entity entity = Object.Instantiate(prefab, position, rotation, parent);
            entity.Initialize(_world);
            _entities.Add(entity.Id, entity);
            return entity;
        }

        public void Destroy(int id)
        {
            if (_entities.Remove(id, out Entity entity))
            {
                entity.Dispose();
                Object.Destroy(entity.gameObject);
            }
        }

        public Entity Get(int id)
        {
            return _entities[id];
        }
    }
}