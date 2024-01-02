using DD.Constants;
using DD.Map.Serialization;
using DD.Objects;
using DD.TileMap;
using DD.Enums;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DD.Databases;
using DD.Map.Elements;
using DD.Extensions;
using DD.Utilities;
using System.Collections.Generic;

namespace DD.Managers
{
    internal sealed class DSceneManager : DGameObject
    {
        private readonly DTileMap tilemap;

        private DMapElementsDatabase _mapElementsDatabase;

        internal DSceneManager(DMapElementsDatabase mapElementsDatabase)
        {
            this.tilemap = new(DMapConstants.TILEMAP_SIZE_WIDTH, DMapConstants.TILEMAP_SIZE_HEIGHT);
            this._mapElementsDatabase = mapElementsDatabase;
        }

        protected override void OnDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            List<(DBlock, Vector2)> activeBlocks = [];

            // Search for all active elements on the map.
            for (int y = this.tilemap.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < this.tilemap.Width; x++)
                {
                    DBlock block = this._mapElementsDatabase.GetBlock(this.tilemap.GetBlockType(x, y));

                    if (!block.IsEmpty)
                    {
                        activeBlocks.Add((block, DTileMapUtilities.ToWorldPosition(x, y)));
                    }
                }
            }

            // Draw all elements neatly.
            // Blocks.
            foreach ((DBlock, Vector2) blockInfo in activeBlocks)
            {
                spriteBatch.Draw(blockInfo.Item1.Texture, blockInfo.Item2, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            }

            // [...]
        }

        internal void LoadScene(DMapxData data)
        {
            UnloadScene();

            // LOAD BLOCKS
            if (data.TryGetValue(DMapxConstants.BLOCKS, out sbyte[,] blocks_value))
            {
                blocks_value.IterateThroughArray(new((value, x, y) =>
                {
                    tilemap.SetBlockType((DBlockType)value, x, y);
                }));
            }
        }

        internal void UnloadScene()
        {
            tilemap.Clear();
        }
    }
}
