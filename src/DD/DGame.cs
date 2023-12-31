﻿using DD.Constants;
using DD.Databases;
using DD.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Reflection;

namespace DD
{
    internal class DGame : Game
    {
        public DGraphicsManager GraphicsManager => this._graphicsManager;
        public DComponentManager ComponentManager => this._componentManager;
        public DEntityManager EntityManager => this._entityManager;
        public DTileMapManager TileMapManager => this._tileMapManager;
        public DInputManager InputManager => this._inputManager;
        public DMapManager MapManager => this._mapManager;

        public DAssetsDatabase AssetsDatabase => this._assetsDatabase;
        public DMapElementsDatabase MapElementsDatabase => this._mapElementsDatabase;

        // ================================= //

        private readonly Assembly _assembly;
        private SpriteBatch _sb;

        private readonly DGraphicsManager _graphicsManager;
        private readonly DComponentManager _componentManager;
        private readonly DEntityManager _entityManager;
        private readonly DTileMapManager _tileMapManager;
        private readonly DInputManager _inputManager;
        private readonly DMapManager _mapManager;
        private readonly DGameRoutineManager _gameRoutineManager;

        private readonly DAssetsDatabase _assetsDatabase;
        private readonly DMapElementsDatabase _mapElementsDatabase;

        // ================================= //

        internal DGame()
        {
            // Initialize the game's graphics.
            this._graphicsManager = new(new(this)
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

            // Database
            this._assetsDatabase = new(this.Content);
            this._mapElementsDatabase = new(this._assetsDatabase);

            // Managers
            this._entityManager = new();
            this._componentManager = new();
            this._tileMapManager = new(this._mapElementsDatabase);
            this._inputManager = new();
            this._mapManager = new();
            this._gameRoutineManager = new();
        }

        protected override void Initialize()
        {
            #region Database
            // Settings
            this._assetsDatabase.SetGameInstance(this);
            this._mapElementsDatabase.SetGameInstance(this);

            // Initialize
            this._assetsDatabase.Initialize();
            this._mapElementsDatabase.Initialize();
            #endregion

            #region Managers
            // Settings
            this._graphicsManager.SetGameInstance(this);
            this._entityManager.SetGameInstance(this);
            this._componentManager.SetGameInstance(this);
            this._tileMapManager.SetGameInstance(this);
            this._inputManager.SetGameInstance(this);
            this._mapManager.SetGameInstance(this);
            this._gameRoutineManager.SetGameInstance(this);

            // Initialize
            this._graphicsManager.Initialize();
            this._entityManager.Initialize();
            this._componentManager.Initialize();
            this._tileMapManager.Initialize();
            this._inputManager.Initialize();
            this._mapManager.Initialize();
            this._gameRoutineManager.Initialize();
            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this._sb = new(this.GraphicsDevice);
            base.LoadContent();
        }

        protected override void BeginRun()
        {
            this._gameRoutineManager.BeginRun();
            base.BeginRun();
        }

        protected override void Update(GameTime gameTime)
        {
            this._gameRoutineManager.Update(gameTime);
            this._inputManager.Update(gameTime);
            this._entityManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            #region RENDERING (ELEMENTS)
            // UI
            this.GraphicsDevice.SetRenderTarget(this._graphicsManager.UIRenderTarget);
            this.GraphicsDevice.Clear(Color.Transparent);
            this._sb.Begin();
            this._sb.End();

            // HUD
            this.GraphicsDevice.SetRenderTarget(this._graphicsManager.HUDRenderTarget);
            this.GraphicsDevice.Clear(Color.Yellow);
            this._sb.Begin();
            this._sb.End();

            // VIEW
            this.GraphicsDevice.SetRenderTarget(this._graphicsManager.ViewRenderTarget);
            this.GraphicsDevice.Clear(this._gameRoutineManager.BackgroundColor);
            this._sb.Begin();
            this._tileMapManager.Draw(this._sb, gameTime);
            this._entityManager.Draw(this._sb, gameTime);
            this._sb.End();
            #endregion

            #region RENDERING (SCREEN)
            this.GraphicsDevice.SetRenderTarget(this._graphicsManager.ScreenRenderTarget);
            this.GraphicsDevice.Clear(Color.Black);
            this._sb.Begin();
            this._sb.Draw(this._graphicsManager.HUDRenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            this._sb.Draw(this._graphicsManager.ViewRenderTarget, new Vector2(0, DScreenConstants.HUD_HEIGHT), null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            this._sb.Draw(this._graphicsManager.UIRenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            this._sb.End();
            #endregion

            #region RENDERING (FINAL)
            Vector2 scaleFactor = new(DScreenConstants.SCALE_FACTOR);

            this.GraphicsDevice.SetRenderTarget(null);
            this.GraphicsDevice.Clear(Color.Black);
            this._sb.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, null);
            this._sb.Draw(this._graphicsManager.ScreenRenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scaleFactor, SpriteEffects.None, 0f);
            this._sb.End();
            #endregion

            base.Draw(gameTime);
        }
    }
}
