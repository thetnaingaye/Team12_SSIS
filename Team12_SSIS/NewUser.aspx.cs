using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;


namespace Team12_SSIS
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            string username = CreateUserWizard1.UserName;
            string password = CreateUserWizard1.Password;
            Roles.AddUserToRole(username, "agent");
            CreateUserWizardStep step1 = (CreateUserWizardStep)CreateUserWizard1.FindControl("Step1");
            TextBox k1 = (TextBox)step1.ContentTemplateContainer.FindControl("Key1");
            TextBox k2 = (TextBox)step1.ContentTemplateContainer.FindControl("Key2");
            ProfileCommon profile = System.Web.Profile.GetProfile(username);
            profile.key1 = k1.Text;
            profile.key2 = k2.Text;
            profile.Save();
        }
    }
}