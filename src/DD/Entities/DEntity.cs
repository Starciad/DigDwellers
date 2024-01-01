using DD.Components;
using DD.Objects;

namespace DD.Entities
{
    internal abstract class DEntity : DGameObject
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
        protected override void OnUpdate()
        {
            this.componentContainer.Update();
        }
    }
}
