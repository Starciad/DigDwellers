namespace DD.Objects
{
    internal abstract class DGameObject : DObject
    {
        protected DGame Game { get; private set; }

        internal virtual void SetGameInstance(DGame game)
        {
            this.Game = game;
        }
    }
}
