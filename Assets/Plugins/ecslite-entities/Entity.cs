using UnityEngine;

// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace Leopotam.EcsLite.Entities
{
    public class Entity : MonoBehaviour
    {
        public int Id => id;

        private EcsWorld world;
        private int id = -1;

        [SerializeField]
        private EntityInstaller[] installers;

        public bool IsAlive()
        {
            return id != -1 && world != null;
        }

        public void Initialize(EcsWorld world)
        {
            int entity = world.NewEntity();
            Initialize(entity, world);
        }

        public void Initialize(int id, EcsWorld world)
        {
            this.id = id;
            this.world = world;

            for (int i = 0, count = installers.Length; i < count; i++)
            {
                EntityInstaller installer = installers[i];
                installer.Install(this);
            }
        }

        public void Dispose()
        {
            for (int i = 0, count = installers.Length; i < count; i++)
            {
                EntityInstaller installer = installers[i];
                installer.Dispose(this);
            }
            
            world.DelEntity(id);
            world = null;
            id = -1;
        }

        public void AddData<T>(T component) where T : struct
        {
            var pool = world.GetPool<T>();
            pool.Add(id) = component;
        }

        public void RemoveData<T>() where T : struct
        {
            var pool = world.GetPool<T>();
            pool.Del(id);
        }

        public ref T GetData<T>() where T : struct
        {
            EcsPool<T> pool = world.GetPool<T>();
            return ref pool.Get(id);
        }

        public void SetData<T>(T data) where T : struct
        {
            var pool = world.GetPool<T>();
            if (pool.Has(id))
            {
                pool.Get(id) = data;
            }
            else
            {
                pool.Add(id) = data;
            }
        }

        public bool TryGetData<T>(out T data) where T : struct
        {
            var pool = world.GetPool<T>();
            if (pool.Has(id))
            {
                data = pool.Get(id);
                return true;
            }

            data = default;
            return false;
        }

        public bool HasData<T>() where T : struct
        {
            var pool = world.GetPool<T>();
            return pool.Has(id);
        }

        public int GetComponentsNonAlloc(ref object[] components)
        {
            return world.GetComponents(id, ref components);
        }

        public EcsWorld GetWorld()
        {
            return world;
        }
    }
}