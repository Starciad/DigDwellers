using DD.Components.Common;
using DD.Constants;
using DD.Entities.Common.Player;
using DD.Enums.Game;
using DD.Map.Serialization;
using DD.Objects;
using DD.TileMap;

using Microsoft.Xna.Framework;

using System.Collections.Generic;

namespace DD.Managers
{
    internal class DGameRoutineManager : DGameObject
    {
        internal Color BackgroundColor => this.backgroundColor;

        // Infos
        private DGameState gameState;
        private DGameArea gameArea;

        // Background
        private Color backgroundColor;
        private readonly Dictionary<DGameArea, Color> backgroundColorScheme = new()
        {
            [DGameArea.Lobby] = Color.Cyan,
            [DGameArea.Underground] = Color.Gray,
            [DGameArea.LegendaryCave] = Color.Black
        };

        // Components
        private DGraphicsManager _graphicsManager;
        private DComponentManager _componentManager;
        private DEntityManager _entityManager;
        private DTileMapManager _tileMapManager;
        private DInputManager _inputManager;
        private DMapManager _mapManager;

        // Entities
        private DPlayer _player;
        private DTransformComponent _playerTransformComponent;

        // Maps
        private DMapxData _lobbyTilemap;
        private DMapxData _legendaryCaveTilemap;
        private DMapxData _undergroundHomeTilemap;

        #region SYSTEM
        protected override void OnAwake()
        {
            this.gameArea = DGameArea.Underground;
            this.gameState = DGameState.Activated;

            this._graphicsManager = this.Game.GraphicsManager;
            this._componentManager = this.Game.ComponentManager;
            this._entityManager = this.Game.EntityManager;
            this._tileMapManager = this.Game.TileMapManager;
            this._inputManager = this.Game.InputManager;
            this._mapManager = this.Game.MapManager;

            this._lobbyTilemap = this.Game.AssetsDatabase.GetMapxData("lobby");
            this._legendaryCaveTilemap = this.Game.AssetsDatabase.GetMapxData("legendary_cave");
            this._undergroundHomeTilemap = this.Game.AssetsDatabase.GetMapxData("underground_home");
        }
        internal void BeginRun()
        {
            BuildPlayer();
            LoadGameArea(DGameArea.Underground);
        }
        protected override void OnUpdate(GameTime gameTime)
        {
            UpdateBackgroundColor();
            UpdateArea();
        }
        #endregion

        #region UPDATE (Routine)
        private void UpdateBackgroundColor()
        {
            this.backgroundColor = this.backgroundColorScheme[this.gameArea];
        }
        private void UpdateArea()
        {
            switch (this.gameArea)
            {
                case DGameArea.Lobby:
                    UpdateLobbyArea();
                    return;

                case DGameArea.Underground:
                    UpdateUndergroundArea();
                    return;

                default:
                    return;
            }
        }
        private static void UpdateLobbyArea()
        {
            return;
        }
        private void UpdateUndergroundArea()
        {
            // Checar se o jogador está dentro dos limites da chunk
            // Caso esteja fora, escurecer a camera e carregar a outra chunk
            // Posicionar jogador no local correto
        }
        #endregion

        #region BUILDING
        private void BuildPlayer()
        {
            this._player = this._entityManager.Instantiate<DPlayer>();
            this._playerTransformComponent = this._player.ComponentContainer.GetComponent<DTransformComponent>();
        }
        #endregion

        #region UTILITIES
        private void LoadGameArea(DGameArea area)
        {
            switch (area)
            {
                case DGameArea.Lobby:
                    this._tileMapManager.Load(this._lobbyTilemap);
                    this._playerTransformComponent.SetPosition(new(DScreenConstants.VIEW_WIDTH / 2, DScreenConstants.VIEW_HEIGHT / 2));
                    break;

                case DGameArea.Underground:
                    this._tileMapManager.Load(this._undergroundHomeTilemap);
                    this._playerTransformComponent.SetPosition(new(DScreenConstants.VIEW_WIDTH / 2, 0));
                    break;

                case DGameArea.LegendaryCave:
                    this._tileMapManager.Load(this._legendaryCaveTilemap);
                    this._playerTransformComponent.SetPosition(new(DScreenConstants.VIEW_WIDTH / 2, DScreenConstants.VIEW_HEIGHT / 2));
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}