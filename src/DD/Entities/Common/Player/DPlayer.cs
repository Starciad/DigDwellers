using DD.Collision.Info;
using DD.Components.Common;
using DD.Components.Common.Player;
using DD.Utilities;
using DD.Enums;

using Microsoft.Xna.Framework;

namespace DD.Entities.Common.Player
{
    internal sealed partial class DPlayer : DEntity
    {
        private DTransformComponent _transformComponent;
        private DPhysicsComponent _physicsComponent;
        private DTileCollisionComponent _tileCollisionComponent;
        private DAnimatorComponent _animatorComponent;
        private DAttributesComponent _attributesComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            // Get
            this._transformComponent = this.ComponentContainer.GetComponent<DTransformComponent>();

            // Adding
            _ = this.ComponentContainer.AddComponent<DDrawComponent>();
            // _ = this.ComponentContainer.AddComponent<DPlayerControllerComponent>();
            this._attributesComponent = this.ComponentContainer.AddComponent<DAttributesComponent>();
            this._physicsComponent = this.ComponentContainer.AddComponent<DPhysicsComponent>();
            this._tileCollisionComponent = this.ComponentContainer.AddComponent<DTileCollisionComponent>();
            this._animatorComponent = this.ComponentContainer.AddComponent<DAnimatorComponent>();

            // Settings
            OnAwake_Animation();
            this._attributesComponent.Speed = 80;
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            Update_TileCollision();
        }

        private void Update_TileCollision()
        {
            DTileCollisionInfo[] collisionInfos = this._tileCollisionComponent.DetectedCollisions;

            for (int i = 0; i < collisionInfos.Length; i++)
            {
                DTileCollisionInfo collisionInfo = collisionInfos[i];

                // Up & Down
                if (collisionInfo.Direction == DCardinalDirection.North ||
                    collisionInfo.Direction == DCardinalDirection.South)
                {
                    this._physicsComponent.Velocity = new(this._physicsComponent.Velocity.X, 0);
                }

                // Left & Right
                if (collisionInfo.Direction == DCardinalDirection.East ||
                    collisionInfo.Direction == DCardinalDirection.West)
                {
                    this._physicsComponent.Velocity = new(0, this._physicsComponent.Velocity.Y);
                }
            }
        }
    }
}