using DD.Extensions;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DD.Components.Common
{
    internal sealed class DDrawComponent : DComponent
    {
        internal Texture2D Texture { get; private set; } = null;
        internal Rectangle? SourceRectangle { get; private set; } = null;
        internal Vector2 Position { get; private set; } = Vector2.Zero;
        internal Vector2 Scale { get; private set; } = Vector2.One;
        internal float Rotation { get; private set; } = 0f;
        internal Color Color { get; private set; } = Color.White;
        internal SpriteEffects SpriteEffects { get; private set; } = SpriteEffects.None;
        internal float LayerDepth { get; private set; } = 0f;

        private DTransformComponent _transformComponent;

        public override void Reset()
        {
            base.Reset();

            this.Texture = null;
            this.SourceRectangle = Rectangle.Empty;
            this.Position = Vector2.Zero;
            this.Scale = Vector2.Zero;
            this.Color = Color.White;
            this.SpriteEffects = SpriteEffects.None;
            this.LayerDepth = 0f;
        }
        protected override void OnAwake()
        {
            base.OnAwake();

            this.Entity.ComponentContainer.TryGetComponent(out _transformComponent);
        }
        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            if (this._transformComponent != null)
            {
                SetPosition(this._transformComponent.Position);
                SetScale(this._transformComponent.Scale);
                SetRotation(this._transformComponent.Rotation);
            }
        }
        protected override void OnDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.OnDraw(spriteBatch, gameTime);

            if (this.Texture == null)
            {
                return;
            }

            spriteBatch.Draw(this.Texture, this.Position, this.SourceRectangle, this.Color, this.Rotation, Vector2.Zero, this.Scale, this.SpriteEffects, this.LayerDepth);
        }

        internal void SetTexture(Texture2D value)
        {
            this.Texture = value;
        }
        internal void SetSourceRectangle(Rectangle? value)
        {
            this.SourceRectangle = value;
        }
        internal void SetPosition(Vector2 value)
        {
            this.Position = value;
        }
        internal void SetScale(Vector2 value)
        {
            this.Scale = value;
        }
        internal void SetRotation(float value)
        {
            this.Rotation = value;
        }
        internal void SetColor(Color value)
        {
            this.Color = value;
        }
        internal void SetSpriteEffects(SpriteEffects value)
        {
            this.SpriteEffects = value;
        }
        internal void SetLayerDepth(float value)
        {
            this.LayerDepth = value;
        }
    }
}