using DD.Collision.Info;
using DD.Constants;
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
            this.detectedCollisions.Clear();

            foreach (var item in DTileCollisionUtilities.CardinalDirections)
            {
                Vector2 gridPosition = DTileMapUtilities.ToGridPosition(this._transform.Position + item.Value);
                DBlockType blockType = this._tileMapManager.GetBlockType(gridPosition);

                if (blockType != DBlockType.Empty)
                {
                    this.detectedCollisions.Add(new DTileCollisionInfo
                    {
                        Direction = item.Key,
                        Position = gridPosition,
                        BlockType = blockType
                    });
                }
            }
        }
    }
}