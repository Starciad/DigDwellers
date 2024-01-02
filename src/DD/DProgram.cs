using System;

#if !DEBUG
using System.Text;
using System.Windows.Forms;
using DD.IO;
using DD.Constants;
#endif

namespace DD
{
    internal static class DProgram
    {
        [STAThread]
        private static void Main()
        {
#if DEBUG
            EXECUTE_DEBUG_VERSION();
#else
            EXECUTE_PUBLISHED_VERSION();
#endif
        }

#if DEBUG
        private static void EXECUTE_DEBUG_VERSION()
        {
            using DGame game = new();
            game.Run();
        }
#else
        private static void EXECUTE_PUBLISHED_VERSION()
        {
            using Core game = new();

            try
            {
                game.Run();
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            finally
            {
                game.Dispose();
                game.Exit();
            }
        }

        private static void HandleException(Exception value)
        {
            string logFilename = DFile.WriteException(value);
            StringBuilder logString = new();
            logString.AppendLine($"An unexpected error caused {DGameConstants.Title} to crash!");
            logString.AppendLine($"Exception: {value.Message}");
            logString.AppendLine($"Path: {logFilename}");

            MessageBox.Show(logString.ToString(),
                            $"{DGameConstants.Title} - Fatal Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
#endif
    }
}