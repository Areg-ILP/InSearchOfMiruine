using System;

namespace InSearchOfMiruine.Constants
{
    public class LogFileGenerationCostants
    {
        public const string LOG_FILE_EXTENTION = ".log";
        public const string LOG_FILE_DATE_FORMAT = "yyyyMMdd_HHmmss";
        public const string LOG_FILE_PREFIX = "Res_";

        /// <summary>
        /// Generate file name for logging by requirements.
        /// </summary>
        /// <returns>file name.</returns>
        public static string GenerateLogFileName()
        {
            return LOG_FILE_PREFIX + DateTime.Now.ToString(LOG_FILE_DATE_FORMAT) + LOG_FILE_EXTENTION;
        }
    }
}
