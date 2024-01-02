using DD.Enums;
using DD.Extensions;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DD.Map.Elements
{
    internal readonly struct DBlock
    {
        internal readonly bool IsEmpty => this.blockType == DBlockType.Empty;
        internal readonly DBlockType BlockType => this.blockType;
        internal readonly sbyte Level => this.level;
        internal readonly Texture2D Texture => this.texture;
        internal readonly bool HasTexture => this.hasTexture;

        private readonly DBlockType blockType;
        private readonly sbyte level;
        private readonly Texture2D texture;
        private readonly bool hasTexture;

        internal DBlock(DBlockType blockType, sbyte level, Texture2D texture)
        {
            this.blockType = blockType;
            this.level = level;
            this.texture = texture;
            this.hasTexture = texture != null;
        }
    }
}