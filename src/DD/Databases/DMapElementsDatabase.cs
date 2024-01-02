using DD.Enums;
using DD.Map.Elements;
using DD.Objects;

namespace DD.Databases
{
    internal sealed class DMapElementsDatabase : DGameObject
    {
        private DBlock[] blocks;
        private DBgo[] bgos;

        private readonly DAssetsDatabase _assetsDatabase;

        internal DMapElementsDatabase(DAssetsDatabase assetsDatabase)
        {
            this._assetsDatabase = assetsDatabase;
        }

        protected override void OnAwake()
        {
            this.blocks =
            [
                new(DBlockType.Empty, 0, null),
                new(DBlockType.Dirt, 1, this._assetsDatabase.GetTexture("block_1")),
                new(DBlockType.Plataform, 1, this._assetsDatabase.GetTexture("block_2")),
            ];

            this.bgos =
            [
                new(DBgoType.Empty, null),
                new(DBgoType.White_Square, this._assetsDatabase.GetTexture("bgo_1")),
                new(DBgoType.Grass, this._assetsDatabase.GetTexture("bgo_2")),
            ];
        }

        internal DBlock GetBlock(DBlockType blockType)
        {
            return this.blocks[(sbyte)blockType];
        }

        internal DBgo GetBgo(DBgoType bgoType)
        {
            return this.bgos[(sbyte)bgoType];
        }
    }
}
