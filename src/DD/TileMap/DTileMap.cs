namespace DD.TileMap
{
    internal sealed class DTileMap
    {
        private readonly DTile[,] tiles;
        private readonly int width;
        private readonly int height;

        internal DTileMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.tiles = new DTile[width, height];
        }
    }
}
