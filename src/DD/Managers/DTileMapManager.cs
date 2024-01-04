using DD.Constants;
using DD.Databases;
using DD.Extensions;
using DD.Map.Elements;
using DD.Map.Enums;
using DD.Map.Serialization;
using DD.Objects;
using DD.TileMap;
using DD.Utilities;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace DD.Managers
{
    internal sealed class DTileMapManager : DGameObject
    {
        internal int Width => this.tilemap.Width;
        internal int Height => this.tilemap.Height;

        // TileMap
        private DTileMap tilemap;

        // Database
        private readonly DMapElementsDatabase _mapElementsDatabase;

        // Infos
        private readonly List<(DBlock, Vector2)> activeBlocks = [];
        private readonly List<(DBgo, Vector2)> activeBGOs = [];

        internal DTileMapManager(DMapElementsDatabase mapElementsDatabase)
        {
            this._mapElementsDatabase = mapElementsDatabase;
        }

        // Utilities
        internal void Load(DTileMap tilemap)
        {
            this.tilemap = tilemap;
        }
        internal void Load(DMapxData data)
        {
            this.tilemap = new(DMapConstants.TILEMAP_SIZE_WIDTH, DMapConstants.TILEMAP_SIZE_HEIGHT);

            // LOAD BLOCKS
            if (data.TryGetValue(DMapxConstants.BLOCKS, out sbyte[,] blocks_value))
            {
                blocks_value.IterateThroughArray(new((value, x, y) =>
                {
                    this.tilemap.SetBlockType((DBlockType)value, x, y);
                }));
            }

            // LOAD BGOS
            if (data.TryGetValue(DMapxConstants.BGOS, out sbyte[,] bgos_value))
            {
                bgos_value.IterateThroughArray(new((value, x, y) =>
                {
                    this.tilemap.SetBgoType((DBgoType)value, x, y);
                }));
            }
        }
        internal void Unload()
        {
            this.tilemap.Clear();
        }

        // System
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
                        this.activeBlocks.Add((block, worldPosition));
                    }

                    if (!bgo.IsEmpty)
                    {
                        this.activeBGOs.Add((bgo, worldPosition));
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

        // Utilities
        internal bool IsTileEmpty(int x, int y)
        {
            return this.tilemap.IsEmpty(x, y);
        }

        internal void SetBlockType(DBlockType type, Vector2 position)
        {
            SetBlockType(type, (int)position.X, (int)position.Y);
        }
        internal void SetBgoType(DBgoType type, Vector2 position)
        {
            SetBgoType(type, (int)position.X, (int)position.Y);
        }

        internal DBlockType GetBlockType(Vector2 position)
        {
            return GetBlockType((int)position.X, (int)position.Y);
        }
        internal DBgoType GetBgoType(Vector2 position)
        {
            return GetBgoType((int)position.X, (int)position.Y);
        }

        internal void SetBlockType(DBlockType type, int x, int y)
        {
            this.tilemap.SetBlockType(type, x, y);
        }
        internal void SetBgoType(DBgoType type, int x, int y)
        {
            this.tilemap.SetBgoType(type, x, y);
        }

        internal DBlockType GetBlockType(int x, int y)
        {
            return this.tilemap.GetBlockType(x, y);
        }
        internal DBgoType GetBgoType(int x, int y)
        {
            return this.tilemap.GetBgoType(x, y);
        }
    }
}
