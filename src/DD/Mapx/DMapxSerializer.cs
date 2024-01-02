using DD.Constants;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace DD.Mapx
{
    internal static class DMapxSerializer
    {
        private const int WIDTH = DWorldConstants.CHUNK_WIDTH;
        private const int HEIGHT = DWorldConstants.CHUNK_HEIGHT;

        private const string TAG_START_CHARACTER = "[";
        private const string TAG_END_OPENING = "_OPEN]";
        private const string TAG_END_CLOSURE = "_CLOSE]";
        private const string OPENING_VALUES_LINES_CHARACTER = "+";
        private const string VALUE_SEPARATION_CHARACTER = ";";

        internal static DMapxData Deserialize(string filename)
        {
            DMapxData mapData = new();

            string[] lines = File.ReadAllLines(filename).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            bool isOpeningTagStarted = false;
            ReadOnlySpan<char> currentTag = string.Empty;
            List<sbyte[]> numericValues = [];

            for (int i = 0; i < lines.Length; i++)
            {
                ReadOnlySpan<char> line = lines[i];

                // If there is an opening tag, the deserialization processes will begin.
                if (!isOpeningTagStarted && line.StartsWith(TAG_START_CHARACTER) && line.EndsWith(TAG_END_OPENING))
                {
                    isOpeningTagStarted = true;
                    currentTag = line[1..^6];
                    numericValues.Clear();
                }
                // If the line starts with the character +, add all respective values to the list.
                else if (isOpeningTagStarted && line.StartsWith(OPENING_VALUES_LINES_CHARACTER))
                {
                    string[] s_values = line.TrimStart(OPENING_VALUES_LINES_CHARACTER).ToString().Split(VALUE_SEPARATION_CHARACTER, StringSplitOptions.RemoveEmptyEntries);
                    sbyte[] values = Array.ConvertAll(s_values, Convert.ToSByte);

                    if (values.Length == WIDTH)
                    {
                        numericValues.Add(values);
                    }
                    else
                    {
                        throw new InvalidDataException($"The values for the '{currentTag}' tag do not match the expected dimensions.");
                    }
                }
                // If there is a close/thermal tag on this line, complete the final operations.
                else if (isOpeningTagStarted && line.StartsWith(TAG_START_CHARACTER) && line.EndsWith(TAG_END_CLOSURE) && numericValues.Count == HEIGHT)
                {
                    isOpeningTagStarted = false;

                    sbyte[,] matrix = new sbyte[WIDTH, HEIGHT];
                    for (int y = 0; y < HEIGHT; y++)
                    {
                        for (int x = 0; x < WIDTH; x++)
                        {
                            // The numeric values have the X and Y inverted because the first column is the vertical position while the second is the horizontal.
                            matrix[x, y] = numericValues[y][x];
                        }
                    }

                    mapData.AddValue(currentTag.ToString(), matrix);
                }
            }

            return mapData;
        }
    }
}
