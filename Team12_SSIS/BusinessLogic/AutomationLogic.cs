using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    //Whole thing belongs to Khair
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
                //Uncomment for final ver: int currentPeriod = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                DateTime date1 = new DateTime(2018, 2, 1);
                int currentPeriod = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

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


            // Checking for the right day aka weekday
            if (!dayTodae.Equals(DayOfWeek.Saturday) || !dayTodae.Equals(DayOfWeek.Sunday))
            {
                // Init all req attrs
                bool isOverride = false;
                bool rightHour = false;
                bool rightMinute = false;
                bool rightSecond = false;
                int hour;
                int minute;
                int second;
                int targetHour = 10;             // Change this to manually set our hour [For testing purposes - Default should be 17]
                int targetMinute = 10;          // Change this to manually set our minute [For testing purposes - Default should be 59] 

                // Checking for the right hour
                do
                {
                    hour = DateTime.Now.Hour;      // Retrieving current hour

                    if (hour == targetHour)
                    {
                        rightHour = true;
                    }
                    else if (hour < targetHour)
                    {
                        Thread.Sleep((targetHour - hour) * 60 * 60 * 1000);
                    }
                    else
                    {
                        //Thread.Sleep(6 * 60 * 60 * 1000);   // Sleep for 6 hours so will proceed to the next day
                        isOverride = true;
                        rightHour = true;
                    }

                } while (!rightHour);

                
                if (!isOverride)   // If it is not after 6pm
                {
                    // Checking for the right minute
                    do
                    {
                        minute = DateTime.Now.Minute;    // Retrieving current minute

                        if (minute == targetMinute)
                        {
                            rightMinute = true;
                        }
                        else
                        {
                            Thread.Sleep((targetMinute - minute) * 60 * 1000);
                            rightMinute = true;
                        }

                    } while (!rightMinute);

                    // Checking for the right second
                    do
                    {
                        second = DateTime.Now.Second;    // Retrieving current second

                        if (second == 59)
                        {
                            rightSecond = true;
                        }
                        else
                        {
                            Thread.Sleep((59 - second) * 1000);
                            Thread.Sleep(1000);   // Adds another milliseconds to make it a full minute.
                            rightSecond = true;
                        }

                    } while (!rightSecond);

                    //if (rightHour && rightMinute && rightSecond)
                    //{
                    //    // Performing our clearing code here
                    //    var temp = PurchasingLogic.PopulateReorderTable();

                    //    if (temp != null && temp.Count > 0)
                    //    {
                    //        string s = PurchasingLogic.CreateMultiplePO(temp);
                    //    }
                    //}

                    // Performing our clearing code here
                    var temp = PurchasingLogic.PopulateReorderTable();

                    if (temp != null && temp.Count > 0)
                    {
                        string s = PurchasingLogic.CreateMultiplePO(temp);
                    }
                }


                if (DateTime.Now.Hour <= 22)
                {
                    // Once all is done, perform a force sleep so that the timing is resetted back to about 10+pm
                    hour = DateTime.Now.Hour;
                    int hoursToSleep = 22 - hour;
                    Thread.Sleep(hoursToSleep * 60 * 60 * 1000);
                    // This ensures that the thread which will trigger this method (Every 18 hours) is done correctly.
                }
            }
            else
            {
                // Gotta reset it back to about 10pm as well
                int hour = DateTime.Now.Hour;
                int hoursToSleep = 22 - hour;
                Thread.Sleep(hoursToSleep * 60 * 60 * 1000);
            }
        }

        // Running our weekend processes (aka forecasting process)
        public static void ForecastingAlgorithm(object sender, System.Timers.ElapsedEventArgs e)
        {
            DayOfWeek dayTodae = DateTime.Now.DayOfWeek;

            if (dayTodae.Equals(DayOfWeek.Sunday))
            {
                //Init all req attrs
                bool rightHour = false;
                bool rightMinute = false;
                bool rightSecond = false;
                int hour;
                int minute;
                int second;

                // Checking for the right hour
                do
                {
                    hour = DateTime.Now.Hour;      // Retrieving current hour

                    if (hour == 6)
                    {
                        rightHour = true;
                    }
                    else if (hour < 6)
                    {
                        Thread.Sleep((6 - hour) * 60 * 60 * 1000);
                    }

                } while (!rightHour);

                // Checking for the right minute
                do
                {
                    minute = DateTime.Now.Minute;    // Retrieving current minute

                    if (minute == 59)
                    {
                        rightMinute = true;
                    }
                    else
                    {
                        Thread.Sleep((59 - minute) * 60 * 1000);
                        rightMinute = true;
                    }

                } while (!rightMinute);

                // Checking for the right second
                do
                {
                    second = DateTime.Now.Second;    // Retrieving current second

                    if (second == 59)
                    {
                        rightSecond = true;
                    }
                    else
                    {
                        Thread.Sleep((59 - second) * 1000);
                        rightSecond = true;
                    }

                } while (!rightSecond);

                if (rightHour && rightMinute && rightSecond)
                {
                    try
                    {
                        CheckActualData();
                        CallForecastingScript();
                        UpdatingBufferStock();
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                    }
                }


                // Once all is done, perform a force sleep so that the timing is resetted back to btw 3.00 to 3.59am
                hour = DateTime.Now.Hour;
                int hoursToSleep = (23 - hour) + 4;
                Thread.Sleep(hoursToSleep * 60 * 60 * 1000);
                // This ensures that the thread which will trigger this method (Every 24 hours) is done correctly before a scheduled forecast run.  
            }
            else
            {
                // Gotta reset as well back to btw 3.00 to 3.59am
                int hour = DateTime.Now.Hour;
                
                if (hour >= 4)
                {
                    int hoursToSleep = (23 - hour) + 4;
                    Thread.Sleep(hoursToSleep * 60 * 60 * 1000);
                }
            }
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

        // Calling the R script
        private static void CallForecastingScript()
        {
            ProcessStartInfo process = new ProcessStartInfo();
            Process rScript;

            // Running our bat file which will execute the R compiler with the R script
            process.FileName = @"C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts/RExec.bat";
            // Specify your preferences when running the script
            process.CreateNoWindow = false;
            process.UseShellExecute = false;      //Set 'true' if you want the cmd panel to pop up

            rScript = Process.Start(process);
            rScript.Close();
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

    }
}