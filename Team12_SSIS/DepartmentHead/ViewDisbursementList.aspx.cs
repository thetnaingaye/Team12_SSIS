using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ViewDisbursementList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblCollectionDate.Text = Request.QueryString["DisbursementID"];


        }
    }
}