using DD.Collections;
using DD.Entities;
using DD.Objects;

namespace DD.Components
{
    internal abstract class DComponent : DGameObject, IDPoolableObject
    {
        protected DEntity Entity { get; private set; }

        internal void SetEntityInstance(DEntity entity)
        {
            this.Entity = entity;
        }

        public virtual void Reset()
        {
            this.Entity = null;
        }
    }
}
