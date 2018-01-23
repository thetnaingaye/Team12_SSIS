using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{

    //Yishu Line 15 to 315
    //thanisha Line 316 to 616
    //Jane Line 617 to 917
    //Naing Line 1218 to 1518
    //Pradeep Line 1519 to 1820
    public class DisbursementLogic
    {












































































































































































































































































































        //-------------------------Getting disbursement details------------------------------//
        public List<DisbursementList> getDisbursement()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.DisbursementLists.ToList<DisbursementList>();
            }

        }


        public List<DisbursementList> getDisbursementByRep(string rep)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.DisbursementLists.Where(x => x.RepresentativeName == rep).ToList<DisbursementList>();
            }

        }
        public List<DisbursementList> getDisbursementByDate(DateTime startDate, DateTime enddate)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                var q = from x in entities.DisbursementLists where x.CollectionDate >= startDate && x.CollectionDate <= enddate select x;
                List<DisbursementList> dList = q.ToList<DisbursementList>();
                return dList;
            }
        }


		//-----------------------------using join --------//
		//public List<Object> getDisbursementForm()
		//{
		//    using (SA45Team12AD entities = new SA45Team12AD())
		//    {
		//        var q = (from di in entities.DisbursementLists
		//                 join de in entities.Departments on di.DepartmentID equals de.DeptID
		//                 join co in entities.CollectionPoints on di.CollectionPointID equals co.CollectionPointID
		//                 select new
		//                 {
		//                     DisbursementID = di.DisbursementID,
		//                     DepartmentName = de.DepartmentName,
		//                     CollectionPoint = co.CollectionPoint1,
		//                     Representative = di.RepresentativeName,
		//                     status = di.Status
		//                 });
		//        return 
		//        }
		//    }




































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































		public static List<CollectionPoint> ListCollectionPoints()
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				return entities.CollectionPoints.ToList();
			}
		}

		public static List<string> ListCollectionPointsWithTime()
		{
			List<CollectionPoint> cpList = new List<CollectionPoint>();
			cpList = DisbursementLogic.ListCollectionPoints();
			List<string> cpWithTimeList = new List<string>();
			foreach (CollectionPoint C in cpList)
			{
				string s = C.CollectionPoint1;
				cpWithTimeList.Add(s);
			}
			return cpWithTimeList;
		}

		public static string GetCurrentDep()
		{
			return HttpContext.Current.Profile.GetPropertyValue("department").ToString();
		}

		public static string GetCurrentCPIDByDep(string dep)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				return entities.Departments.Where(x => x.DeptID == dep).Select(x => x.CollectionPointID).Single().ToString();

			}
		}

		public static string GetCurrentCPWithTimeByID(int id)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				string CPName = entities.CollectionPoints.Where(x => x.CollectionPointID == id).Select(x => x.CollectionPoint1).Single().ToString();
				return CPName;
			}
		}

		public static void UpdateCollectionPoint(string depid, int cpid)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				Department department = entities.Departments.Where(p => p.DeptID == depid).First<Department>();
				department.CollectionPointID = cpid;
				entities.SaveChanges();
			}
		}

		public static List<MembershipUser> GetUsersFromDept(string dept)
		{
			List<MembershipUser> currentdepusers = new List<MembershipUser>();
			var users = Membership.GetAllUsers();

			foreach (MembershipUser u in users)
			{


				ProfileBase profile = ProfileBase.Create(u.UserName);
				if (profile.GetPropertyValue("department").ToString() == dept)
				{
					currentdepusers.Add(u);
				}


			}


			return currentdepusers;
		}
		public static List<String> GetFullNamesFromDept(string dept)
		{
			List<String> currentdep = new List<String>();
			var users = Membership.GetAllUsers();

			foreach (MembershipUser u in users)
			{


				ProfileBase profile = ProfileBase.Create(u.UserName);
				if (profile.GetPropertyValue("department").ToString() == dept)
				{
					currentdep.Add(profile.GetPropertyValue("fullname").ToString());
				}


			}


			return currentdep;
		}

		public static List<String> GetAllEmployeeFullNamesFromDept(string dept)
		{
			String employeeFullName = "";
			List<MembershipUser> users = GetUsersFromDept(dept);
			List<String> repusers = Roles.GetUsersInRole("Employee").ToList();
			List<string> employees = new List<string>();
			foreach (MembershipUser u in users)
			{
				foreach (string username in repusers)
				{
					if (u.UserName == username)
					{
						ProfileBase p = ProfileBase.Create(username);
						employeeFullName = p.GetPropertyValue("fullname").ToString();
						employees.Add(employeeFullName);


					}
				}
			}

			return employees;
		}
		public static string GetDeptRepFullName(String dept)
		{
			String repFullName = "";
			List<MembershipUser> users = GetUsersFromDept(dept);
			List<String> repusers = Roles.GetUsersInRole("Rep").ToList();
			foreach (MembershipUser u in users)
			{
				foreach (string username in repusers)
				{
					if (u.UserName == username)
					{
						ProfileBase p = ProfileBase.Create(username);
						repFullName = p.GetPropertyValue("fullname").ToString();

					}
				}
			}

			return repFullName;
		}

		public static string GetDeptRepUserName(String dept)
		{

			List<MembershipUser> users = GetUsersFromDept(dept);
			List<String> repusers = Roles.GetUsersInRole("Rep").ToList();
			foreach (MembershipUser u in users)
			{
				foreach (string username in repusers)
				{
					if (u.UserName == username)
					{
						return u.UserName;

					}
				}
			}

			return null;
		}

		public static string GetUserName(String fullname, String dept)
		{

			List<MembershipUser> users = GetUsersFromDept(dept);
			foreach (MembershipUser u in users)
			{
				ProfileBase p = ProfileBase.Create(u.UserName);
				if (p.GetPropertyValue("fullname").ToString() == fullname)
				{
					return u.UserName;
				}
			}
			return null;
		}

		public static void UpdateDeptRep(String newrepfullname, String dept)
		{
			Roles.RemoveUserFromRole(GetDeptRepUserName(GetCurrentDep()), "Rep");
			Roles.AddUserToRole(GetDeptRepUserName(GetCurrentDep()), "Employee");
			Roles.RemoveUserFromRole(GetUserName(newrepfullname, dept), "Employee");
			Roles.AddUserToRole(GetUserName(newrepfullname, dept), "Rep");
			
		}
	}

}
