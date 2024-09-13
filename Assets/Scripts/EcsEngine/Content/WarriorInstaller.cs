using DefaultNamespace;
using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class WarriorInstaller:EntityInstaller
    {
        [SerializeField] 
        private Animator animator;

        [SerializeField] 
        private TeamData team;
        
        protected override void Install(Entity entity)
        {
            //Logic:
            entity.AddData(new MoveDirection{value = Vector3.zero});
            entity.AddData(new MoveSpeed{value = 3});
            entity.AddData(new Position{value = transform.position});
            entity.AddData(new Health{value = 5});
            entity.AddData(new Team{value = team});
            entity.AddData(new DamagableTag());
            entity.AddData(new Target{value = -1});
            entity.AddData(new AttackDistance{value = 1f});
            entity.AddData(new Damage{value = 3});
            entity.AddData(new DamageDelay{value = 1.6f});
            entity.AddData(new LastAttackDate{value = 0f});
            
            //View:
            entity.AddData(new TransformView{value = transform});
            entity.AddData(new AnimatorView{value = animator});
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}