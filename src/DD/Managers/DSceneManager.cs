using DD.Constants;
using DD.Map.Serialization;
using DD.Objects;
using DD.TileMap;
using DD.Enums;
using DD.Databases;
using DD.Map.Elements;
using DD.Extensions;
using DD.Utilities;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace DD.Managers
{
    internal sealed class DSceneManager : DGameObject
    {
        // TileMap
        private readonly DTileMap tilemap;

        // Database
        private readonly DMapElementsDatabase _mapElementsDatabase;

        // Infos
        private readonly List<(DBlock, Vector2)> activeBlocks = [];
        private readonly List<(DBgo, Vector2)> activeBGOs = [];

        internal DSceneManager(DMapElementsDatabase mapElementsDatabase)
        {
            this.tilemap = new(DMapConstants.TILEMAP_SIZE_WIDTH, DMapConstants.TILEMAP_SIZE_HEIGHT);
            this._mapElementsDatabase = mapElementsDatabase;
        }
        protected override void OnDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            SearchActiveElements();
            DrawActiveElements(spriteBatch);
        }

        private void SearchActiveElements()
        {
            this.activeBlocks.Clear();
            this.activeBGOs.Clear();

            // Search for all active elements on the map.
            for (int y = this.tilemap.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < this.tilemap.Width; x++)
                {
                    if (this.tilemap.IsEmpty(x, y))
                    {
                        continue;
                    }

                    DBlock block = this._mapElementsDatabase.GetBlock(this.tilemap.GetBlockType(x, y));
                    DBgo bgo = this._mapElementsDatabase.GetBgo(this.tilemap.GetBgoType(x, y));

                    Vector2 worldPosition = DTileMapUtilities.ToWorldPosition(x, y);

                    if (!block.IsEmpty)
                    {
                        activeBlocks.Add((block, worldPosition));
                    }

                    if (!bgo.IsEmpty)
                    {
                        activeBGOs.Add((bgo, worldPosition));
                    }
                }
            }
        }
        private void DrawActiveElements(SpriteBatch spriteBatch)
        {
            (DBlock, Vector2)[] activeBlocksArray = [.. this.activeBlocks];
            (DBgo, Vector2)[] activeBgosArray = [.. this.activeBGOs];

            int activeBlocksLength = activeBlocksArray.Length;
            int activeBgosLength = activeBgosArray.Length;

            (DBlock, Vector2) blockInfo;
            (DBgo, Vector2) bgoInfo;

            // Draw all elements neatly.
            // Blocks
            for (int i = 0; i < activeBlocksLength; i++)
            {
                blockInfo = activeBlocksArray[i];
                spriteBatch.Draw(blockInfo.Item1.Texture, blockInfo.Item2, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            }

            // BGOs
            for (int i = 0; i < activeBgosLength; i++)
            {
                bgoInfo = activeBgosArray[i];
                spriteBatch.Draw(bgoInfo.Item1.Texture, bgoInfo.Item2, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            }
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

            // LOAD BGOS
            if (data.TryGetValue(DMapxConstants.BGOS, out sbyte[,] bgos_value))
            {
                bgos_value.IterateThroughArray(new((value, x, y) =>
                {
                    tilemap.SetBgoType((DBgoType)value, x, y);
                }));
            }
        }
        internal void UnloadScene()
        {
            tilemap.Clear();
        }
    }
}
