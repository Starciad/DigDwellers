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

            this._tileMapManager.Load(data);
            this._entityManager.Load(data);
        }
        internal void UnloadScene()
        {
            this._tileMapManager.Unload();
            this._entityManager.Unload();
        }
    }
}
