using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using Team12_SSIS.Model;

//----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

namespace Team12_SSIS.BusinessLogic
{
    public class AutomationLogic
    {
        
        // Setting automated buffer stock handling  --- Auto is set to 10%
        public static void SetAutomatedlBFS(string itemID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                // Finding the week no for the year (aka our period currently)
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int currentPeriod = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                // Creating our obj from DB
                ForecastedData f = context.ForecastedDatas.Where(x => x.ItemID.Equals(itemID)).Where(y => y.Season == DateTime.Now.Year).Where(z => z.Period == currentPeriod + 1).First();
                InventoryCatalogue i = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();

                // Changing our values
                i.BFSProportion = 10;
                i.BufferStockLevel = Convert.ToInt32(Math.Ceiling((10.0 * Convert.ToDouble(f.High95)) / 100));   // We take high95 cos it possesses the expected Dd with the highest confidence interval determinable (just to be safe)

                context.SaveChanges();
            }
        }

        // End of business day method
        public static void BeginEndOfDayProcesses(object sender, System.Timers.ElapsedEventArgs e)
        {
            // These lines of code will ensure that the reorder table is cleared at the end of each working day (about 6pm).
            DayOfWeek dayTodae = DateTime.Now.DayOfWeek;

            // Start message
            UpdateAutomationLog(DateTime.Now + ": Checking the day.", 1);


            // Checking for the right day aka weekday
            if (!dayTodae.Equals(DayOfWeek.Saturday) || !dayTodae.Equals(DayOfWeek.Sunday))
            {
                UpdateAutomationLog(DateTime.Now + ": EOD processes will begin as today is a weekday.", 1);

                // Init all req attrs
                bool isOverride = false;
                bool rightHour = false;
                bool rightMinute = false;
                bool rightSecond = false;
                int hour;
                int minute;
                int second;
                int targetHour = 17;             // Change this to manually set our hour [For testing purposes - Default should be 17]
                int targetMinute = 59;          // Change this to manually set our minute [For testing purposes - Default should be 59] 


                // Checking for the right hour
                do
                {
                    hour = DateTime.Now.Hour;      // Retrieving current hour

                    if (hour == targetHour)
                    {
                        rightHour = true;
                        UpdateAutomationLog("Hour Checked: " + hour, 1);
                    }
                    else if (hour < targetHour)
                    {
                        Thread.Sleep(1 * 60 * 60 * 1000);  // Will sleep for 1hr before checking again
                    }
                    else
                    {
                        isOverride = true;
                        rightHour = true;
                        UpdateAutomationLog(DateTime.Now + ": Unable to proceed as current time is beyond 6pm.", 1);
                    }

                } while (!rightHour);


                if (!isOverride)   // If it is not after 6.00pm (aka more than target hour)
                {
                    // Checking for the right minute
                    do
                    {
                        minute = DateTime.Now.Minute;    // Retrieving current minute

                        if (minute == targetMinute)
                        {
                            rightMinute = true;
                            UpdateAutomationLog("Minute Checked: " + minute, 1);
                        }
                        else
                        {
                            Thread.Sleep(10000);  // Wait 10s before checking again
                        }

                    } while (!rightMinute);

                    // Checking for the right second
                    do
                    {
                        second = DateTime.Now.Second;    // Retrieving current second

                        if (second == 59)
                        {
                            rightSecond = true;
                            Thread.Sleep(1000);   // Adds another milliseconds to make it a full minute.
                            UpdateAutomationLog("Second Checked: " + second, 1);
                        }

                    } while (!rightSecond);

                    if (rightHour && rightMinute && rightSecond)
                    {
                        // Performing our clearing code here
                        var temp = PurchasingLogic.PopulateReorderTable();

                        if (temp != null && temp.Count > 0)
                        {
                            string s = PurchasingLogic.CreateMultiplePO(temp);
                        }

                        UpdateAutomationLog(DateTime.Now + ": EOD processes successfully completed.", 1);
                    }
                }
                else
                {
                    UpdateAutomationLog(DateTime.Now + ": EOD processes will now stop as now is beyond the intended scheduled time.", 1);
                }
            }
            else
            {
                UpdateAutomationLog(DateTime.Now + ": Today is a " + dayTodae + ". Since it is a weekend, EOD processes will not be carried out.", 1);
            }
        }

        // Running our weekend processes (aka forecasting process)
        public static void ForecastingAlgorithm(object sender, System.Timers.ElapsedEventArgs e)
        {
            DayOfWeek dayTodae = DateTime.Now.DayOfWeek;

            // Start message
            UpdateAutomationLog(DateTime.Now + ": Checking the day.", 2);


            // Checking for the right day aka Sundae
            if (dayTodae.Equals(DayOfWeek.Sunday))
            {
                UpdateAutomationLog(DateTime.Now + ": Forecasting processes start as it is a Sunday.", 2);

                // Init all req attrs
                bool isOverride = false;
                bool rightHour = false;
                bool rightMinute = false;
                bool rightSecond = false;
                int hour;
                int minute;
                int second;
                int targetHour = 6;             // Change this to manually set our hour [For testing purposes - Default should be 6]
                int targetMinute = 59;          // Change this to manually set our minute [For testing purposes - Default should be 59] 


                // Checking for the right hour
                do
                {
                    hour = DateTime.Now.Hour;      // Retrieving current hour

                    if (hour == targetHour)
                    {
                        rightHour = true;
                        UpdateAutomationLog("Hour Checked: " + hour, 2);
                    }
                    else if (hour < targetHour)
                    {
                        Thread.Sleep(1 * 60 * 60 * 1000);  // WIll sleep for 1hr before checking again
                    }
                    else
                    {
                        isOverride = true;
                        rightHour = true;
                        UpdateAutomationLog(DateTime.Now + ": Unable to proceed as current time is beyond 7am.", 2);
                    }

                } while (!rightHour);


                if (!isOverride)   // If it is not after 6.00pm (aka more than target hour)
                {
                    // Checking for the right minute
                    do
                    {
                        minute = DateTime.Now.Minute;    // Retrieving current minute

                        if (minute == targetMinute)
                        {
                            rightMinute = true;
                            UpdateAutomationLog("Minute Checked: " + minute, 2);
                        }
                        else
                        {
                            Thread.Sleep(10000);  // Wait 10s before checking again
                        }

                    } while (!rightMinute);

                    // Checking for the right second
                    do
                    {
                        second = DateTime.Now.Second;    // Retrieving current second

                        if (second == 59)
                        {
                            rightSecond = true;
                            Thread.Sleep(1000);   // Adds another milliseconds to make it a full minute.
                            UpdateAutomationLog("Second Checked: " + second, 2);
                        }

                    } while (!rightSecond);

                    if (rightHour && rightMinute && rightSecond)
                    {
                        try   // Performing our necessary logic...
                        {
                            CheckActualData();
                            CallForecastingScript();
                            UpdatingBufferStock();
                        }
                        catch (Exception ee)
                        {
                            Console.WriteLine(ee.Message);
                        }

                        UpdateAutomationLog(DateTime.Now + ": Forecasting processes successfully completed.", 2);
                    }
                }
                else
                {
                    UpdateAutomationLog(DateTime.Now + ": Forecasting processes will now stop as now is beyond the intended scheduled time.", 2);
                }
            }
            else
            {
                UpdateAutomationLog(DateTime.Now + ": Today is a " + dayTodae + ". Hence forecasting processes will not be carried out.", 2);
            }
        }

        // Calling the R script
        private static void CallForecastingScript()
        {
            ProcessStartInfo process = new ProcessStartInfo();
            Process rScript;

            // Running our bat file which will execute the R compiler with the R script
            process.FileName = @"C:/inetpub/wwwroot/Team12_SSIS/RScripts/RExec.bat";
            // Specify your preferences when running the script
            process.CreateNoWindow = false;
            process.UseShellExecute = false;      //Set 'true' if you want the cmd panel to pop up

            rScript = Process.Start(process);
            rScript.Close();
        }

        // Retrieving info from the inventory retrieval table and then populating into the actual data table
        private static void CheckActualData()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                List<InventoryCatalogue> iList = context.InventoryCatalogues.ToList();

                foreach (var item in iList)
                {
                    // Specify our itemID
                    string itemID = item.ItemID;

                    // Other attrs..
                    List<InventoryRetrievalList> i = context.InventoryRetrievalLists.Where(x => x.ItemID.Equals(itemID)).ToList();
                    int totalQty = 0;

                    // Getting the present datetime
                    DateTime now = DateTime.Now;

                    // Getting the datetime for the start of last week
                    DateTime prev = DateTime.Now.AddDays(-7);

                    // Isolating only those that are relevant (with ref to their DateRetrieved)
                    foreach (var ir in i)
                    {
                        DateTime tempDate = (DateTime)ir.DateRetrieved;

                        if (tempDate > prev && tempDate < now)
                        {
                            totalQty += (int)ir.RequestedQuantity;
                        }

                    }

                    // Finding the year
                    int season = DateTime.Now.Year;

                    // Finding the week no for the year (aka our period currently)
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    Calendar cal = dfi.Calendar;
                    int period = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);


                    // Check if there are existing entries in the database
                    List<ActualData> cList = context.ActualDatas.Where(x => x.ItemID.Equals(itemID)).ToList();
                    bool anyDuplicates = false;
                    foreach (var c in cList)
                    {
                        if (c.Season == season && c.Period == period)
                        {
                            anyDuplicates = true;
                        }
                    }
                    Console.WriteLine(period);
                    // Populating back to the database
                    if (anyDuplicates == false && totalQty != 0)
                    {
                        ActualData a = new ActualData();
                        a.ItemID = itemID;
                        a.Season = season;
                        a.Period = period;
                        a.ActualDemand = totalQty;

                        context.ActualDatas.Add(a);
                    }

                    context.SaveChanges();

                }
            }
        }

        // Updating the buffer stock in the inventory catelogue table
        private static void UpdatingBufferStock()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                List<InventoryCatalogue> i = context.InventoryCatalogues.ToList();

                foreach (var item in i)
                {
                    bool canContinue = true;

                    // Gotta check if BFSProportion is zero  --  If it is, set bool to false
                    if (item.BFSProportion == 0 || item.BFSProportion == null) canContinue = false;

                    if (canContinue)
                    {
                        PurchasingLogic.SetProportionalBFS(item.ItemID, (int)item.BFSProportion);
                    }
                    // Will not update those that have 0, i.e those that are manually set by the user.
                }
            }
        }

        // Update automation log
        public static void UpdateAutomationLog(string msg, int x)    // 1 => EOD Automation & 2 => Sunday Automation
        {
            if (x == 1)
            {
                using (StreamWriter writetext = new StreamWriter("C:\\inetpub\\wwwroot\\Team12_SSIS\\EODAutomationLog.txt", true))    // EOD automation log file
                {
                    writetext.WriteLine(msg);
                }
            }
            if (x == 2)
            {
                using (StreamWriter writetext = new StreamWriter("C:\\inetpub\\wwwroot\\Team12_SSIS\\ForecastAutomationLog.txt", true))    // Sunday automation log file
                {
                    writetext.WriteLine(msg);
                }
            }
        }

    }
}