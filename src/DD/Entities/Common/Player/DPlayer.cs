using DD.Components.Common;

namespace DD.Entities.Common.Player
{
    internal sealed partial class DPlayer : DEntity
    {
        private DAnimatorComponent _animatorComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            // Adding
            _ = this.ComponentContainer.AddComponent<DDrawComponent>();
            _ = this.ComponentContainer.AddComponent<DPhysicsComponent>();
            this._animatorComponent = this.ComponentContainer.AddComponent<DAnimatorComponent>();

            // Settings
            OnAwake_Animation();
        }
    }
}