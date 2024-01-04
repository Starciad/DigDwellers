using DD.Constants;

using Microsoft.Xna.Framework;

namespace DD.Components.Common
{
    internal sealed class DPhysicsComponent : DComponent
    {
        internal float GravityScale { get; set; } = 1.0f;
        internal float Mass { get; set; } = 1.0f;
        internal Vector2 TotalForce { get; private set; } = Vector2.Zero;
        internal Vector2 Velocity { get; private set; } = Vector2.Zero;

        private DTransformComponent _transform;

        public override void Reset()
        {
            base.Reset();

            this.GravityScale = 1.0f;
            this.Mass = 1.0f;
            this.TotalForce = Vector2.Zero;
            this.Velocity = Vector2.Zero;
        }

        protected override void OnAwake()
        {
            base.OnAwake();

            this._transform = this.Entity.ComponentContainer.GetComponent<DTransformComponent>();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 gravity = new Vector2(DPhysicsConstants.GRAVITY_X, DPhysicsConstants.GRAVITY_Y) * this.GravityScale * this.Mass;
            AddForce(gravity);

            // Update velocity based on applied forces
            Vector2 acceleration = this.TotalForce / this.Mass;
            this.Velocity += acceleration * deltaTime;

            // Update position based on velocity
            this._transform.MoveRelative(Velocity * deltaTime);

            // Reset total force after each physics step
            this.TotalForce = Vector2.Zero;
        }

        internal void AddForce(Vector2 force)
        {
            this.TotalForce += force;
        }
    }
}