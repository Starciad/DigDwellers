using DD.Map.Enums;

using Microsoft.Xna.Framework.Graphics;

namespace DD.Map.Elements
{
    internal readonly struct DBlock
    {
        internal readonly bool IsEmpty => this.blockType == DBlockType.Empty;
        internal readonly DBlockType BlockType => this.blockType;
        internal readonly sbyte Tier => this.tier;
        internal readonly Texture2D Texture => this.texture;
        internal readonly bool HasTexture => this.hasTexture;

        private readonly DBlockType blockType;
        private readonly sbyte tier;
        private readonly Texture2D texture;
        private readonly bool hasTexture;

        internal DBlock(DBlockType blockType, sbyte tier, Texture2D texture)
        {
            this.blockType = blockType;
            this.tier = tier;
            this.texture = texture;
            this.hasTexture = texture != null;
        }
    }
}