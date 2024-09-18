using DefaultNamespace;
using Leopotam.EcsLite.Entities;
using UnityEngine;

public class UnitsSpawner
{
    private readonly Transform _parent;

    private readonly EntityManager _entityManager;

    public UnitsSpawner(EntityManager entityManager, Transform parent)
    {
        _entityManager = entityManager;
        _parent = parent;
    }

    public Entity SpawnUnit(UnitConfig config)
    {
        var entity = _entityManager.Create(
            config.prefab,
            config.spawnPoint.position,
            config.spawnPoint.rotation,
            _parent
        );

        return entity;
    }
}