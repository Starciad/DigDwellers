namespace DD.Extensions
{
    internal static class Array2DExtensions
    {
        internal delegate void ArrayValueAction<T>(T value, int x, int y);

        internal static void IterateThroughArray<T>(this T[,] array, ArrayValueAction<T> action)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    action.Invoke(array[x, y], x, y);
                }
            }
        }
    }
}
