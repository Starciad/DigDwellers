using DD.Collision.Info;
using DD.Managers;
using DD.Map.Enums;
using DD.Utilities;

using Microsoft.Xna.Framework;

using System.Collections.Generic;

namespace DD.Components.Common
{
    internal sealed class DTileCollisionComponent : DComponent
    {
        private DTileMapManager _tileMapManager;
        private DTransformComponent _transform;

        internal DTileCollisionInfo[] DetectedCollisions => [.. this.detectedCollisions];

        private readonly Vector2[] CardinalDirections =
        [
            Vector2.Zero,                     // Center
            Vector2.UnitY,                    // North
            -Vector2.UnitY,                   // South
            Vector2.UnitX,                    // East
            -Vector2.UnitX,                   // West
            Vector2.UnitX + Vector2.UnitY,    // Northeast
            -Vector2.UnitX + Vector2.UnitY,   // Northwest
            Vector2.UnitX - Vector2.UnitY,    // Southeast
            -Vector2.UnitX - Vector2.UnitY    // Southwest
        ];

        private readonly List<DTileCollisionInfo> detectedCollisions = [];

        protected override void OnAwake()
        {
            base.OnAwake();

            this._tileMapManager = this.Game.TileMapManager;
            this._transform = this.Entity.ComponentContainer.GetComponent<DTransformComponent>();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            Vector2 gridPosition = DTileMapUtilities.ToGridPosition(this._transform.Position);

            this.detectedCollisions.Clear();
            int length = this.CardinalDirections.Length;

            for (int i = 0; i < length; i++)
            {
                Vector2 targetPosition = gridPosition + this.CardinalDirections[i];
                DBlockType blockType = this._tileMapManager.GetBlockType(targetPosition);

                if (blockType != DBlockType.Empty)
                {
                    this.detectedCollisions.Add(new DTileCollisionInfo
                    {
                        TilePosition = targetPosition,
                        BlockType = blockType
                    });
                }
            }
        }
    }
}