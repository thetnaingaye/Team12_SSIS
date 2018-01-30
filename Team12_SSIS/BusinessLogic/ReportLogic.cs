using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    //Chang Siang here...
    public class ReportLogic
    {
        public static DataTable GetPurchaseHistotoryWithCost(DateTime startPeriod, DateTime endPeriod, string itemId,string supplierId)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                SqlParameter startDate = new SqlParameter("@startPeriod", startPeriod);
                SqlParameter endDate = new SqlParameter("@endDate", endPeriod);
                SqlParameter itemCode = new SqlParameter("@itemId", itemId);
                SqlParameter supplierCode = new SqlParameter("@supplierId", supplierId);
                dynamic data = ctx.Database.SqlQuery<SA45Team12ADDataSet>("StoreOrderHistory @startPeriod, @endDate, @ItemId, @supplierId", startDate, endDate, itemCode, supplierCode).SingleAsync();
                DataTable dataTable = Utility.Utility.ToDataTable(data);
                return dataTable;
            }
        }




        //----------------------------         KHAIR's               ----------------------------// 

        // Retrieving our forecasted data by ItemID
        public static List<ForecastedData> RetrieveForecastedData(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.Database.SqlQuery<ForecastedData>("EXEC [SA45Team12AD].[dbo].[RetrieveLatestForecastData] @ItemID = {0}", itemID).ToList();
            }
        }

        // Here we run our R script to populate our chart
        public static void GetChart(string itemID)
        {
            // Modify our .bat file
            String path = "C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/ChartExec.bat";
            using (var stream = new FileStream(path, FileMode.Truncate))   // This ensures that all data inside the file is cleared first before we add new data to it
            {
                using (StreamWriter writetext = new StreamWriter(stream))
                {
                    writetext.WriteLine("@echo off");
                    string temp = "\"C:/Program Files/R/R-3.4.1/bin/x64/Rscript.exe\" \"C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/ChartingTool.R\" ";
                    temp += itemID;
                    writetext.WriteLine(temp);
                    writetext.WriteLine("exit");     //Initially 'pause'
                }
            }

            //// Running our .bat file
            //ProcessStartInfo process = new ProcessStartInfo();
            //Process rScript;

            //// Running our bat file which will execute the R compiler with the R script
            //process.FileName = @"C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/ChartExec.bat";
            //process.Arguments = "/c start /wait";  // Initially not here
            //// Specify your preferences when running the script
            //process.CreateNoWindow = false;
            //process.UseShellExecute = false;      //Set 'true' if you want the cmd panel to pop up


            //rScript = Process.Start(process);
            //rScript.Close();


            // Running our .bat file
            ProcessStartInfo process = new ProcessStartInfo();

            // Running our bat file which will execute the R compiler with the R script
            process.FileName = @"C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/ChartExec.bat";

            // Specify your preferences when running the script
            process.CreateNoWindow = false;
            process.UseShellExecute = false;      //Set 'true' if you want the cmd panel to pop up

            Process.Start(process).WaitForExit();
        }





    }
}