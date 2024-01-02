using DD.Enums;

namespace DD.TileMap
{
    internal struct DTile
    {
        private DBlockType blockType;

        public DTile()
        {
            this.blockType = DBlockType.Empty;
        }

        internal void SetBlock(DBlockType blockType)
        {
            this.blockType = blockType;
        }

        internal readonly DBlockType GetBlock()
        {
            return this.blockType;
        }

        internal void Clear()
        {
            this.blockType = DBlockType.Empty;
        }
    }
}
