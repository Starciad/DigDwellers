using DD.Components.Common;
using DD.Components.Common.Player;

using Microsoft.Xna.Framework;

namespace DD.Entities.Common.Player
{
    internal sealed partial class DPlayer : DEntity
    {
        private DTransformComponent _transformComponent;
        private DAnimatorComponent _animatorComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            // Get
            this._transformComponent = this.ComponentContainer.GetComponent<DTransformComponent>();

            // Adding
            _ = this.ComponentContainer.AddComponent<DDrawComponent>();
            _ = this.ComponentContainer.AddComponent<DPlayerControllerComponent>();

            this._animatorComponent = this.ComponentContainer.AddComponent<DAnimatorComponent>();

            // Settings
            OnAwake_Animation();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);
        }
    }
}