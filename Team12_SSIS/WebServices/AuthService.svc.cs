//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace Team12_SSIS.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthService.svc or AuthService.svc.cs at the Solution Explorer and start debugging.

    public class AuthService : IAuthService
    {
        const int shft = 5;
        const char seperator = '/';
        public string Login(UserIdentity user)
        {
            string loginToken = string.Empty;
            char seperator = '/';
            if (Membership.ValidateUser(user.userName, user.password))
            {
                ProfileBase pUser = ProfileBase.Create(user.userName);
                loginToken = Team12CustomStringEncoder(user.userName, user.password);
                return loginToken + seperator + pUser.GetPropertyValue("department") + seperator +Roles.GetRolesForUser(user.userName).First();
            }
            loginToken = "Invalid";
            return loginToken;
        }

        string Team12CustomStringEncoder(string userName, string password)
        {
            //Took this code from StackOverflow by lokusking https://stackoverflow.com/questions/38816004/simple-string-encryption-without-dependencies/38816208#38816208?newreg=466b51f08cc74759835ead8063afb961
            string topSecret = userName + seperator + password;
            string encrypted = topSecret.Select(ch => ((int)ch) << shft).Aggregate("", (current, val) => current + (char)(val * 2));
            encrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes(encrypted));
            return encrypted;
        }


        UserIdentity Team12CustomIdentityDecoder(string tokenString)
        {
            //Took this code from StackOverflow by lokusking https://stackoverflow.com/questions/38816004/simple-string-encryption-without-dependencies/38816208#38816208?newreg=466b51f08cc74759835ead8063afb961
            string decrypted = Encoding.UTF8.GetString(Convert.FromBase64String(tokenString)).Select(ch => ((int)ch) >> shft).Aggregate("", (current, val) => current + (char)(val / 2));
            string[] splitString = decrypted.Split(seperator);
            UserIdentity user = new UserIdentity();
            user.userName = splitString[0];
            user.password = splitString[1];
            return user;
        }
    }
}
