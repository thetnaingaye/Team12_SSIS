using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using Team12_SSIS.Model;
using Team12_SSIS.Utility;

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

























































































































































































































































        //-- Jane not using.. Chang Siang will write here first..
        public static List<Department> GetListofDepartments()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.Departments.ToList();
            }
        }

        public static List<CollectionPoint> GetListofColPoint()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.CollectionPoints.ToList();
            }
        }

        public int CreateDisbursementList(string deptId, int collectPtId, DateTime collectionDate, string deptRep)
        {
            DisbursementList dList = new DisbursementList();
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                dList.DepartmentID = deptId;
                dList.CollectionPointID = collectPtId;
                dList.CollectionDate = collectionDate;
                dList.RepresentativeName = deptRep;
                dList.Status = "Pending Collection";
                ctx.DisbursementLists.Add(dList);
                ctx.SaveChanges();
            }
            using (EmailControl em = new EmailControl())
            {
                em.NewStationeryCollectionNotification(Utility.Utility.GetEmailAddressByName(deptRep), GetCurrentCPWithTimeByID(collectPtId), collectionDate.ToString("d"));
            }
            return dList.DisbursementID;
        }

        public void CreateDisbursementListDetails(int disbursementId, string itemId, int actualQuantity, int quantityRequested, int quantityCollected, string uom, string remarks)
        {
            DisbursementListDetail dListDetails = new DisbursementListDetail();
            dListDetails.DisbursementID = disbursementId;
            dListDetails.ItemID = itemId;
            dListDetails.ActualQuantity = actualQuantity;
            dListDetails.QuantityRequested = quantityRequested;
            dListDetails.QuantityCollected = quantityCollected;
            dListDetails.UOM = uom;
            dListDetails.Remarks = remarks;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.DisbursementListDetails.Add(dListDetails);
                ctx.SaveChanges();
            }
        }

        public bool UpdateDisbursementListDetails(int id, int quantityCollected, string remarks)
        {
            bool success = false;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                DisbursementListDetail dListDetails = ctx.DisbursementListDetails.Where(x => x.ID == id).FirstOrDefault();
                CheckForOutstandingItem(quantityCollected, dListDetails, remarks);
                dListDetails.QuantityCollected = quantityCollected;
                dListDetails.Remarks = remarks;
                ctx.SaveChanges();
                success = true;
            }
            return success;
        }

        public int CreateSystemStationeryRequest(DateTime requestDate, string deptId, string remarks)
        {
            RequisitionRecord rRecord = new RequisitionRecord();
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.RequisitionRecords.Add(rRecord);
                ctx.SaveChanges();
                return rRecord.RequestID;
            }
        }

        public void CreateStationeryRequestDetails(int requestId, string itemId, int requestedQuantity)
        {
            RequisitionRecordDetail rRDetails = new RequisitionRecordDetail();
            rRDetails.RequestID = requestId;
            rRDetails.ItemID = itemId;
            rRDetails.RequestedQuantity = requestedQuantity;
            rRDetails.Status = "Pending";

            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                ctx.RequisitionRecordDetails.Add(rRDetails);
                ctx.SaveChanges();
            }
        }

        private void CheckForOutstandingItem(int quantityCollected, DisbursementListDetail dListDetails, string remarks)
        {
            if (quantityCollected < dListDetails.QuantityCollected)
            {
                int Reqid = CreateSystemStationeryRequest(DateTime.Now.Date, dListDetails.DisbursementList.DepartmentID, remarks);
                CreateStationeryRequestDetails(Reqid, dListDetails.ItemID, (int)dListDetails.QuantityCollected - quantityCollected);
            }
        }

        public static DisbursementList GetDisbursementList(int disbursementId)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementLists.Where(x => x.DisbursementID == disbursementId).FirstOrDefault();
            }
        }

        public static List<DisbursementList> GetDisbursementList()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementLists.ToList();
            }
        }

        public static List<DisbursementListDetail> GetDisbursementListDetails()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementListDetails.ToList();
            }
        }

        public static List<DisbursementListDetail> GetDisbursementListDetails(int disbursementId)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementListDetails.Where(x => x.DisbursementID == disbursementId).ToList();
            }
        }

        public bool UpdateDisbursementStatus(int disbursementId, string status)
        {
            bool success = false;
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                DisbursementList dL = ctx.DisbursementLists.Where(x => x.DisbursementID == disbursementId).FirstOrDefault();
                dL.Status = status;
                ctx.SaveChanges();
                success = true;
            }
            return success;
        }

        public static List<DisbursementList> GetListOfDisbursements()
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                return ctx.DisbursementLists.ToList();
            }
        }

        public static List<DisbursementList> GetListOfDisbursements(string columnName, string query)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                switch (columnName)
                {
                    case ("DepartmentID"):
                        return ctx.DisbursementLists.Where(x => x.DepartmentID == query).ToList();
                    case ("Status"):
                        return ctx.DisbursementLists.Where(x => x.Status == query).ToList();
                    default:
                        return ctx.DisbursementLists.ToList();
                }
            }
        }










































































































































































































































































































































































































































































































































































































































































































































































































































































































































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

		public static void UpdateDeptRep(string username)
		{

			Roles.RemoveUserFromRole(GetDeptRepUserName(GetCurrentDep()), "Rep");
			Roles.AddUserToRole(username, "Rep");

		}
	}

}
