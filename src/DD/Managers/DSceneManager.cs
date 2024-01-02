using DD.Map.Serialization;
using DD.Objects;

namespace DD.Managers
{
    internal sealed class DSceneManager : DGameObject
    {
        private readonly DEntityManager _entityManager;
        private readonly DTileMapManager _tileMapManager;

        internal DSceneManager(DEntityManager em, DTileMapManager tm)
        {
            this._entityManager = em;
            this._tileMapManager = tm;
        }

        internal void LoadScene(DMapxData data)
        {
            UnloadScene();

            _tileMapManager.Load(data);
            _entityManager.Load(data);
        }
        internal void UnloadScene()
        {
            _tileMapManager.Unload();
            _entityManager.Unload();
        }
    }
}
