using DD.Constants;
using DD.Entities.Common.Player;
using DD.Objects;

namespace DD.Managers
{
    internal class DGameRoutineManager : DGameObject
    {
        private DGraphicsManager _graphicsManager;
        private DComponentManager _componentManager;
        private DEntityManager _entityManager;
        private DTileMapManager _tileMapManager;
        private DInputManager _inputManager;
        private DMapManager _mapManager;

        protected override void OnAwake()
        {
            this._graphicsManager = this.Game.GraphicsManager;
            this._componentManager = this.Game.ComponentManager;
            this._entityManager = this.Game.EntityManager;
            this._tileMapManager = this.Game.TileMapManager;
            this._inputManager = this.Game.InputManager;
            this._mapManager = this.Game.MapManager;
        }
        internal void BeginRun()
        {
            _ = this._entityManager.Instantiate<DPlayer>(new(DScreenConstants.VIEW_WIDTH / 2, DScreenConstants.VIEW_HEIGHT / 2));
            this._tileMapManager.Load(this._mapManager.GetChunk(0, 0));
        }
    }
}
