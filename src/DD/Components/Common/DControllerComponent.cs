using DD.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DD.Components.Common
{
    internal sealed class DControllerComponent : DComponent
    {
        private DInputManager _inputManager;

        private DPhysicsComponent _physicsComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this._inputManager = this.Game.InputManager;

            this._physicsComponent = this.Entity.ComponentContainer.GetComponent<DPhysicsComponent>();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            // HORIZONTAL
            if (this._inputManager.Performed(Keys.Left))
            {
                this._physicsComponent.Velocity = new(-40, 0);
            }
            else if (this._inputManager.Performed(Keys.Right))
            {
                this._physicsComponent.Velocity = new(40, 0);
            }
        }
    }
}
