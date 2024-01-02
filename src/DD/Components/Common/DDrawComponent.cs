using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DD.Components.Common
{
    internal sealed class DDrawComponent : DComponent
    {
        internal Texture2D Texture { get; private set; }
        internal Rectangle SourceRectangle { get; private set; }
        internal Vector2 Position { get; private set; }
        internal Vector2 Scale { get; private set; }
        internal float Rotation { get; private set; }
        internal Color Color { get; private set; }
        internal Vector2 Origin { get; private set; }
        internal SpriteEffects SpriteEffects { get; private set; }
        internal float LayerDepth { get; private set; }

        private DTransformComponent _transformComponent;

        public override void Reset()
        {
            base.Reset();
            this.Texture = null;
            this.SourceRectangle = Rectangle.Empty;
            this.Position = Vector2.Zero;
            this.Scale = Vector2.Zero;
            this.Color = Color.White;
            this.Origin = Vector2.Zero;
            this.SpriteEffects = SpriteEffects.None;
            this.LayerDepth = 0f;
        }
        protected override void OnStart()
        {
            base.OnStart();

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

            spriteBatch.Draw(this.Texture, this.Position, this.SourceRectangle, this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
        }

        internal void SetTexture(Texture2D value)
        {
            this.Texture = value;
        }
        internal void SetSourceRectangle(Rectangle value)
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
        internal void SetOrigin(Vector2 value)
        {
            this.Origin = value;
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
