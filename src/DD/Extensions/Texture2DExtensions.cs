using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DD.Extensions
{
    internal static class Texture2DExtensions
    {
        internal static Vector2 GetCenterOrigin(this Texture2D texture)
        {
            return new(texture.Width / 2, texture.Height / 2);
        }
    }
}
