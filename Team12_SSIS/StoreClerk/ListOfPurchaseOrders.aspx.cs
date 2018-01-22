using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class ListOfPurchaseOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Populate();
            string[] supplierID = { "ALPA", "CHEP", "BANE" };
            if (!IsPostBack)
            {
                ddlShow.DataSource = supplierID;
                ddlShow.DataBind();
            }
        }
        protected void Populate()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                GridViewLPO.DataSource = entities.PORecords.ToList<PORecord>();
                GridViewLPO.DataBind();
            }


        }
        }
    }
}