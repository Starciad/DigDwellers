using DD.Collections;
using DD.Components;
using DD.Exceptions.Components;
using DD.Objects;

using System;
using System.Collections.Generic;

namespace DD.Managers
{
    internal sealed class DComponentManager : DGameObject
    {
        private readonly Dictionary<Type, DObjectPool> componentsPool = [];

        internal T Instantiate<T>() where T : DComponent
        {
            return (T)Instantiate(typeof(T));
        }

        internal DComponent Instantiate(Type componentType)
        {
            if (!componentType.IsSubclassOf(typeof(DComponent)))
            {
                throw new DInvalidComponentTypeException($"The type '{componentType.Name}' is not a valid {nameof(DComponent)}.");
            }

            if (this.componentsPool.TryGetValue(componentType, out DObjectPool pool))
            {
                return (DComponent)pool.Get();
            }
            else
            {
                this.componentsPool.Add(componentType, new());
                return (DComponent)Activator.CreateInstance(componentType);
            }
        }

        internal void Destroy(DComponent component)
        {
            Type componentType = component.GetType();

            if (!this.componentsPool.TryGetValue(componentType, out DObjectPool pool))
            {
                pool = new();
                this.componentsPool.Add(componentType, pool);
            }

            pool.Add(component);
        }
    }
}
