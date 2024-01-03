using DD.Animation;
using DD.Animation.Enums;

using Microsoft.Xna.Framework;

using System.Collections.Generic;

namespace DD.Components.Common
{
    internal sealed class DAnimatorComponent : DComponent
    {
        internal string CurrentAnimationName => this.currentAnimationName;
        internal DAnimation CurrentAnimation => this.currentAnimation;

        private readonly Dictionary<string, DAnimation> animations = [];

        private string currentAnimationName = string.Empty;
        private DAnimation currentAnimation = null;

        private DDrawComponent _drawComponent;

        public override void Reset()
        {
            base.Reset();

            this.animations.Clear();

            this.currentAnimationName = string.Empty;
            this.currentAnimation = null;
        }
        protected override void OnAwake()
        {
            base.OnAwake();

            this.Entity.ComponentContainer.TryGetComponent(out _drawComponent);
        }
        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            if (string.IsNullOrEmpty(this.currentAnimationName))
            {
                return;
            }

            this._drawComponent.SetTexture(this.currentAnimation.Texture);
            this._drawComponent.SetSourceRectangle(this.currentAnimation.SourceFrame);

            this.currentAnimation.Update();
        }

        internal DAnimation AddAnimation(string name)
        {
            DAnimation anim = new();
            this.animations.Add(name, anim);

            return anim;
        }
        internal DAnimation GetAnimation(string name)
        {
            return animations[name];
        }
        internal void RemoveAnimation(string name)
        {
            _ = this.animations.Remove(name);
        }

        internal void Play(string name)
        {
            if (this.currentAnimationName.Equals(name))
            {
                return;
            }

            if (animations.TryGetValue(name, out DAnimation animation))
            {
                animation.Reset();
                animation.SetMode(DAnimationMode.Forward);

                this.currentAnimation = animation;
                this.currentAnimationName = name;
            }
        }
        internal void Stop()
        {
            if (string.IsNullOrEmpty(this.currentAnimationName))
            {
                return;
            }

            this.currentAnimation = null;
            this.currentAnimationName = string.Empty;

            this.currentAnimation.Reset();
        }
        internal void Pause()
        {
            if (string.IsNullOrEmpty(this.currentAnimationName))
            {
                return;
            }

            this.currentAnimation.Pause();
        }
        internal void Resume()
        {
            if (string.IsNullOrEmpty(this.currentAnimationName))
            {
                return;
            }

            this.currentAnimation.Resume();
        }
    }
}
