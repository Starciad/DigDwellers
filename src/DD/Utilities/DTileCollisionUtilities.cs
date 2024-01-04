using DD.Constants;
using DD.Enums;

using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace DD.Utilities
{
    internal static class DTileCollisionUtilities
    {
        internal static IReadOnlyDictionary<DCardinalDirection, Vector2> CardinalDirections => cardinalDirections;

        private static readonly Dictionary<DCardinalDirection, Vector2> cardinalDirections = new()
        {
            [DCardinalDirection.Center] = Vector2.Zero,
            [DCardinalDirection.North] = new(0,  DTileCollisionConstants.Range),
            [DCardinalDirection.South] = new(0, -DTileCollisionConstants.Range),
            [DCardinalDirection.East]  = new( DTileCollisionConstants.Range, 0),
            [DCardinalDirection.West]  = new(-DTileCollisionConstants.Range, 0),
            [DCardinalDirection.Northeast] = new( DTileCollisionConstants.Range, DTileCollisionConstants.Range),
            [DCardinalDirection.Northwest] = new(-DTileCollisionConstants.Range, DTileCollisionConstants.Range),
            [DCardinalDirection.Southeast] = new( DTileCollisionConstants.Range, DTileCollisionConstants.Range),
            [DCardinalDirection.Southwest] = new(-DTileCollisionConstants.Range, DTileCollisionConstants.Range),
        };
    }
}
