using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Team12_SSIS.Utility
{
	public static class Utility
	{




















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
	}
}