using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    }
}