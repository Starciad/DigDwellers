using DD.Constants;
using DD.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Reflection;

namespace DD
{
    internal class DGame : Game
    {
        public DComponentManager ComponentManager => this._componentManager;

        // ================================= //

        private readonly Assembly _assembly;
        private SpriteBatch _sb;
        private readonly DGraphicsManager _graphicsManager;
        private readonly DComponentManager _componentManager;

        // ================================= //

        internal DGame()
        {
            // Initialize the game's graphics.
            _graphicsManager = new(new(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = DScreenConstants.SCREEN_WIDTH,
                PreferredBackBufferHeight = DScreenConstants.SCREEN_HEIGHT,
                SynchronizeWithVerticalRetrace = false,
            });

            // Initialize Content
            this.Content.RootDirectory = DDirectoryConstants.ASSETS_DIRECTORY;

            // Set the Assembly reference
            this._assembly = typeof(DGame).Assembly;

            // Configure the game's window
            this.Window.Title = DGameConstants.GetTitleAndVersionString();
            this.Window.AllowUserResizing = false;
            this.Window.IsBorderless = false;

            // Configure game settings
            this.IsMouseVisible = true;
            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = DGraphicsConstants.FramesPerSecond;

            // Managers
            this._componentManager = new();
        }

        protected override void Initialize()
        {
            this._graphicsManager.SetGameInstance(this);
            this._componentManager.SetGameInstance(this);

            this._graphicsManager.Initialize();
            this._componentManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this._sb = new(this.GraphicsDevice);
            base.LoadContent();
        }

        protected override void BeginRun()
        {
            base.BeginRun();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            #region RENDERING (ELEMENTS)
            // UI
            GraphicsDevice.SetRenderTarget(this._graphicsManager.UIRenderTarget);
            GraphicsDevice.Clear(Color.Black);
            this._sb.Begin();
            this._sb.End();

            // HUD
            GraphicsDevice.SetRenderTarget(this._graphicsManager.HUDRenderTarget);
            GraphicsDevice.Clear(Color.Black);
            this._sb.Begin();
            this._sb.End();

            // VIEW
            GraphicsDevice.SetRenderTarget(this._graphicsManager.ViewRenderTarget);
            GraphicsDevice.Clear(Color.Black);
            this._sb.Begin();
            this._sb.End();
            #endregion

            #region RENDERING (SCREEN)
            GraphicsDevice.SetRenderTarget(this._graphicsManager.ScreenRenderTarget);
            GraphicsDevice.Clear(Color.Black);
            this._sb.Begin();
            this._sb.Draw(this._graphicsManager.HUDRenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            this._sb.Draw(this._graphicsManager.ViewRenderTarget, new Vector2(0, DScreenConstants.HUD_HEIGHT + 1), null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            this._sb.Draw(this._graphicsManager.UIRenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            this._sb.End();
            #endregion

            #region RENDERING (FINAL)
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            this._sb.Begin();
            this._sb.Draw(this._graphicsManager.ScreenRenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            this._sb.End();
            #endregion

            base.Draw(gameTime);
        }
    }
}
