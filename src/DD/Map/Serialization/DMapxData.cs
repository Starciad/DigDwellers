using System.Collections.Generic;

namespace DD.Map.Serialization
{
    internal sealed class DMapxData
    {
        private readonly Dictionary<string, sbyte[,]> values = [];

        internal void AddValue(string name, sbyte[,] values)
        {
            _ = this.values.TryAdd(name, values);
        }
    }
}
