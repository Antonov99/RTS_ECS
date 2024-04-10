using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class TowerInstaller:EntityInstaller
    {
        [SerializeField] 
        private string team;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new Health{value = 15});
            entity.AddData(new Team{value = team});
            entity.AddData(new DamagableTag());
            entity.AddData(new Position{value = transform.position});
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}