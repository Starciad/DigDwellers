using DD.Collections;
using DD.Entities;
using DD.Map.Serialization;
using DD.Objects;

using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;

namespace DD.Managers
{
    internal sealed class DEntityManager : DGameObject
    {
        internal DEntity[] ActiveEntities => this.activeEntities.ToArray();

        private readonly Dictionary<Type, DObjectPool> entityPool = [];
        private readonly List<DEntity> activeEntities = [];

        internal void Load(DMapxData data)
        {
            return;
        }
        internal void Unload()
        {
            return;
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            foreach (DEntity entity in this.ActiveEntities)
            {
                if (entity != null)
                {
                    continue;
                }

                entity.Update(gameTime);
            }
        }

        internal void Reset()
        {
            foreach (DEntity entity in this.ActiveEntities)
            {
                AddEntityToObjectPool(entity);
            }

            this.activeEntities.Clear();
        }

        public T Instantiate<T>() where T : DEntity
        {
            return (T)Instantiate(typeof(T));
        }
        public DEntity Instantiate(Type type)
        {
            DEntity entity = GetEntityFromObjectPool(type);

            entity.Initialize();
            this.activeEntities.Add(entity);

            return entity;
        }
        internal void Destroy(DEntity entity)
        {
            _ = this.activeEntities.Remove(entity);
            AddEntityToObjectPool(entity);
        }

        private void AddEntityToObjectPool(DEntity entity)
        {
            Type entityType = entity.GetType();

            if (!this.entityPool.TryGetValue(entityType, out DObjectPool value))
            {
                value = new();
                this.entityPool.Add(entityType, value);
            }

            value.Add(entity);
        }
        private DEntity GetEntityFromObjectPool(Type entityType)
        {
            if (!this.entityPool.TryGetValue(entityType, out DObjectPool value))
            {
                value = new();
                this.entityPool.Add(entityType, value);
            }

            DEntity entity = (DEntity)value.Get();

            if (entity == null)
            {
                entity = (DEntity)Activator.CreateInstance(entityType);
                entity.Reset();
            }

            return entity;
        }
    }
}