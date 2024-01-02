using DD.Enums;
using DD.Map.Elements;
using DD.Objects;

using System.Collections.Generic;

namespace DD.Databases
{
    internal sealed class DMapElementsDatabase : DGameObject
    {
        private readonly DBlock[] blocks =
        [
            new(DBlockType.Empty, 0),
            new(DBlockType.Dirt, 1),
        ];

        internal DBlock GetBlockInfos(DBlockType blockType)
        {
            return blocks[(sbyte)blockType];
        }
    }
}
