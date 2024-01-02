using Microsoft.Xna.Framework;

namespace DD.Components.Common
{
    internal sealed class DTransformComponent : DComponent
    {
        internal Vector2 Position { get; set; }
        internal Vector2 Scale { get; set; }
        internal float Rotation { get; set; }
    }
}
