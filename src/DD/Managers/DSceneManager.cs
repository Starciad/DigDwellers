using DD.Constants;
using DD.Mapx;
using DD.Objects;
using DD.TileMap;

namespace DD.Managers
{
    internal sealed class DSceneManager : DGameObject
    {
        private readonly DTileMap tilemap;

        internal DSceneManager()
        {
            this.tilemap = new(DMapConstants.TILEMAP_SIZE_WIDTH, DMapConstants.TILEMAP_SIZE_HEIGHT);
        }

        internal void LoadScene(DMapxData data)
        {
            UnloadScene();
        }

        internal void UnloadScene()
        {

        }
    }
}
