using InSearchOfMiruine.FIleManagement;
using InSearchOfMiruine.Logging;
using InSearchOfMiruine.Models;
using System;
using System.Diagnostics;

namespace InSearchOfMiruine
{
    class Program
    {
        static void Main(string[] args)
        {
            var scanResult = new ScanResult();
            try
            {
                scanResult = BactFilesScanMigration.Run();
            }
            catch(Exception ex)
            {
                LogMaster.Error(ex.Message);
            }
            finally
            {
                LogMaster.Info(scanResult);
            }
        }
    }
}
