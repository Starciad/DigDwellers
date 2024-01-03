using Microsoft.Xna.Framework;

using SharpDX.Direct2D1.Effects;

namespace DD.Utilities
{
    internal static class DSpriteUtilities
    {
        /// <summary>
        /// Get a sprite rectangle with a specified scale and pivot point.
        /// </summary>
        /// <param name="scale">The scale of the sprite.</param>
        /// <param name="pivotX">The X-coordinate of the pivot point.</param>
        /// <param name="pivotY">The Y-coordinate of the pivot point.</param>
        /// <returns>A Rectangle representing the sprite with the specified scale and pivot point.</returns>
        internal static Rectangle GetSprite(int scale, int pivotX, int pivotY)
        {
            return new Rectangle(new Point(pivotX * scale, pivotY * scale), new Point(scale));
        }

        /// <summary>
        /// Get a sprite rectangle with specified X and Y scales and a pivot point.
        /// </summary>
        /// <param name="scaleX">The X-scale of the sprite.</param>
        /// <param name="scaleY">The Y-scale of the sprite.</param>
        /// <param name="pivotX">The X-coordinate of the pivot point.</param>
        /// <param name="pivotY">The Y-coordinate of the pivot point.</param>
        /// <returns>A Rectangle representing the sprite with specified X and Y scales and a pivot point.</returns>
        internal static Rectangle GetSprite(int scaleX, int scaleY, int pivotX, int pivotY)
        {
            return GetSprite(new Point(scaleX, scaleY), new Point(pivotX, pivotY));
        }

        /// <summary>
        /// Get a sprite rectangle with specified X and Y scales and a pivot point.
        /// </summary>
        /// <param name="scale">The scale of the sprite.</param>
        /// <param name="pivot">The coordinate of the pivot point.</param>
        /// <returns>A Rectangle representing the sprite with specified scales and a pivot point.</returns>
        internal static Rectangle GetSprite(Point scale, Point pivot)
        {
            return new Rectangle(new Point(pivot.X * scale.X, pivot.Y * scale.X), scale);
        }
    }
}