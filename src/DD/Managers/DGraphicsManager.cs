using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using DD.Constants;

namespace DD.Managers
{
    internal sealed class DGraphicsManager
    {
        internal GraphicsDeviceManager GraphicsDeviceManager => this._gdm;
        internal GraphicsDevice GraphicsDevice => this._gdm.GraphicsDevice;

        public RenderTarget2D ScreenRenderTarget => this.screenRenderTarget;
        public RenderTarget2D UIRenderTarget => this.uiRenderTarget;
        public RenderTarget2D HUDRenderTarget => this.hudRenderTarget;
        public RenderTarget2D ViewRenderTarget => this.viewRenderTarget;

        private readonly GraphicsDeviceManager _gdm;
        private RenderTarget2D screenRenderTarget;
        private RenderTarget2D uiRenderTarget;
        private RenderTarget2D hudRenderTarget;
        private RenderTarget2D viewRenderTarget;

        internal DGraphicsManager(GraphicsDeviceManager gdm)
        {
            this._gdm = gdm;
        }

        internal void Initialize()
        {
            this.screenRenderTarget = new(this.GraphicsDevice, DScreenConstants.SCREEN_WIDTH, DScreenConstants.SCREEN_HEIGHT);
            this.uiRenderTarget = new(this.GraphicsDevice, DScreenConstants.SCREEN_WIDTH, DScreenConstants.SCREEN_HEIGHT);
            this.hudRenderTarget = new(this.GraphicsDevice, DScreenConstants.HUD_WIDTH, DScreenConstants.HUD_HEIGHT);
            this.viewRenderTarget = new(this.GraphicsDevice, DScreenConstants.VIEW_WIDTH, DScreenConstants.VIEW_HEIGHT);
        }
    }
}
