using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblUserName.Text = "Welcome : " + User.Identity.Name;
            String name = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            String salutation = HttpContext.Current.Profile.GetPropertyValue("salutation").ToString();
            String department = HttpContext.Current.Profile.GetPropertyValue("department").ToString();
            LblUserName.Text += " : " + salutation;
            LblUserName.Text += "." + name;
            LblUserName.Text += " : " + department;
            var user = Membership.GetUser(User.Identity.Name);

            LblUserName.Text += " : " + user.Email;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(TxtName.Text))
            {
                HttpContext.Current.Profile.SetPropertyValue("fullname", TxtName.Text);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var user = Membership.GetUser(User.Identity.Name);
            user.Email = TxtEmail.Text;
            Membership.UpdateUser(user);
           
        }
    }
}