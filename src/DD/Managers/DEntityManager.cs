using DD.Entities;
using DD.Objects;
using DD.Collections;

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace DD.Managers
{
    internal sealed class DEntityManager : DGameObject
    {
        internal DEntity[] ActiveEntities => activeEntities.ToArray();

        // Pool
        private readonly Dictionary<Type, DObjectPool> entityPool = [];
        private readonly List<DEntity> activeEntities = [];

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

        internal static void Draw()
        {
            return;
        }

        internal void Reset()
        {
            foreach (DEntity entity in ActiveEntities)
            {
                AddEntityToObjectPool(entity);
            }

            activeEntities.Clear();
        }

        public T Create<T>() where T : DEntity
        {
            return (T)Create(typeof(T));
        }

        public DEntity Create(Type type)
        {
            DEntity entity = GetEntityFromObjectPool(type);

            entity.Initialize();
            activeEntities.Add(entity);

            return entity;
        }

        internal void Remove(DEntity entity)
        {
            _ = activeEntities.Remove(entity);
            AddEntityToObjectPool(entity);
        }

        private void AddEntityToObjectPool(DEntity entity)
        {
            Type entityType = entity.GetType();

            if (!entityPool.TryGetValue(entityType, out DObjectPool value))
            {
                value = new();
                entityPool.Add(entityType, value);
            }

            value.Add(entity);
        }

        private DEntity GetEntityFromObjectPool(Type entityType)
        {
            if (!entityPool.TryGetValue(entityType, out DObjectPool value))
            {
                value = new();
                entityPool.Add(entityType, value);
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