using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    
    public class ReportLogic
    {

        //------------------ Lim Chang Siang's Code Starts Here---------------------//
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

        //------------------ Lim Chang Siang's Code Ends Here---------------------//



        //----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

        // Retrieving our forecasted data by ItemID
        public static List<ForecastedData> RetrieveForecastedData(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.Database.SqlQuery<ForecastedData>("EXEC [SA45Team12AD].[dbo].[RetrieveLatestForecastData] @ItemID = {0}", itemID).ToList();
            }
        }

        // Here we run our R script to populate our chart
        public static void GetChart(string itemID, DateTime dateFrom, DateTime dateTo, int numPeriods, int typeOfChart)
        {
            // We gotta break down our DateTime objects to two diff variables for each (Season and period)
            int seasonFrom = dateFrom.Year;
            DateTimeFormatInfo dfi1 = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi1.Calendar;
            int periodFrom = cal.GetWeekOfYear(dateFrom, dfi1.CalendarWeekRule, dfi1.FirstDayOfWeek);

            int seasonTo = dateTo.Year;
            DateTimeFormatInfo dfi2 = DateTimeFormatInfo.CurrentInfo;
            Calendar cal2 = dfi2.Calendar;
            int periodTo = cal2.GetWeekOfYear(dateTo, dfi2.CalendarWeekRule, dfi2.FirstDayOfWeek);

            // Modify our .bat file
            String path = "C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/ChartExec.bat";
            using (var stream = new FileStream(path, FileMode.Truncate))   // This ensures that all data inside the file is cleared first before we add new data to it
            {
                using (StreamWriter writetext = new StreamWriter(stream))
                {
                    writetext.WriteLine("@echo off");
                    string temp = "\"C:/Program Files/R/R-3.4.1/bin/x64/Rscript.exe\" \"C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/ChartingTool.R\" ";
                    temp += itemID + " " + seasonFrom + " " + periodFrom + " " + seasonTo + " " + periodTo + " " + numPeriods + " " + typeOfChart;
                    writetext.WriteLine(temp);
                    writetext.WriteLine("exit");     //Initially 'pause'
                }
            }

            // Running our .bat file
            ProcessStartInfo process = new ProcessStartInfo();

            // Running our bat file which will execute the R compiler with the R script
            process.FileName = @"C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/ChartExec.bat";

            // Specify your preferences when running the script
            process.CreateNoWindow = false;
            process.UseShellExecute = false;      //Set 'true' if you want the cmd panel to pop up

            Process.Start(process).WaitForExit();
        }

        // Retrieve latest date from actual data table
        public static bool CheckIfBeyondLatestData(DateTime tempDate)
        {
            using(SA45Team12AD context = new SA45Team12AD())
            {
                ActualData temp = context.Database.SqlQuery<ActualData>("EXEC [SA45Team12AD].[dbo].[LatestActualDataEntry]").First();
                int lSeason = temp.Season;
                int lPeriod = temp.Period;

                // Check if the year selected is more than the latest we have in our db, return false
                if (lSeason < tempDate.Year)
                {
                    return false;
                }
                if (lSeason == tempDate.Year)
                {
                    // Check if the period selected is more than the latest we have in our db, return false
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    Calendar cal = dfi.Calendar;
                    int selectedPeriod = cal.GetWeekOfYear(tempDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    if (lPeriod <= selectedPeriod)
                    {
                        return false;
                    }
                }
                return true;
            }
        }



    }
}