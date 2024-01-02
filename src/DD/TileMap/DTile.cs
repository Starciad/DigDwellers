using DD.Enums;

namespace DD.TileMap
{
    internal struct DTile
    {
        internal readonly bool IsEmpty => this.blockType == DBlockType.Empty &&
                                          this.bgoType == DBgoType.Empty;

        private DBlockType blockType;
        private DBgoType bgoType;

        public DTile()
        {
            this.blockType = DBlockType.Empty;
            this.bgoType = DBgoType.Empty;
        }

        internal void SetBlock(DBlockType blockType)
        {
            this.blockType = blockType;
        }
        internal void SetBgo(DBgoType bgoType)
        {
            this.bgoType = bgoType;
        }

        internal readonly DBlockType GetBlock()
        {
            return this.blockType;
        }
        internal readonly DBgoType GetBgo()
        {
            return this.bgoType;
        }

        internal void Clear()
        {
            this.blockType = DBlockType.Empty;
            this.bgoType = DBgoType.Empty;
        }
    }
}
