using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ClerkMenu.Visible = Page.User.IsInRole("Clerk");

            if (Page.User.IsInRole("Supervisor"))
            {
                ManagerMenu.Visible = true;
                SupervisorMenu.Visible = true;
            }
            else if(Page.User.IsInRole("Manager"))
            {
                ManagerMenu.Visible = true;
                SupervisorMenu.Visible = false;
            }
            else
            {
                ManagerMenu.Visible = false;
                SupervisorMenu.Visible = false;
            }
      



            if (Page.User.Identity.IsAuthenticated)
            {
                LogoutMenu.Visible = true;
                UserName.Visible = true;
                LoginMenu.Visible = false;
                LblUserName.Text = Page.User.Identity.Name.ToString();
            }


        }
    }
}