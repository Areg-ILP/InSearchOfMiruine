using InSearchOfMiruine.Constants;
using System.Linq;

namespace InSearchOfMiruine.Models
{
    public class GenModel
    {
        /// <summary>
        /// Gen index is line of gen in the file.
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Gen code is line value in the file.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Check if gen valid.
        /// </summary>
        /// <param name="gen">gen model.</param>
        /// <returns>Validation flag.</returns>       
        public static bool IsValidGen(GenModel gen)
        {
            //case: code contain required twix code
            bool requiredTwixCodeCase = gen.Code.Contains(MiruineProduceGenValidationConstatns.REQURIED_TWIX_CODE);

            if (requiredTwixCodeCase)
            {
                var tmpCode = gen.Code;
                var codeWithoutTwixs = tmpCode.Replace(MiruineProduceGenValidationConstatns.REQURIED_TWIX_CODE, string.Empty);

                //case: code dosn't contain twixs but contain required code
                if (codeWithoutTwixs.Contains(MiruineProduceGenValidationConstatns.REQURIED_CODE))
                {
                    var firstCode = int.Parse(gen.Code.First().ToString());
                    var lastCode = int.Parse(gen.Code.Last().ToString());

                    //case: sum of first and last code of gen must be less or eqaul gen index
                    return firstCode + lastCode <= gen.Index + 1;
                }
            }

            return false;
        }
    }
}
