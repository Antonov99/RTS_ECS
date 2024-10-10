using System;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace EcsEngine.Components
{
    [Serializable]
    public struct DistanceWeapon
    {
        public Transform firePoint;
        public Entity bulletPrefab;
    }
}