using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Profile;
using System.Web.Security;

namespace Team12_SSIS.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthService.svc or AuthService.svc.cs at the Solution Explorer and start debugging.
    public class AuthService : IAuthService
    {
        public string Login(UserIdentity user)
        {
            string nameAndRole = string.Empty;
            if(Membership.ValidateUser(user.userName, user.password))
            {
                ProfileBase pUser = ProfileBase.Create(user.userName);
                nameAndRole = user.userName + "/" +Roles.GetRolesForUser(user.userName).First() +"/"+ pUser.GetPropertyValue("department");
                return nameAndRole;
            }
            nameAndRole = "Invalid";
            return nameAndRole;
        }
    }
}
