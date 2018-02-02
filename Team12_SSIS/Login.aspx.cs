using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label status = Master.FindControl("LblStatus") as Label;
            status.Text = "Please login to start";

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }
    }
}