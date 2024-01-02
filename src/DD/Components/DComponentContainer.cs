using DD.Collections;
using DD.Entities;
using DD.Exceptions.Components;
using DD.Objects;

using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DD.Components
{
    internal sealed class DComponentContainer : DGameObject, IDPoolableObject
    {
        internal int Count => this._components.Count;

        private readonly Dictionary<Type, DComponent> _components = [];
        private DEntity _entity;

        internal void SetEntityInstance(DEntity entity)
        {
            this._entity = entity;
        }

        internal T AddComponent<T>() where T : DComponent
        {
            return (T)AddComponent(typeof(T));
        }
        internal T GetComponent<T>() where T : DComponent
        {
            return (T)GetComponent(typeof(T));
        }
        internal void RemoveComponent<T>() where T : DComponent
        {
            RemoveComponent(typeof(T));
        }
        internal bool TryGetComponent<T>(out T value) where T : DComponent
        {
            if (TryGetComponent(typeof(T), out DComponent component))
            {
                value = (T)component;
                return true;
            }

            value = null;
            return false;
        }
        internal bool TryRemoveComponent<T>() where T : DComponent
        {
            return TryRemoveComponent(typeof(T));
        }
        internal bool HasComponent<T>() where T : DComponent
        {
            return HasComponent(typeof(T));
        }

        internal DComponent AddComponent(Type componentType)
        {
            if (!typeof(DComponent).IsAssignableFrom(componentType))
            {
                throw new DInvalidComponentTypeException($"The type '{componentType.Name}' is not a valid {nameof(DComponent)}.");
            }

            if (this._components.ContainsKey(componentType))
            {
                throw new DDuplicateComponentsException($"The entity already contains a '{componentType.Name}' component.");
            }

            DComponent componentValue = this.Game.ComponentManager.Instantiate(componentType);
            componentValue.SetGameInstance(this.Game);
            componentValue.SetEntityInstance(this._entity);
            this._components.Add(componentType, componentValue);
            return componentValue;
        }
        internal DComponent GetComponent(Type componentType)
        {
            return this._components.TryGetValue(componentType, out DComponent value) ? value : null;
        }
        internal void RemoveComponent(Type componentType)
        {
            _ = TryRemoveComponent(componentType);
        }
        internal bool TryGetComponent(Type componentType, out DComponent value)
        {
            DComponent result = GetComponent(componentType);
            if (result != null)
            {
                value = result;
                return true;
            }

            value = null;
            return false;
        }
        internal bool TryRemoveComponent(Type componentType)
        {
            if (this._components.TryGetValue(componentType, out DComponent value))
            {
                this.Game.ComponentManager.Destroy(value);
            }

            return this._components.Remove(componentType);
        }
        internal bool HasComponent(Type componentType)
        {
            return !typeof(DComponent).IsAssignableFrom(componentType)
                ? throw new DInvalidComponentTypeException($"The type '{componentType.Name}' is not a valid {nameof(DComponent)}.")
                : this._components.ContainsKey(componentType);
        }
        internal void RemoveAllComponents()
        {
            while (this._components.Count > 0)
            {
                RemoveComponent(this._components.First().Key);
            }
        }

        protected override void OnAwake()
        {
            foreach (DComponent component in this._components.Values)
            {
                component.Initialize();
            }
        }
        protected override void OnUpdate(GameTime gameTime)
        {
            foreach (DComponent component in this._components.Values)
            {
                component.Update(gameTime);
            }
        }

        public void Reset()
        {
            RemoveAllComponents();
        }
    }
}