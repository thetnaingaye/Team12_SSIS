using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated) // if the user is already logged in
            {

                //redirecting respective home page according to Roles
                if (Page.User.IsInRole("Clerk"))
                {
                    Response.Redirect("~/StoreClerk/Home.aspx");
                }
                if (Page.User.IsInRole("Manager") || Page.User.IsInRole("Supervisor"))
                {
                    Response.Redirect("~/StoreManager/Home.aspx");
                }
                if (Page.User.IsInRole("Employee") || Page.User.IsInRole("Rep"))
                {
                    Response.Redirect("~/DepartmentEmployee/Home.aspx");
                }
                if (Page.User.IsInRole("HOD"))
                {
                    Response.Redirect("~/DepartmentHead/Home.aspx");
                }

            }
        }
    }
}