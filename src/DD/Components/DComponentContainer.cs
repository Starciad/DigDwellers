using DD.Entities;
using DD.Exceptions.Components;
using DD.Objects;

using System;
using System.Collections.Generic;

namespace DD.Components
{
    internal sealed class DComponentContainer : DGameObject
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
            if (!componentType.IsSubclassOf(typeof(DComponent)))
            {
                throw new DInvalidComponentTypeException($"The type '{componentType.Name}' is not a valid {nameof(DComponent)}.");
            }

            if (this._components.ContainsKey(componentType))
            {
                throw new DDuplicateComponentsException($"The entity already contains a '{componentType.Name}' component.");
            }

            DComponent componentValue = (DComponent)Activator.CreateInstance(componentType);
            componentValue.SetGameInstance(this.Game);
            componentValue.SetEntityInstance(this._entity);
            this._components.Add(componentType, componentValue);
            return componentValue;
        }
        internal DComponent GetComponent(Type componentType)
        {
            return this._components.TryGetValue(componentType, out DComponent value) ? value : null;
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
            return this._components.Remove(componentType);
        }
        internal bool HasComponent(Type componentType)
        {
            return !componentType.IsSubclassOf(typeof(DComponent))
                ? throw new DInvalidComponentTypeException($"The type '{componentType.Name}' is not a valid {nameof(DComponent)}.")
                : this._components.ContainsKey(componentType);
        }
        internal void RemoveAllComponents()
        {
            this._components.Clear();
        }

        protected override void OnAwake()
        {
            foreach (DComponent component in this._components.Values)
            {
                component.Initialize();
            }
        }
        protected override void OnUpdate()
        {
            foreach (DComponent component in this._components.Values)
            {
                component.Update();
            }
        }
    }
}
