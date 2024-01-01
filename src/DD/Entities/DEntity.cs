using DD.Collections;
using DD.Components;
using DD.Objects;

using Microsoft.Xna.Framework;

namespace DD.Entities
{
    internal abstract class DEntity : DGameObject, IDPoolableObject
    {
        internal string Name { get; set; }
        internal int Id { get; set; }
        internal DComponentContainer ComponentContainer => this.componentContainer;

        private readonly DComponentContainer componentContainer = new();

        internal override void SetGameInstance(DGame game)
        {
            base.SetGameInstance(game);
            this.componentContainer.SetGameInstance(game);
            this.componentContainer.SetEntityInstance(this);
        }

        protected override void OnStart()
        {
            this.componentContainer.Initialize();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            this.componentContainer.Update(gameTime);
        }

        public virtual void Reset()
        {
            this.componentContainer.Reset();
        }
    }
}
