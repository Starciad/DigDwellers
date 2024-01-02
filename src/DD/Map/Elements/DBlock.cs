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
        internal readonly Vector2 TextureOrigin => this.textureOrigin;

        private readonly DBlockType blockType;
        private readonly sbyte level;
        private readonly Texture2D texture;
        private readonly Vector2 textureOrigin;
        private readonly bool hasTexture;

        internal DBlock(DBlockType blockType, sbyte level, Texture2D texture)
        {
            this.blockType = blockType;
            this.level = level;
            this.texture = texture;
            this.hasTexture = texture != null;

            if (this.hasTexture)
            {
                this.textureOrigin = this.texture.GetOrigin();
            }
        }
    }
}