using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class UnitInstaller:EntityInstaller
    {
        protected override void Install(Entity entity)
        {
            entity.AddData(new MoveDirection{value = Vector3.forward});
            entity.AddData(new MoveSpeed{value = 3});
            entity.AddData(new Position{value = transform.position});
            entity.AddData(new TransformView{value = transform});
        }

        protected override void Dispose(Entity entity)
        {
            
        }
    }
}