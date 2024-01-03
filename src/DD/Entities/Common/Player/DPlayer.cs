using DD.Animation;
using DD.Animation.Enums;
using DD.Components.Common;
using DD.Constants;
using DD.Utilities;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DD.Entities.Common.Player
{
    internal sealed partial class DPlayer : DEntity
    {
        private DDrawComponent _drawComponent;
        private DAnimatorComponent _animatorComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            // Add
            this._drawComponent = this.ComponentContainer.AddComponent<DDrawComponent>();
            this._animatorComponent = this.ComponentContainer.AddComponent<DAnimatorComponent>();

            // Settings
            OnAwake_Animation();
        }
    }
}