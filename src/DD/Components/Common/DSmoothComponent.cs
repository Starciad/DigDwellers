using Microsoft.Xna.Framework;

namespace DD.Components.Common
{
    internal sealed class DSmoothComponent : DComponent
    {
        internal Vector2 Position { get; set; }
        internal float SmoothScale { get; set; }

        private DTransformComponent _transformComponent;

        protected override void OnAwake()
        {
            base.OnAwake();
            this._transformComponent = this.Entity.ComponentContainer.GetComponent<DTransformComponent>();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);
            this._transformComponent.SetPosition(Vector2.Lerp(this._transformComponent.Position, this.Position, this.SmoothScale));
        }

        internal void SetPosition(Vector2 newPosition)
        {
            this.Position = newPosition;
        }
    }
}