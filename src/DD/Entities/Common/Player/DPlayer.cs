using DD.Collision.Info;
using DD.Components.Common;
using DD.Utilities;

using Microsoft.Xna.Framework;

namespace DD.Entities.Common.Player
{
    internal sealed partial class DPlayer : DEntity
    {
        private DTransformComponent _transformComponent;
        private DPhysicsComponent _physicsComponent;
        private DTileCollisionComponent _tileCollisionComponent;
        private DAnimatorComponent _animatorComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            // Get
            this._transformComponent = this.ComponentContainer.GetComponent<DTransformComponent>();

            // Adding
            _ = this.ComponentContainer.AddComponent<DDrawComponent>();
            _ = this.ComponentContainer.AddComponent<DControllerComponent>();
            this._physicsComponent = this.ComponentContainer.AddComponent<DPhysicsComponent>();
            this._tileCollisionComponent = this.ComponentContainer.AddComponent<DTileCollisionComponent>();
            this._animatorComponent = this.ComponentContainer.AddComponent<DAnimatorComponent>();

            // Settings
            OnAwake_Animation();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            Update_TileCollision();
        }

        private void Update_TileCollision()
        {
            Vector2 gridPosition = DTileMapUtilities.ToGridPosition(this._transformComponent.Position);

            DTileCollisionInfo[] collisionInfos = this._tileCollisionComponent.DetectedCollisions;
            int length = collisionInfos.Length;

            for (int i = 0; i < length; i++)
            {
                DTileCollisionInfo collisionInfo = collisionInfos[i];

                // Up & Down
                if (collisionInfo.TilePosition.Equals(gridPosition + Vector2.UnitY) ||
                    collisionInfo.TilePosition.Equals(gridPosition - Vector2.UnitY))
                {
                    this._physicsComponent.Velocity = new(this._physicsComponent.Velocity.X, 0);
                }

                // Left & Right
                if (collisionInfo.TilePosition.Equals(gridPosition + Vector2.UnitX) ||
                    collisionInfo.TilePosition.Equals(gridPosition - Vector2.UnitX))
                {
                    this._physicsComponent.Velocity = new(0, this._physicsComponent.Velocity.Y);
                }
            }
        }
    }
}