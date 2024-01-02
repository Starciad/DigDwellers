using Microsoft.Xna.Framework;

namespace DD.Components.Common
{
    internal sealed class DTransformComponent : DComponent
    {
        internal Vector2 Position { get; set; }
        internal Vector2 Scale { get; set; }
        internal float Rotation { get; set; }

        public override void Reset()
        {
            base.Reset();
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Rotation = 0f;
        }

        internal void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        internal void SetRotation(float angleInRadians)
        {
            Rotation = angleInRadians;
        }

        internal void MoveRelative(Vector2 offset)
        {
            Position += offset;
        }

        internal void Resize(Vector2 newScale)
        {
            Scale = newScale;
        }

        internal void Rotate(float angleInRadians)
        {
            Rotation += angleInRadians;
        }
    }
}