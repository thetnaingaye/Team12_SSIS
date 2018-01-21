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
  
            LblUserName.Text = "Welcome : " + User.Identity.Name + " : " + (User.IsInRole("Clerk") ? "Clerk Role" : "No Role");
            String name = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            String salutation = HttpContext.Current.Profile.GetPropertyValue("salutation").ToString();
            String department = HttpContext.Current.Profile.GetPropertyValue("department").ToString();
            LblUserName.Text += " : " + salutation;
            LblUserName.Text += "." + name;
            LblUserName.Text += " : " + department;

            var users = Membership.GetAllUsers();
            var userList = new List<MembershipUser>();
            foreach (MembershipUser u in users)
            {
                userList.Add(u);
            
            }
          //  GridView1.DataSource = userList;
            GridView1.DataSource = Roles.GetUsersInRole("HOD");
                        GridView1.DataBind();

            //var user = (MembershipUser)userList.Find(x => x.UserName == "clerk1");

            //getting user with supervisor role
            var user = (MembershipUser)userList.Find(x => x.UserName == Roles.GetUsersInRole("Supervisor").First());
            ProfileBase profile = ProfileBase.Create(user.UserName);

            LblEmail.Text = user.Email.ToString() + "full name " + profile.GetPropertyValue("fullname");

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