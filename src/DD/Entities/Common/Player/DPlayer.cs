using DD.Components.Common;
using DD.Constants;

namespace DD.Entities.Common.Player
{
    internal sealed class DPlayer : DEntity
    {
        private DTransformComponent _transformComponent;
        private DDrawComponent _drawComponent;

        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";

            this._transformComponent = this.ComponentContainer.GetComponent<DTransformComponent>();
            this._drawComponent = this.ComponentContainer.AddComponent<DDrawComponent>();

            this._drawComponent.SetTexture(this.Game.AssetsDatabase.GetTexture("char_1"));
        }
    }
}