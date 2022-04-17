using InSearchOfMiruine.Constants;
using InSearchOfMiruine.Models;
using System.IO;

namespace InSearchOfMiruine.Logging
{
    public static class LogMaster
    {
        static LogMaster()
        {
            if(!Directory.Exists(FoldersPathConstants.LOGS_FOLDER_PATH))
            {
                Directory.CreateDirectory(FoldersPathConstants.LOGS_FOLDER_PATH);
            }
        }

        public static void Info(ScanResult scanResult)
        {
            var path = CreateLogFile();
            string scanInfo = string.Empty;

            scanInfo += $"Dev: {scanResult.DeveloperName}\n";
            scanInfo += $"Processed count: {scanResult.ProcessedFilesCount}\n";
            scanInfo += $"Corrupted count: {scanResult.CorruptedFilesCount}\n";
            scanInfo += $"Found count: {scanResult.ValidStrainsCount}\n\n";

            scanInfo += $"=== Corrupted file names ===\n";
            scanInfo += string.Join("\n", scanResult.CorruptedFileNames);
            scanInfo += $"\n=== Valid file names ===\n";
            scanInfo += string.Join("\n", scanResult.ValidStrainNumbers);
            scanInfo += $"\n\nTime elapsed: {scanResult.TimeElapsed}";

            File.WriteAllText(path, scanInfo);
        }

        public static void Error(string exMessage)
        {
            var path = CreateLogFile();
            File.WriteAllText(path, exMessage);
        }

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
