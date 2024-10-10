using EcsEngine.Components;
using EcsEngine.Systems;
using JetBrains.Annotations;
using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;

namespace EcsEngine
{
    [UsedImplicitly]
    public class EcsSystemsInstaller
    {
        private IEcsSystems _systems;
        public void Install(IEcsSystems systems)
        {
            _systems = systems;

            InstallLogic();
            InstallView();
            Clear();
        }

        private void InstallLogic()
        {
            _systems
                //Logic:
                .Add(new MovementSystem())
                .Add(new HealthEmptySystem())
                .Add(new DeathRequestSystem())
                .Add(new TargetExistSystem())
                .Add(new TargetRequestSystem())
                .Add(new UnitAISystem())
                .Add(new AttackRequestSystem())
                .Add(new VictorySystem())
                .Add(new TowerBurningSystem())
                .Add(new TowerBurningRequestSystem());
        }

        private void InstallView()
        {
            _systems
                .Add(new TransformViewSystem())
                .Add(new AnimatorDeathListener())
                .Add(new AnimatorAttackListener())
                .Add(new AnimatorMoveListener())
                .Add(new TowerVFXListener())

                //Editor:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
        }

        private void Clear()
        {
            _systems
                .DelHere<DeathEvent>()
                .DelHere<AttackEvent>();
        }
    }
}