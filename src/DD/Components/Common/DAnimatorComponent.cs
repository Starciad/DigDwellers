using DD.Animation;

using Microsoft.Xna.Framework;

namespace DD.Components.Common
{
    internal sealed class DAnimatorComponent : DComponent
    {
        private readonly DAnimation animation = new();

        private DDrawComponent _drawComponent;

        public override void Reset()
        {
            base.Reset();

            this.animation.Reset();
            this.animation.ClearFrames();
        }
        protected override void OnAwake()
        {
            base.OnAwake();

            this.Entity.ComponentContainer.TryGetComponent(out _drawComponent);
        }
        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            if (this.animation == null)
            {
                return;
            }

            this._drawComponent.SetTexture(this.animation.Texture);
            this._drawComponent.SetSourceRectangle(this.animation.SourceFrame);

            this.animation.Update();
        }
    }
}
