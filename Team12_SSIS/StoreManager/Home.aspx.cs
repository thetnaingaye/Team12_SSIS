using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;


namespace Team12_SSIS.StoreManager
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["count"] = 0;
        }
        protected void Chart2_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Chart4_Load(object sender, EventArgs e)
        {

        }

        protected string GetPendingPO()
        {

       
                return PurchasingLogic.GetListOfPO("Pending").Count.ToString();
     
           
        }

        protected string GetPendingAVR()
        {

                 return InventoryLogic.GetListOfAdjustmentRequests("Pending").Count.ToString();
  
        }


    }
}