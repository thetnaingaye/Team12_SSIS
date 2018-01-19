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

      
            if (Page.User.IsInRole("Clerk"))
            {
                ClerkMenu.Visible = true;
      
            }
            else
            {
                ClerkMenu.Visible = false;
            }

            if(Page.User.Identity.IsAuthenticated)
            {
                LogoutMenu.Visible = true;
                UserName.Visible = true;
                LoginMenu.Visible = false;
                LblUserName.Text = Page.User.Identity.Name.ToString(); ;
            }


        }
    }
}