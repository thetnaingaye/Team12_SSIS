using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreManager.StoreSupervisor
{
    public partial class ApprovePurchaseOrder : System.Web.UI.Page
    {
        PurchasingLogic p = new PurchasingLogic();
        int poNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            //poNo = Request.QueryString["PONumber"];
           
            //poNo = 12;
            //PORecord poR = p.GetPORecords(Convert.ToInt32(poNo));
            //LblDate.Text=poR.DateRequested.Value.ToString("MM/dd/yyyy");
            //LblStatus.Text = poR.Status.(Convert.ToInt32(poNo));

        }
    }
}
