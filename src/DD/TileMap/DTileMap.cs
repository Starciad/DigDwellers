using DD.Enums;

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

        internal bool IsEmpty(int x, int y)
        {
            return this.tiles[x, y].IsEmpty;
        }

        internal void SetBlockType(DBlockType type, int x, int y)
        {
            this.tiles[x, y].SetBlock(type);
        }
        internal void SetBGOType(DBgoType type, int x, int y)
        {
            this.tiles[x, y].SetBgo(type);
        }

        internal DBlockType GetBlockType(int x, int y)
        {
            return this.tiles[x, y].GetBlock();
        }
        internal DBgoType GetBgoType(int x, int y)
        {
            return this.tiles[x, y].GetBgo();
        }

        internal void Clear()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    this.tiles[x, y].Clear();
                }
            }
        }
    }
}
