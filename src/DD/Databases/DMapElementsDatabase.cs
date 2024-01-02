using DD.Enums;
using DD.Map.Elements;
using DD.Objects;

namespace DD.Databases
{
    internal sealed class DMapElementsDatabase : DGameObject
    {
        private DBlock[] blocks;

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
            ];
        }

        internal DBlock GetBlock(DBlockType blockType)
        {
            return blocks[(sbyte)blockType];
        }
    }
}
