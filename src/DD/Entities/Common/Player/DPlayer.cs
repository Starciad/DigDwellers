using DD.Components.Common;

namespace DD.Entities.Common.Player
{
    internal sealed class DPlayer : DEntity
    {
        private DDrawComponent _drawComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            this._drawComponent = this.ComponentContainer.AddComponent<DDrawComponent>();
            this._drawComponent.SetTexture(this.Game.AssetsDatabase.GetTexture("char_1"));
        }
    }
}