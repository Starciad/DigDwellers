using System.Collections.Generic;

namespace DD.Collections
{
    /// <summary>
    /// An object pool for managing reusable objects that implement the IPoolableObject interface.
    /// </summary>
    public sealed class DObjectPool
    {
        /// <summary>
        /// Gets the number of objects currently in the pool.
        /// </summary>
        public int Count => this._pool.Count;

        private readonly Queue<IDPoolableObject> _pool = new();

        /// <summary>
        /// Retrieves an object from the pool.
        /// </summary>
        /// <returns>The retrieved object.</returns>
        public IDPoolableObject Get()
        {
            IDPoolableObject value;

            if (this._pool.Count > 0)
            {
                value = this._pool.Dequeue();
                value.Reset();
                return value;
            }

            return default;
        }

        /// <summary>
        /// Adds an object to the pool.
        /// </summary>
        /// <param name="value">The object to add to the pool.</param>
        public void Add(IDPoolableObject value)
        {
            this._pool.Enqueue(value);
        }
    }
}