﻿using System;
using InSearchOfMiruine.FIleManagement;
using InSearchOfMiruine.Logging;
using InSearchOfMiruine.Models;

namespace InSearchOfMiruine
{
    class Program
    {
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
