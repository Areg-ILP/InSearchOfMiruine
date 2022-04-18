using System;
using System.Collections.Generic;

namespace InSearchOfMiruine.Models
{
    public class ScanResult
    {
        public string DeveloperName => "Areg Gevorgyan";
        /// <summary>
        /// All Processed files count.
        /// </summary>
        public int ProcessedFilesCount { get; set; }
        /// <summary>
        /// Curruppted file names.
        /// </summary>
        public HashSet<string> CorruptedFileNames { get; set; }
        /// <summary>
        /// Valid strain numbers.
        /// </summary>
        public HashSet<int> ValidStrainNumbers { get; set; }
        /// <summary>
        /// Migration Execution time.
        /// </summary>
        public TimeSpan TimeElapsed { get; set; }
    }
}
