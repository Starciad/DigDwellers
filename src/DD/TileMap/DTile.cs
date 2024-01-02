using DD.Enums;

namespace DD.TileMap
{
    internal struct DTile
    {
        private DBlockType blockType;

        public DTile()
        {
            blockType = DBlockType.Empty;
        }

        internal void SetBlock(DBlockType blockType)
        {
            this.blockType = blockType;
        }
    }
}
