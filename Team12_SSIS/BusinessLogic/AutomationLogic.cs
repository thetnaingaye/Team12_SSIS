using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            int x = 26;
            bool s = false;
            do
            {
                if (DateTime.Now.Minute.Equals(x))
                {
                    using (SA45Team12AD context = new SA45Team12AD())
                    {
                        List<ReorderRecord> r = context.ReorderRecords.ToList();
                        PurchasingLogic.CreateMultiplePO(r);
                    }
                }
                else
                {
                    int tempN = DateTime.Now.Minute;
                    int rem = (x - tempN) * 60;
                    System.Threading.Thread.Sleep(1000 * rem);
                }
            }
            while (!s);
        }

    }
}