using DD.Enums;
using DD.Map.Enums;

using Microsoft.Xna.Framework;

namespace DD.Collision.Info
{
    internal struct DTileCollisionInfo
    {
        internal DCardinalDirection Direction { get; set; }
        internal Vector2 Position { get; set; }
        internal DBlockType BlockType { get; set; }
    }
}
