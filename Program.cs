using System;
using InSearchOfMiruine.FIleManagement;
using InSearchOfMiruine.Logging;

namespace InSearchOfMiruine
{
    class Program
    {
        /// <summary>
        /// Тhis code was hidden from the government. 
        /// but we managed somehow and were able to send it via a secure line.
        /// Vormzdegh helped us with this.
        /// Thank you for lessons!
        /// </summary>
        static void Main(string[] args)
        {
            try
            {                
                var scanResult = BactFilesScanMigration.Run();
                LogMaster.Info(scanResult);
            }
            catch(Exception ex)
            {
                LogMaster.Error(ex.Message);
            } 
        }
    }
}
