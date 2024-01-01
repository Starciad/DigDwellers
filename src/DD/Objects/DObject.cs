namespace DD.Objects
{
    internal abstract class DObject
    {
        internal void Initialize()
        {
            OnAwake();
            OnStart();
        }
        internal void Update()
        {
            OnUpdate();
        }

        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }
        protected virtual void OnUpdate() { }
    }
}
