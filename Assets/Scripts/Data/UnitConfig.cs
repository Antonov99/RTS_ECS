using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(
        fileName = "UnitConfig",
        menuName = "Units/New UnitConfig"
    )]
    public class UnitConfig:ScriptableObject
    {
        [SerializeField]
        public UnitsData id;
        
        [SerializeField]
        public Entity prefab;

        [SerializeField]
        public Transform spawnPoint;
    }
}