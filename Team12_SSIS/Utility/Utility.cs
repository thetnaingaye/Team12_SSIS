//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace Team12_SSIS.Utility
{
    public static class Utility
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static List<MembershipUser> GetListOfMembershipUsers()
        {
            var users = Membership.GetAllUsers();
            List<MembershipUser> userList = new List<MembershipUser>();
            foreach (MembershipUser u in users)
            {
                userList.Add(u);
            }
            return userList;
        }

        public static List<MembershipUser> GetListOfMembershipUsersByDept(string dept)
        {
            List<MembershipUser> userList = GetListOfMembershipUsers();
            foreach (MembershipUser u in userList)
            {
                ProfileBase user = ProfileBase.Create(u.UserName);
                if ((string)user.GetPropertyValue("department") != dept)
                {
                    userList.Remove(u);
                }
            }
            return userList;
        }

        public static int GetValidPrimaryKeyInt(string referenceId)
        {
            string s = referenceId;
            Regex regex = new Regex("[0-9]");
            for (int i = 0; i < s.Length - 1; i++)
            {
                int x;
                if (regex.IsMatch(s.Substring(i, 1)))
                {
                    bool isValid = int.TryParse(s.Substring(i, s.Length - i), out x);
                    return x;
                }               
            }
            return -1;
        }

































































































































































































































































        public static string GetUserEmailAddress(string fullname)
        {
            List<string> clerkemails = new List<string>();
            List<MembershipUser> userList = GetListOfMembershipUsers();
            foreach (MembershipUser u in userList)
            {
                ProfileBase p = ProfileBase.Create(u.UserName);
                if (p.GetPropertyValue("fullname").ToString() == fullname)
                {
                    return u.Email;
                }
            }
            //in case user is not found...
            return "sa45team12ssis+UtilityinGetUserEmailAddressError@gmail.com";
        }















        public static List<string> GetClerksEmailAddressList()
        {
            List<string> clerkemails = new List<string>();
            List<MembershipUser> userList = GetListOfMembershipUsers();
            foreach (MembershipUser u in userList)
            {
                if (Roles.GetRolesForUser(u.UserName)[0] == ("Clerk"))
                {
                    clerkemails.Add(u.Email);
                }

            }
            return clerkemails;

        }
        public static List<string> GetAllUserEmailAddressListForDept(string depid)
        {
            List<string> deptuseremails = new List<string>();
            List<MembershipUser> userList = GetListOfMembershipUsers();
            foreach (MembershipUser u in userList)
            {
                ProfileBase user = ProfileBase.Create(u.UserName);
                if ((string)user.GetPropertyValue("department") == depid)
                {
                    deptuseremails.Add(u.Email);
                }
            }
            return deptuseremails;

        }


        public static string GetEmailAddressByName(string name)
        { 
            List<MembershipUser> userList = GetListOfMembershipUsers();
            foreach (MembershipUser u in userList)
            {
                ProfileBase user = ProfileBase.Create(u.UserName);
                if (user.GetPropertyValue("fullname").ToString() == name)
                    return u.Email;
            }
            //If error! Send to this email. So we can catch the error by the string after the "+" sign.
            return "sa45team12ssis+UtilityinGetEmailAddressByName@gmail.com";
        }
    }
}
