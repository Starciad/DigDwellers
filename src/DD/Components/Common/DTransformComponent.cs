using Microsoft.Xna.Framework;

namespace DD.Components.Common
{
    internal sealed class DTransformComponent : DComponent
    {
        internal Vector2 Position { get; set; } = Vector2.Zero;
        internal Vector2 Scale { get; set; } = Vector2.One;
        internal float Rotation { get; set; } = 0f;

        public override void Reset()
        {
            base.Reset();
            this.Position = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Rotation = 0f;
        }

        internal void SetPosition(Vector2 newPosition)
        {
            this.Position = newPosition;
        }

        internal void SetRotation(float angleInRadians)
        {
            this.Rotation = angleInRadians;
        }

        internal void MoveRelative(Vector2 offset)
        {
            this.Position += offset;
        }

        internal void Resize(Vector2 newScale)
        {
            this.Scale = newScale;
        }

        internal void Rotate(float angleInRadians)
        {
            this.Rotation += angleInRadians;
        }
    }
}