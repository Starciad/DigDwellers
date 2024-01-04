using DD.Constants;

using Microsoft.Xna.Framework;

namespace DD.Components.Common
{
    internal sealed class DPhysicsComponent : DComponent
    {
        internal float GravityScale { get; set; }
        internal float Mass { get; set; }
        internal Vector2 TotalForce { get; private set; }
        internal Vector2 Velocity { get; private set; }

        private DTransformComponent _transform;

        protected override void OnAwake()
        {
            base.OnAwake();

            this._transform = this.Entity.ComponentContainer.GetComponent<DTransformComponent>();

            this.GravityScale = 1.0f;
            this.Mass = 1.0f;
            this.TotalForce = Vector2.Zero;
            this.Velocity = Vector2.Zero;
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            // Apply physics calculations using forces and update position and velocity
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Apply gravity
            Vector2 gravity = new Vector2(DPhysicsConstants.GRAVITY_X, DPhysicsConstants.GRAVITY_Y) * this.GravityScale * this.Mass;
            AddForce(gravity);

            // Update velocity based on applied forces
            Vector2 acceleration = this.TotalForce / this.Mass;
            this.Velocity += acceleration * deltaTime;

            // Update position based on velocity
            this._transform.Position += Velocity * deltaTime;

            // Reset total force after each physics step
            this.TotalForce = Vector2.Zero;
        }

        internal void AddForce(Vector2 force)
        {
            this.TotalForce += force;
        }
    }
}