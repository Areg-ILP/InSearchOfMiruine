using InSearchOfMiruine.Constants;
using System.Collections.Generic;
using System.Linq;

namespace InSearchOfMiruine.Extentions
{
    public static class ExtentionClass
    {
        /// <summary>
        /// Checks if there are three of the same character in the string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <returns>Checking flag</returns>
        public static bool HasAnySymbolThreeTimes(this string source)
        {
            if (source.Length < 3) return false;
            return source.Where((c, i) => i >= 2
                            && source[i - 1] == c
                            && source[i - 2] == c)
                          .Any();
        }

        /// <summary>
        /// Check is given genetic list valid.
        /// </summary>
        /// <param name="geneticList">Source genetic list.</param>
        /// <returns>Validation flag.</returns>
        public static bool IsValidGeneticList(this List<string> geneticList)
        {
            bool isValid = geneticList.Count == GeneticListValidationConstants.LINES_COUNT
                           && !geneticList.Any(l =>
                               l.StartsWith(GeneticListValidationConstants.LINES_NOT_START_WITH_SYMBOL)
                               || l.Length != GeneticListValidationConstants.LINES_LENGTH
                               || l.Any(c => char.IsLetter(c) || char.IsWhiteSpace(c))
                               );
            return isValid;
        }
    }
}
