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

            if (componentsPool.TryGetValue(componentType, out DObjectPool pool))
            {
                return (DComponent)pool.Get();
            }
            else
            {
                componentsPool.Add(componentType, new());
                return (DComponent)Activator.CreateInstance(componentType);
            }
        }

        internal void Destroy(DComponent component)
        {
            Type componentType = component.GetType();

            if (!componentsPool.TryGetValue(componentType, out DObjectPool pool))
            {
                pool = new();
                componentsPool.Add(componentType, pool);
            }

            pool.Add(component);
        }
    }
}
