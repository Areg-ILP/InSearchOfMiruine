using System.Collections.Generic;

namespace InSearchOfMiruine.Models
{
    public class StrainModel
    {
        /// <summary>
        /// Name of file where strain stored.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Number of strain (get from file name).
        /// </summary>
        public string StrainNumber { get; set; }
        /// <summary>
        /// Genetic codes of strain.
        /// </summary>
        public List<string> GeneticCodes { get; set; }
        /// <summary>
        /// Validation flag for strain.
        /// </summary>
        public bool IsValid { get; set; }
    }
}
