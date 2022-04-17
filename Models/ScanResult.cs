using System;
using System.Collections.Generic;

namespace InSearchOfMiruine.Models
{
    public class ScanResult
    {
        public string DeveloperName => "Areg Gevorgyan";
        /// <summary>
        /// 
        /// </summary>
        public int ProcessedFilesCount { get; set; }
        public int  CorruptedFilesCount { get; set; }
        public int ValidStrainsCount { get; set; }
        public HashSet<string> CorruptedFileNames { get; set; }
        public HashSet<string> ValidStrainNumbers { get; set; }
        public TimeSpan TimeElapsed { get; set; }
    }
}
