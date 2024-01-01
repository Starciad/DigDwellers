using Microsoft.Xna.Framework;

namespace DD.Objects
{
    internal abstract class DObject
    {
        internal void Initialize()
        {
            OnAwake();
            OnStart();
        }
        internal void Update(GameTime gameTime)
        {
            OnUpdate(gameTime);
        }

        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }
        protected virtual void OnUpdate(GameTime gameTime) { }
    }
}
