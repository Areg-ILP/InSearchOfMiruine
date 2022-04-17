using InSearchOfMiruine.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //case: contain bad code "553";
            bool badNumberCase = gen.Code.Contains(MiruineProduceGenValidationConstatns.REQURIED_CODE +
                                                   MiruineProduceGenValidationConstatns.REQURIED_TWIX_CODE);
            
            if(!badNumberCase)
            {
                //case: contain required twix code "53"
                bool requiredTwixCodeCase = gen.Code.Contains(MiruineProduceGenValidationConstatns.REQURIED_TWIX_CODE);

                if(requiredTwixCodeCase)
                {
                    var code = gen.Code;
                    var codeWithoutTwix = code.Remove(code.IndexOf(MiruineProduceGenValidationConstatns.REQURIED_TWIX_CODE), 1);
                    
                    //case: contain required code "5" 
                    bool requiredCodeCase = codeWithoutTwix.Contains(MiruineProduceGenValidationConstatns.REQURIED_CODE);
                    if(requiredCodeCase)
                    {
                        var firstCode = int.Parse(gen.Code.First().ToString());
                        var lastCode = int.Parse(gen.Code.Last().ToString());

                        //case: sum of first and last code of gen must be eqaul gen index
                        return firstCode + lastCode <= gen.Index + 1;
                    }
                }
            }

            return false;
        }
    }
}
