using DefaultNamespace;
using Leopotam.EcsLite.Entities;
using UnityEngine;

public class UnitsSpawnSystem
{
    private readonly Transform _parent;
    
    private readonly EntityManager _entityManager;
    
    public UnitsSpawnSystem(EntityManager entityManager, Transform parent)
    {
        _entityManager = entityManager;
        _parent = parent;
    }
    
    public void SpawnUnit(UnitConfig config)
    {
        _entityManager.Create(
            config.prefab,
            config.spawnPoint.position, 
            config.spawnPoint.rotation,
            _parent
            );
    }
}
