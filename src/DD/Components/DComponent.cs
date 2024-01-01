using DD.Entities;
using DD.Objects;

namespace DD.Components
{
    internal class DComponent : DGameObject
    {
        protected DEntity Entity { get; private set; }

        internal void SetEntityInstance(DEntity entity)
        {
            this.Entity = entity;
        }
    }
}
