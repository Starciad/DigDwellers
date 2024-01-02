using DD.Enums;

namespace DD.Map.Elements
{
    internal readonly struct DBlock
    {
        internal readonly DBlockType BlockType => this.blockType;
        internal readonly sbyte Level => this.level;

        private readonly DBlockType blockType;
        private readonly sbyte level;

        internal DBlock(DBlockType blockType, sbyte level)
        {
            this.blockType = blockType;
            this.level = level;
        }
    }
}