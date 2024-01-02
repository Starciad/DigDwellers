using System;
using System.Collections.Generic;

namespace DD.Map.Serialization
{
    internal sealed class DMapxData
    {
        private readonly Dictionary<string, sbyte[,]> values = [];

        internal void AddValue(string name, sbyte[,] values)
        {
            _ = TryAddValue(name, values);
        }

        internal sbyte[,] GetValue(string name)
        {
            _ = TryGetValue(name, out sbyte[,] value);
            return value;
        }

        internal bool TryAddValue(string name, sbyte[,] values)
        {
            return this.values.TryAdd(name, values);
        }

        internal bool TryGetValue(string name, out sbyte[,] value)
        {
            if (this.values.TryGetValue(name, out sbyte[,] target))
            {
                value = target;
                return true;
            }

            value = new sbyte[0, 0];
            return false;
        }
    }
}
