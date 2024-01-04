using DD.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DD.Components.Common.Player
{
    internal sealed class DPlayerControllerComponent : DComponent
    {
        private DInputManager _inputManager;

        private DPhysicsComponent _physicsComponent;
        private DAttributesComponent _attributesComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this._inputManager = this.Game.InputManager;

            this._physicsComponent = this.Entity.ComponentContainer.GetComponent<DPhysicsComponent>();
            this._attributesComponent = this.Entity.ComponentContainer.GetComponent<DAttributesComponent>();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            UpdateHorizontal();
            UpdateVertical();
            UpdateJump();
        }

        private void UpdateHorizontal()
        {
            if (this._inputManager.Performed(Keys.Left))
            {
                this._physicsComponent.Velocity = new(-this._attributesComponent.Speed, this._physicsComponent.Velocity.Y);
            }
            else if (this._inputManager.Performed(Keys.Right))
            {
                this._physicsComponent.Velocity = new(this._attributesComponent.Speed, this._physicsComponent.Velocity.Y);
            }
            else
            {
                this._physicsComponent.Velocity = Vector2.Zero;
            }
        }

        private void UpdateVertical()
        {

        }

        private void UpdateJump()
        {

        }
    }
}