using DD.Collections;
using DD.Components.Common;
using DD.Entities;
using DD.Exceptions.Entities;
using DD.Map.Serialization;
using DD.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace DD.Managers
{
    internal sealed class DEntityManager : DGameObject
    {
        internal DEntity[] ActiveEntities => [.. this.activeEntities];

        private readonly Dictionary<Type, DObjectPool> entityPool = [];
        private readonly List<DEntity> activeEntities = [];

        private DEntity[] activeEntitiesArray;
        private int activeEntitiesLength;

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
            this.activeEntitiesArray = [.. this.activeEntities];
            this.activeEntitiesLength = activeEntitiesArray.Length;

            for (int i = 0; i < this.activeEntitiesLength; i++)
            {
                DEntity entity = this.activeEntitiesArray[i];
                if (entity == null)
                {
                    continue;
                }

                entity.Update(gameTime);
            }
        }
        protected override void OnDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < this.activeEntitiesLength; i++)
            {
                DEntity entity = this.activeEntitiesArray[i];
                if (entity == null)
                {
                    continue;
                }

                if (!entity.ComponentContainer.TryGetComponent(out DDrawComponent drawComponent))
                {
                    continue;
                }

                drawComponent.Draw(spriteBatch, gameTime);
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
            return Instantiate<T>(Vector2.Zero);
        }
        public T Instantiate<T>(Vector2 position) where T : DEntity
        {
            return Instantiate<T>(position, Vector2.One);
        }
        public T Instantiate<T>(Vector2 position, Vector2 scale) where T : DEntity
        {
            return Instantiate<T>(position, scale, 0f);
        }
        public T Instantiate<T>(Vector2 position, Vector2 scale, float rotation) where T : DEntity
        {
            return (T)Instantiate(typeof(T), position, scale, rotation);
        }
        public DEntity Instantiate(Type type)
        {
            return Instantiate(type, Vector2.Zero);
        }
        public DEntity Instantiate(Type type, Vector2 position)
        {
            return Instantiate(type, position, Vector2.One);
        }
        public DEntity Instantiate(Type type, Vector2 position, Vector2 scale)
        {
            return Instantiate(type, position, scale, 0f);
        }
        public DEntity Instantiate(Type type, Vector2 position, Vector2 scale, float rotation)
        {
            if (!typeof(DEntity).IsAssignableFrom(type))
            {
                throw new DInvalidEntityTypeException($"The type '{type}' is not a valid DEntity.");
            }

            DEntity entity = GetEntityFromObjectPool(type);
            entity.SetGameInstance(this.Game);

            DTransformComponent transform = entity.ComponentContainer.AddComponent<DTransformComponent>();
            transform.SetPosition(position);
            transform.Resize(scale);
            transform.SetRotation(rotation);

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