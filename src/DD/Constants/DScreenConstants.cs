namespace DD.Constants
{
    internal static class DScreenConstants
    {
        // GAME SCREEN
        internal const int SCREEN_WIDTH = DEFAULT_WIDTH * 2;
        internal const int SCREEN_HEIGHT = DEFAULT_HEIGHT * 2;

        // RENDER TARGETS
        internal const int VIEW_WIDTH = DEFAULT_WIDTH;
        internal const int VIEW_HEIGHT = DEFAULT_HEIGHT - HUD_HEIGHT;

        internal const int HUD_WIDTH = DEFAULT_WIDTH;
        internal const int HUD_HEIGHT = DEFAULT_HEIGHT - 48;

        // DEFAULT
        internal const int DEFAULT_WIDTH = 256;
        internal const int DEFAULT_HEIGHT = 240;
    }
}
