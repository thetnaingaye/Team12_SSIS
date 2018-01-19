using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Web.Profile;
using System.Web.Security;
using Team12_SSIS.Utility;

namespace Team12_SSIS.StoreClerk
{


    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            IIdentity id = User.Identity;
            LblUserName.Text = "Welcome : " + User.Identity.Name + " : " + (User.IsInRole("Clerk") ? "Clerk Role" : "No Role");
            String name = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            String salutation = HttpContext.Current.Profile.GetPropertyValue("salutation").ToString();
            String department = HttpContext.Current.Profile.GetPropertyValue("department").ToString();
            LblUserName.Text += " : " + salutation;
            LblUserName.Text += "." + name;
            LblUserName.Text += " : " + department;

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Roles.RemoveUserFromRole(User.Identity.Name, "Clerk");
            Roles.AddUserToRole(User.Identity.Name, "Supervisor");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Roles.RemoveUserFromRole(User.Identity.Name, "Supervisor");
            Roles.AddUserToRole(User.Identity.Name, "Clerk");

        }
    }
}