using DD.Enums;

using Microsoft.Xna.Framework.Graphics;

namespace DD.Map.Elements
{
    internal readonly struct DBgo
    {
        internal readonly bool IsEmpty => this.bgoType == DBgoType.Empty;
        internal readonly DBgoType BgoType => this.bgoType;
        internal readonly Texture2D Texture => this.texture;
        internal readonly bool HasTexture => this.hasTexture;

        private readonly DBgoType bgoType;
        private readonly Texture2D texture;
        private readonly bool hasTexture;

        internal DBgo(DBgoType bgoType, Texture2D texture)
        {
            this.bgoType = bgoType;
            this.texture = texture;
            this.hasTexture = texture != null;
        }
    }
}
