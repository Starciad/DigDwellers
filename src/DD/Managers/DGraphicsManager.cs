using DD.Constants;
using DD.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DD.Managers
{
    internal sealed class DGraphicsManager : DGameObject
    {
        internal GraphicsDeviceManager GraphicsDeviceManager => this._gdm;
        internal GraphicsDevice GraphicsDevice => this._gdm.GraphicsDevice;

        public RenderTarget2D ScreenRenderTarget => this.screenRenderTarget;
        public RenderTarget2D UIRenderTarget => this.uiRenderTarget;
        public RenderTarget2D HUDRenderTarget => this.hudRenderTarget;
        public RenderTarget2D SceneRenderTarget => this.sceneRenderTarget;

        private readonly GraphicsDeviceManager _gdm;
        private RenderTarget2D screenRenderTarget;
        private RenderTarget2D uiRenderTarget;
        private RenderTarget2D hudRenderTarget;
        private RenderTarget2D sceneRenderTarget;

        internal DGraphicsManager(GraphicsDeviceManager gdm)
        {
            this._gdm = gdm;
        }

        protected override void OnAwake()
        {
            this.screenRenderTarget = new(this.GraphicsDevice, DScreenConstants.SCREEN_WIDTH, DScreenConstants.SCREEN_HEIGHT);
            this.uiRenderTarget = new(this.GraphicsDevice, DScreenConstants.SCREEN_WIDTH, DScreenConstants.SCREEN_HEIGHT);
            this.hudRenderTarget = new(this.GraphicsDevice, DScreenConstants.HUD_WIDTH, DScreenConstants.HUD_HEIGHT);
            this.sceneRenderTarget = new(this.GraphicsDevice, DScreenConstants.VIEW_WIDTH, DScreenConstants.VIEW_HEIGHT);
        }
    }
}
