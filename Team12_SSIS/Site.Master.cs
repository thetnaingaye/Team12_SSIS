//Author: thet naing aye
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
            // for store clerk role menu
            ClerkMenu.Visible = Page.User.IsInRole("Clerk");

            // for store supervisor and manager role menu
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

            // for department rep and employee role menu
            if (Page.User.IsInRole("Rep"))
            {
                RepMenu.Visible = true;
                RepMenu1.Visible = true;
                EmployeeMenu.Visible = true;
            }
            else if (Page.User.IsInRole("Employee"))
            {
                RepMenu.Visible = false;
                RepMenu1.Visible = false;
                EmployeeMenu.Visible = true;
            }
            else
            {
                RepMenu.Visible = false;
                RepMenu1.Visible = false;
                EmployeeMenu.Visible = false;
            }

            // for deparment head role menu
            HOD.Visible = Page.User.IsInRole("HOD");

            // for login and logout menu
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