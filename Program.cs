using InSearchOfMiruine.FIleManagement;
using InSearchOfMiruine.Models;
using System;
using System.Diagnostics;

namespace InSearchOfMiruine
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            var scanResult = new ScanResult();

            try
            {
                watch.Restart();
                scanResult = BactFilesScanMigration.Run();
            }
            catch(Exception ex)
            {
                //mb log error
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                watch.Stop();
                Console.WriteLine(watch.Elapsed);

                Console.WriteLine($"Dev: {scanResult.DeveloperName}\nAll Files: {scanResult.ProccesserFilesCount}\nCorrupted count: {scanResult.CourruptedFilesCount}\nValid strains count: {scanResult.ValidStrainsCount}");

                Console.WriteLine("Corrupted Names:");
                foreach (var item in scanResult.CourruptedFileNames)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Valid Numbers:");
                foreach (var item in scanResult.ValidStrainNumbers)
                {
                    Console.WriteLine(item);
                }

                //mb log info
            }
        }
    }
}
