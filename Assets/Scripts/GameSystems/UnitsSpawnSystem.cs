using Leopotam.EcsLite.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class UnitsSpawnSystem : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    
    private EntityManager _entityManager;
    
    [SerializeField]
    private Entity blueWarriorPrefab;

    [SerializeField]
    private GameObject spawnPointBlueWarrior;
    
    [SerializeField]
    private Entity redWarriorPrefab;
    
    [SerializeField]
    private GameObject spawnPointRedWarrior;

    [SerializeField]
    private Entity blueArcherPrefab;
    
    [SerializeField]
    private GameObject spawnPointBlueArcher;
    
    [SerializeField]
    private Entity redArcherPrefab;
    
    [SerializeField]
    private GameObject spawnPointRedArcher;
    
    [Inject]
    public void Construct(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }
    
    [Button]
    public void SpawnBlueWarrior()
    {
        _entityManager.Create(
            blueWarriorPrefab,
            spawnPointBlueWarrior.transform.position, 
            spawnPointBlueWarrior.transform.rotation,
            parent
            );
    }
    
    [Button]
    public void SpawnRedWarrior()
    {
        _entityManager.Create(
            redWarriorPrefab, 
            spawnPointRedWarrior.transform.position, 
            spawnPointRedWarrior.transform.rotation,
            parent
            );
    }
    
    [Button]
    public void SpawnBlueArcher()
    {
        _entityManager.Create(
            blueArcherPrefab, 
            spawnPointBlueArcher.transform.position, 
            spawnPointBlueArcher.transform.rotation,
            parent
        );
    }
    
    [Button]
    public void SpawnRedArcher()
    {
        _entityManager.Create(
            redArcherPrefab, 
            spawnPointRedArcher.transform.position, 
            spawnPointRedArcher.transform.rotation,
            parent
        );
    }
}
