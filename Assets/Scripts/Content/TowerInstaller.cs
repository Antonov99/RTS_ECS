using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class TowerInstaller:EntityInstaller
    {
        [SerializeField] 
        private string team;
        
        [SerializeField] 
        private ParticleSystem fireVFX;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new TowerTag());
            entity.AddData(new Health{value = 15});
            entity.AddData(new Team{value = team});
            entity.AddData(new DamagableTag());
            entity.AddData(new Position{value = transform.position});
            entity.AddData(new FireParticle{value = fireVFX});
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}