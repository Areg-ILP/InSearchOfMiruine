using InSearchOfMiruine.Constants;
using InSearchOfMiruine.Models;
using System.IO;

namespace InSearchOfMiruine.Logging
{
    public static class LogMaster
    {
        /// <summary>
        /// Init static ctor.
        /// Checks if a directory exists, creates it if it doesn't.
        /// </summary>
        static LogMaster()
        {
            if(!Directory.Exists(FoldersPathConstants.LOGS_FOLDER_PATH))
            {
                Directory.CreateDirectory(FoldersPathConstants.LOGS_FOLDER_PATH);
            }
        }

        /// <summary>
        /// Write scan result in to log file.
        /// </summary>
        /// <param name="scanResult">migration scan result.</param>
        public static void Info(ScanResult scanResult)
        {
            var path = CreateLogFile();
            string scanInfo = string.Empty;

            scanInfo += $"Dev: {scanResult.DeveloperName}\n";
            scanInfo += $"Processed Count: {scanResult.ProcessedFilesCount}\n";
            scanInfo += $"Corrupted Count: {scanResult.CorruptedFileNames.Count}\n";
            scanInfo += $"Found Count: {scanResult.ValidStrainNumbers.Count}\n\n";

            scanInfo += $"=== Corrupted File Names ===\n";
            scanInfo += string.Join("\n", scanResult.CorruptedFileNames);
            scanInfo += $"\n=== Valid Strain Numbers ===\n";
            scanInfo += string.Join("\n", scanResult.ValidStrainNumbers);
            scanInfo += $"\n\nTime Elapsed: {scanResult.TimeElapsed}";

            File.WriteAllText(path, scanInfo);
        }

        /// <summary>
        /// Write error message in to log file.
        /// </summary>
        /// <param name="exMessage">error message.</param>
        public static void Error(string exMessage)
        {
            var path = CreateLogFile();
            File.WriteAllText(path, exMessage);
        }

        /// <summary>
        /// Create new log file.
        /// </summary>
        /// <returns>File path.</returns>
        private static string CreateLogFile()
        {
            var fileName = LogFileGenerationCostants.GenerateLogFileName();
            var path = Path.Combine(FoldersPathConstants.LOGS_FOLDER_PATH, fileName);
            var file = File.Create(path);
            file.Close();

            return path;
        }
    }
}
