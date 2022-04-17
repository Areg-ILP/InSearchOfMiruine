using InSearchOfMiruine.Constants;
using InSearchOfMiruine.Extentions;
using InSearchOfMiruine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InSearchOfMiruine.FIleManagement
{
    public static class BactFilesScanMigration
    {
        /// <summary>
        /// Bacts folder path constant value.
        /// </summary>
        private const string BACTS_FOLDER_PATH = "C:\\temp\\Bact\\folder";

        /// <summary>
        /// Strains that have not been validated.
        /// </summary>

        private static HashSet<string> _corruptedStrains;

        /// <summary>
        /// Init static ctor.
        /// Checks if there are files for the given path.
        /// </summary>
        static BactFilesScanMigration()
        {
            if (!Directory.Exists(BACTS_FOLDER_PATH))
            {
                throw new Exception("Bact files not exsit");
            }

            _corruptedStrains = new HashSet<string>();
        }

        /// <summary>
        /// Main method to run migration and scan bact files.
        /// </summary>
        /// <returns>Scan result.</returns>
        public static ScanResult Run()
        {
            var allPaths = Directory.GetFiles(BACTS_FOLDER_PATH);

            var strainsProduceMiruine = allPaths.Where(p => ValidateBactFileForLoad(p))
                                                .Select(s => ValidateAndGetStrain(s))
                                                .Where(s => s.IsValid && CanStrainGensProduceMiruine(s))
                                                .Select(n => n.StrainNumber)
                                                .ToHashSet();
                                     
            return new ScanResult()
            {
                ProccesserFilesCount = allPaths.Length,
                CourruptedFilesCount = _corruptedStrains.Count,
                CourruptedFileNames = _corruptedStrains,
                ValidStrainsCount = strainsProduceMiruine.Count,
                ValidStrainNumbers = strainsProduceMiruine,
            };
        }

        /// <summary>
        /// Check if strain gens can produce miruine.
        /// </summary>
        /// <param name="strain">strain model.</param>
        /// <returns>Validation flag.</returns>
        private static bool CanStrainGensProduceMiruine(StrainModel strain)
        {
            if(strain.GeneticCodes.Any(x => x.HasAnySymbolThreeTimes()))
            {
                _corruptedStrains.Add(strain.FileName);
                return false;
            }

            var genValidationList = Enumerable.Range(0, strain.GeneticCodes.Count)
                                              .Select(x => GenModel.IsValidGen(new GenModel()
                                                          { 
                                                              Index = x,
                                                              Code = strain.GeneticCodes[x]
                                                          }))
                                              .ToList();

            var containConsecutiveValidGens = Enumerable.Range(0, genValidationList.Count)
                                                        .Where((b, i) => i >= 1
                                                            && genValidationList[i]
                                                            && genValidationList[i] == genValidationList[i - 1])
                                                        .Any();

            if(containConsecutiveValidGens)
            {
                _corruptedStrains.Add(strain.FileName);
                return false;
            }

            return genValidationList.Any(f => f);
        }

        /// <summary>
        /// Validate strain and get instance of strain.
        /// </summary>
        /// <param name="path">Strain path.</param>
        /// <returns>StrainModel.</returns>
        private static StrainModel ValidateAndGetStrain(string path)
        {
            var geneticCodes = File.ReadAllLines(path)
                                   .Select(s => s.Trim())
                                   .ToList();

            return new StrainModel()
            {
                StrainNumber = Path.GetFileNameWithoutExtension(path)
                                   .Split("_")
                                   .Last()
                                   .Trim('0'),
                FileName = Path.GetFileName(path),
                IsValid = geneticCodes.IsValidGeneticList(),
                GeneticCodes = geneticCodes
            };
        }

        /// <summary>
        /// Validate file by given path,
        /// if the file does not pass validation,
        /// will be added in corrupted files.
        /// </summary>
        /// <param name="path">File Path.</param>
        /// <returns>Validation flag.</returns>
        private static bool ValidateBactFileForLoad(string path)
        {
            var extention = Path.GetExtension(path);
            var fileName = Path.GetFileNameWithoutExtension(path);

            if (extention == BactFileValidationConstants.BACT_FILE_EXTENTION)
            {
                var splitedResult = fileName.Split("_");
                if (splitedResult.Length == 2)
                {
                    var prefix = splitedResult.First();
                    var strainNumber = splitedResult.Last();

                    if(prefix == BactFileValidationConstants.BACT_FILE_PREFIX
                        && strainNumber.Length == BactFileValidationConstants.BACT_STRAIN_NUMBER_COUNT
                        && !strainNumber.Any(c => char.IsLetter(c)))
                    {
                        return true;
                    }
                }
            }

            _corruptedStrains.Add(Path.GetFileName(path));
            return false;
        }
    }
}
