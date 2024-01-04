using DD.Constants;
using DD.Managers;
using DD.Map.Enums;
using DD.Utilities;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DD.Components.Common.Player
{
    internal sealed class DPlayerControllerComponent : DComponent
    {
        private DInputManager _inputManager;
        private DTileMapManager _tileMapManager;

        private DTransformComponent _transformComponent;

        private readonly Vector2[] directions =
        [
            new(0, -1), // Up
            new(0, 1),  // Down
            new(-1, 0), // Left
            new(1, 0)   // Right
        ];

        private readonly Keys[] keys =
        [
            Keys.Up,
            Keys.Down,
            Keys.Left,
            Keys.Right
        ];

        protected override void OnAwake()
        {
            base.OnAwake();

            this._inputManager = this.Game.InputManager;
            this._tileMapManager = this.Game.TileMapManager;

            this._transformComponent = this.Entity.ComponentContainer.GetComponent<DTransformComponent>();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            UpdateMovement();
        }

        private void UpdateMovement()
        {
            Vector2 gPos = DTileMapUtilities.ToGridPosition(this._transformComponent.Position);

            for (int i = 0; i < this.directions.Length; i++)
            {
                if (this._inputManager.Started(GetKeyForDirection(i)))
                {
                    HandleMovement(gPos + this.directions[i]);
                    break;
                }
            }
        }

        private Keys GetKeyForDirection(int directionIndex)
        {
            return keys[directionIndex];
        }

        private void HandleMovement(Vector2 targetPos)
        {
            DBlockType blockType = this._tileMapManager.GetBlockType(targetPos);

            if (blockType == DBlockType.Empty)
            {
                _transformComponent.SetPosition(DTileMapUtilities.ToWorldPosition(targetPos));
            }
        }
    }
}