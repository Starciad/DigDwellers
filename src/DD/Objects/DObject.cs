using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        internal void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            OnDraw(spriteBatch, gameTime);
        }
        internal void Destroy()
        {
            OnDestroy();
        }

        protected virtual void OnAwake() { return; }
        protected virtual void OnStart() { return; }
        protected virtual void OnUpdate(GameTime gameTime) { return; }
        protected virtual void OnDraw(SpriteBatch spriteBatch, GameTime gameTime) { return; }
        protected virtual void OnDestroy() { return; }
    }
}
