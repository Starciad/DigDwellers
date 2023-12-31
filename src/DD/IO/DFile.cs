﻿using DD.Constants;

using System;
using System.IO;

namespace DD.IO
{
    /// <summary>
    /// Provides utility methods for working with files in the game.
    /// </summary>
    public static class DFile
    {
        /// <summary>
        /// Writes an exception to a log file and returns the full path of the log file.
        /// </summary>
        /// <param name="exception">The exception to be logged.</param>
        /// <returns>The full path of the created log file.</returns>
        public static string WriteException(Exception exception)
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DDirectoryConstants.LOGS_DIRECTORY);
            _ = Directory.CreateDirectory(logDirectory);
            string logFileName = $"DD_Log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
            string logFilePath = Path.Combine(logDirectory, logFileName);
            using (StringWriter stringBuilder = new())
            {
                stringBuilder.WriteLine(exception.ToString());
                System.IO.File.WriteAllText(logFilePath, stringBuilder.ToString());
            }

            return logFilePath;
        }
    }
}
