using DD.Map.Enums;

using System;

namespace DD.TileMap
{
    internal sealed class DTileMap
    {
        internal int Width => this.width;
        internal int Height => this.height;

        private readonly DTile[,] tiles;
        private readonly int width;
        private readonly int height;

        internal DTileMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.tiles = new DTile[width, height];
        }

        internal void Fill(DBlockType blockType)
        {
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    SetBlockType(blockType, x, y);
                }
            }
        }

        internal bool IsEmpty(int x, int y)
        {
            return this.tiles[x, y].IsEmpty;
        }

        internal void SetBlockType(DBlockType type, int x, int y)
        {
            this.tiles[x, y].SetBlock(type);
        }
        internal void SetBgoType(DBgoType type, int x, int y)
        {
            this.tiles[x, y].SetBgo(type);
        }

        internal DBlockType GetBlockType(int x, int y)
        {
            (int, int) pos = Clamp(x, y);
            return this.tiles[pos.Item1, pos.Item2].GetBlock();
        }
        internal DBgoType GetBgoType(int x, int y)
        {
            (int, int) pos = Clamp(x, y);
            return this.tiles[pos.Item1, pos.Item2].GetBgo();
        }

        internal void Clear()
        {
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    this.tiles[x, y].Clear();
                }
            }
        }

        internal (int, int) Clamp(int x, int y)
        {
            int posX = Math.Clamp(x, 0, this.width - 1);
            int posY = Math.Clamp(y, 0, this.height - 1);

            return (posX, posY);
        }
    }
}
