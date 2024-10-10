using Data;
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

        [SerializeField]
        private StatsConfig stats;
        
        protected override void Install(Entity entity)
        {
            //Logic:
            entity.AddData(new MoveSpeed{value = stats.GetStat(StatsType.WARRIOR_SPEED)});
            entity.AddData(new Health{value = stats.GetStat(StatsType.WARRIOR_HEALTH)});
            entity.AddData(new Damage{value = stats.GetStat(StatsType.WARRIOR_POWER)});
            entity.AddData(new MoveDirection{value = Vector3.zero});
            entity.AddData(new Position{value = transform.position});
            entity.AddData(new Team{value = team});
            entity.AddData(new DamagableTag());
            entity.AddData(new Target{value = -1});
            entity.AddData(new AttackDistance{value = 1f});
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