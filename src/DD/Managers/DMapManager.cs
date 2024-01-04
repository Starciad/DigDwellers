using DD.Constants;
using DD.Enums.Map;
using DD.Objects;
using DD.TileMap;

using System;

namespace DD.Managers
{
    internal class DMapManager : DGameObject
    {
        private readonly DTileMap[,] chunks = new DTileMap[DMapConstants.WORLD_SIZE_WIDTH, DMapConstants.WORLD_SIZE_HEIGHT];

        protected override void OnAwake()
        {
            base.OnAwake();
            GenerateWorld();
        }

        #region WO0RLD GENERATION (ROUTINE)
        private void GenerateWorld()
        {
            InitializeChunks();
            GenerateChunks();
        }

        private void InitializeChunks()
        {
            for (int y = 0; y < DMapConstants.WORLD_SIZE_HEIGHT; y++)
            {
                for (int x = 0; x < DMapConstants.WORLD_SIZE_WIDTH; x++)
                {
                    SetChunk(new(DMapConstants.TILEMAP_SIZE_WIDTH, DMapConstants.TILEMAP_SIZE_HEIGHT), x, y);
                }
            }
        }

        private void GenerateChunks()
        {
            for (int y = DMapConstants.WORLD_SIZE_HEIGHT - 1; y >= 0; y--)
            {
                for (int x = 0; x < DMapConstants.WORLD_SIZE_WIDTH; x++)
                {
                    DTileMap chunk = GetChunk(x, y);
                    chunk.Fill(DBlockType.Dirt);
                }
            }
        }
        #endregion

        #region UTILITIES
        internal void SetChunk(DTileMap value, int x, int y)
        {
            (int, int) pos = Clamp(x, y);
            this.chunks[pos.Item1, pos.Item2] = value;
        }
        internal DTileMap GetChunk(int x, int y)
        {
            (int, int) pos = Clamp(x, y);
            return this.chunks[pos.Item1, pos.Item2];
        }
        private static (int, int) Clamp(int x, int y)
        {
            int posX = Math.Clamp(x, 0, DMapConstants.WORLD_SIZE_WIDTH);
            int posY = Math.Clamp(y, 0, DMapConstants.WORLD_SIZE_HEIGHT);

            return (posX, posY);
        }
        #endregion
    }
}
