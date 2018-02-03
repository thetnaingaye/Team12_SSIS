//Thet Naing Aye and SICAT JANE ESCALADA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

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
            int supervisor_count = 0;
            int manager_count = 0;

            List<AVRequest> pendingList = InventoryLogic.GetListOfAdjustmentRequests("Pending");
            foreach(AVRequest a in pendingList)
            {
                if(a.HandledBy == "Supervisor")
                {
                    supervisor_count++;
                }
                if(a.HandledBy == "Manager")
                {
                    manager_count++;
                }
            }

            if(User.IsInRole("Supervisor"))
            {
                return supervisor_count.ToString();
            }
            if(User.IsInRole("Manager"))
            {
                return manager_count.ToString();
            }
            return "0";
  
        }


    }
}