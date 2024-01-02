﻿using DD.Constants;

using Microsoft.Xna.Framework;

using System;

namespace DD.Utilities
{
    internal static class DTileMapUtilities
    {
        internal static Vector2 ToGridPosition(float x, float y)
        {
            return ToGridPosition(new Vector2(x, y));
        }
        internal static Vector2 ToGridPosition(int x, int y)
        {
            return ToGridPosition(new Vector2(x, y));
        }
        internal static Vector2 ToGridPosition(Vector2 position)
        {
            int gridX = (int)Math.Round(position.X / DMapConstants.TILE_GRID_SIZE);
            int gridY = (int)Math.Round(position.Y / DMapConstants.TILE_GRID_SIZE);

            return new Vector2(gridX, gridY);
        }

        internal static Vector2 ToWorldPosition(float x, float y)
        {
            return new Vector2(x, y);
        }
        internal static Vector2 ToWorldPosition(int x, int y)
        {
            return new Vector2(x, y);
        }
        internal static Vector2 ToWorldPosition(Vector2 position)
        {
            float worldX = position.X * DMapConstants.TILE_GRID_SIZE;
            float worldY = position.Y * DMapConstants.TILE_GRID_SIZE;

            return new Vector2(worldX, worldY);
        }
    }
}
