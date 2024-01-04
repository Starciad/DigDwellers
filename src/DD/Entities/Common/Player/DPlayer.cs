using DD.Components.Common;
using DD.Components.Common.Player;

using Microsoft.Xna.Framework;

namespace DD.Entities.Common.Player
{
    internal sealed partial class DPlayer : DEntity
    {
        private DTransformComponent _transformComponent;
        private DAnimatorComponent _animatorComponent;
        private DPlayerStatusComponent _statusComponent;
        private DSmoothComponent _smoothComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            // Get
            this._transformComponent = this.ComponentContainer.GetComponent<DTransformComponent>();

            // Adding
            _ = this.ComponentContainer.AddComponent<DDrawComponent>();
            _ = this.ComponentContainer.AddComponent<DPlayerControllerComponent>();

            this._statusComponent = this.ComponentContainer.AddComponent<DPlayerStatusComponent>();
            this._animatorComponent = this.ComponentContainer.AddComponent<DAnimatorComponent>();
            this._smoothComponent = this.ComponentContainer.AddComponent<DSmoothComponent>();

            // Settings
            OnAwake_Animation();
            this._statusComponent.PickaxeTier = 1;

            this._smoothComponent.SetPosition(this._transformComponent.Position);
            this._smoothComponent.SmoothScale = 0.4f;
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);
        }
    }
}