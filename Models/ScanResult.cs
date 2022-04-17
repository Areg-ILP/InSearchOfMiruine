using System.Collections.Generic;

namespace InSearchOfMiruine.Models
{
    public class ScanResult
    {
        public string DeveloperName => "Areg Gevorgyan";
        public int ProccesserFilesCount { get; set; }
        public int  CourruptedFilesCount { get; set; }
        public int ValidStrainsCount { get; set; }
        public HashSet<string> CourruptedFileNames { get; set; }
        public HashSet<string> ValidStrainNumbers { get; set; }
        public double TimeElapsed { get; set; }
    }
}
