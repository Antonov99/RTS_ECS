﻿using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class ArcherInstaller:EntityInstaller
    {
        [SerializeField] 
        private Animator animator;

        [SerializeField] 
        private string team;
        
        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private Entity arrowPrefab;
        
        protected override void Install(Entity entity)
        {
            //Logic:
            entity.AddData(new MoveDirection{value = Vector3.forward});
            entity.AddData(new MoveSpeed{value = 1});
            entity.AddData(new Position{value = transform.position});
            entity.AddData(new Health{value = 5});
            entity.AddData(new Team{value = team});
            entity.AddData(new DamagableTag());
            
            entity.AddData(new DistanceWeapon
            {
                firePoint = firePoint,
                bulletPrefab = arrowPrefab
            });
            
            //View:
            entity.AddData(new TransformView{value = transform});
            entity.AddData(new AnimatorView{value = animator});
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}