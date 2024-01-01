using System;

namespace DD.Constants
{
    internal static class DGameConstants
    {
        internal const string TITLE = "Dig Dwellers";
        internal const string SUBTITLE = "Relic Resurgence";
        internal static Version VERSION = new(1, 0, 0, 0);

        internal static string GetTitleAndVersionString()
        {
            return string.Concat(TITLE, ": ", SUBTITLE, " - ", VERSION);
        }
    }
}
