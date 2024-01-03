using DD.Animation.Enums;
using DD.Animation;
using DD.Constants;
using DD.Utilities;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DD.Entities.Common.Player
{
    internal sealed partial class DPlayer
    {
        private void OnAwake_Animation()
        {
            Texture2D mainTexture = this.Game.AssetsDatabase.GetTexture("char_1");
            Point spriteScale = new(DSpritesConstants.SPRITE_DEFAULT_WIDTH, DSpritesConstants.SPRITE_DEFAULT_HEIGHT);

            #region LEFT
            DAnimation al_idle = this._animatorComponent.AddAnimation("IDLE_L");
            DAnimation al_movement = this._animatorComponent.AddAnimation("MOVEMENT_L");
            DAnimation al_jumping = this._animatorComponent.AddAnimation("JUMPING_L");
            DAnimation al_attacking = this._animatorComponent.AddAnimation("ATTACKING_L");

            al_idle.SetTexture(mainTexture);
            al_idle.SetMode(DAnimationMode.Disable);
            al_idle.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 4)));

            al_movement.SetTexture(mainTexture);
            al_movement.SetMode(DAnimationMode.Forward);
            al_movement.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 4)));
            al_movement.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 7)));

            al_jumping.SetTexture(mainTexture);
            al_jumping.SetMode(DAnimationMode.Disable);
            al_jumping.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 7)));

            al_attacking.SetTexture(mainTexture);
            al_attacking.SetMode(DAnimationMode.Once);
            al_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 4)));
            al_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 5)));
            al_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 6)));
            al_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 4)));
            #endregion

            #region RIGHT
            DAnimation ar_idle = this._animatorComponent.AddAnimation("IDLE_R");
            DAnimation ar_movement = this._animatorComponent.AddAnimation("MOVEMENT_R");
            DAnimation ar_jumping = this._animatorComponent.AddAnimation("JUMPING_R");
            DAnimation ar_attacking = this._animatorComponent.AddAnimation("ATTACKING_R");

            ar_idle.SetTexture(mainTexture);
            ar_idle.SetMode(DAnimationMode.Disable);
            ar_idle.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 0)));

            ar_movement.SetTexture(mainTexture);
            ar_movement.SetMode(DAnimationMode.Forward);
            ar_movement.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 0)));
            ar_movement.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 3)));

            ar_jumping.SetTexture(mainTexture);
            ar_jumping.SetMode(DAnimationMode.Disable);
            ar_jumping.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 3)));

            ar_attacking.SetTexture(mainTexture);
            ar_attacking.SetMode(DAnimationMode.Once);
            ar_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 0)));
            ar_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 1)));
            ar_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 2)));
            ar_attacking.AddFrame(DSpriteUtilities.GetSprite(spriteScale, new(0, 0)));
            #endregion

            this._animatorComponent.Play("MOVEMENT_R");
        }
    }
}
