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

        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }
        protected virtual void OnUpdate(GameTime gameTime) { }
        protected virtual void OnDraw(SpriteBatch spriteBatch, GameTime gameTime) { }
    }
}
