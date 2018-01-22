using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
            var userList = new List<MembershipUser>();
            foreach (MembershipUser u in users)
            {
                userList.Add(u);
            }
            return userList;
        }

        public static List<MembershipUser> GetListOfMembershipUsersByDept(string dept)
        {
            List<MembershipUser> userList= GetListOfMembershipUsers();
            foreach(MembershipUser u in userList)
            {
                ProfileBase user = ProfileBase.Create(u.UserName);
                if((string)user.GetPropertyValue("department") != dept)
                {
                    userList.Remove(u);
                }
            }
            return userList;
        }
    }
}