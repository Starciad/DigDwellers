namespace DD.Entities.Common.Player
{
    internal sealed class DPlayer : DEntity
    {
        protected override void OnAwake()
        {
            base.OnAwake();

            this.Name = "Player";
        }
    }
}