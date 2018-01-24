using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Team12_SSIS.Model;
using Team12_SSIS.Utility;

namespace Team12_SSIS.BusinessLogic
{
    //Khair Line 15 to 315
    //Jane Line 316 to 616
    //Naing Line 617 to 917
    //Pradeep 1218 to 1518
    //Yishu Line 1519 to 1820
    public class RequisitionLogic
    {



















































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































	public static void AddDelegate(String fullname,DateTime startdate, DateTime enddate, string depid)
	{
			if (startdate >= DateTime.Today && enddate >= startdate)
			{
				using (SA45Team12AD entities = new SA45Team12AD())
				{
					DDelegateDetail delegateDetail = new DDelegateDetail
					{
						DepartmentID = depid,
						DepartmentHeadDelegate = fullname,
						StartDate = startdate,
						EndDate = enddate
					};
					entities.DDelegateDetails.Add(delegateDetail);

					Department department = entities.Departments.Where(x => x.DeptID == depid).First();
					department.HasDelegate = 1;
					entities.SaveChanges();
				}
				if (startdate == DateTime.Today)
				{
					AddDeptHeadRoleToUser(fullname, depid);
				}
			}
			
	}

	public static List<DDelegateDetail> ListDelegateDetails(string depid)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				return entities.DDelegateDetails.Where(x=>x.DepartmentID == depid).ToList<DDelegateDetail>();
			}
		}

		public static List<DDelegateDetail> FindDelegateDetailsByEmployeeName(string input, string dept)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				return entities.DDelegateDetails.Where(x => x.DepartmentHeadDelegate.Contains(input)).Where(x => x.DepartmentID == dept).ToList<DDelegateDetail>();
			}
		}


		public static bool HasDelegate(string depid)
		{
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				int hasdelegate = entities.Departments.Where(x => x.DeptID == depid).Select(x => x.HasDelegate).Single();
				if (hasdelegate == 0)
				{
					return false;
				}
				else
				{
					return true;
				}

			}
		}

		public static DDelegateDetail GetLatestDelegate(string depid)
		{
			List<DDelegateDetail> currentdeplist = new List<DDelegateDetail>();
			List<DDelegateDetail> alllist = new List<DDelegateDetail>();
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				alllist = entities.DDelegateDetails.ToList();
				foreach(DDelegateDetail u in alllist)
				{
					if(u.DepartmentID ==depid)
					{
						currentdeplist.Add(u);
					}
				}
			}
			return currentdeplist.OrderByDescending(x => x.EndDate).First(); ;
		}

		public static DateTime GetDelegateStartDate(DDelegateDetail dDelegateDetail)
		{
			return (DateTime)dDelegateDetail.StartDate;
		}

		public static DateTime GetDelegateEndDate(DDelegateDetail dDelegateDetail)
		{
			return (DateTime)dDelegateDetail.EndDate;
			

		}

		public static string GetDelegateName(DDelegateDetail dDelegateDetail)
		{
			return dDelegateDetail.DepartmentHeadDelegate.ToString();
		}

		public static void UpdateDelegate(DDelegateDetail dDelegateinput, DateTime newstartdate, DateTime newenddate)
		{
			//if (Roles.IsUserInRole(DisbursementLogic.GetUserName(dDelegateinput.DepartmentHeadDelegate, dDelegateinput.DepartmentID), "HOD"))
			{
				using (SA45Team12AD entities = new SA45Team12AD())
				{
					DDelegateDetail dDelegate = entities.DDelegateDetails.Where(p => p.DepartmentHeadDelegate == dDelegateinput.DepartmentHeadDelegate).Where(x => x.DepartmentID == dDelegateinput.DepartmentID).Where(x => x.StartDate == dDelegateinput.StartDate).Where(x => x.EndDate == dDelegateinput.EndDate).First();
					dDelegate.StartDate = newstartdate;
					dDelegate.EndDate = newenddate;
					entities.SaveChanges();
				}
				using (EmailControl em = new EmailControl())
				{
					List<string> depuseremails = new List<string>();
					depuseremails = Utility.Utility.GetAllUserEmailAddressListForDept(dDelegateinput.DepartmentID);
				}

			}

		}

		public static void CancelDelegate(DDelegateDetail dDelegateinput)
		{
			
				using (SA45Team12AD entities = new SA45Team12AD())
				{
					DDelegateDetail dDelegate = entities.DDelegateDetails.Where(p => p.DepartmentHeadDelegate == dDelegateinput.DepartmentHeadDelegate).Where(x => x.DepartmentID == dDelegateinput.DepartmentID).Where(x => x.StartDate == dDelegateinput.StartDate).Where(x => x.EndDate == dDelegateinput.EndDate).First();
					if (dDelegateinput.StartDate >= DateTime.Today)
					{
						dDelegate.StartDate = DateTime.Today.AddDays(-1);
					}
					dDelegate.EndDate = DateTime.Today.AddDays(-1);

					Department department = entities.Departments.Where(x => x.DeptID == dDelegateinput.DepartmentID).First();

					department.HasDelegate = 0;
					entities.SaveChanges();
					if (Roles.IsUserInRole(DisbursementLogic.GetUserName(dDelegateinput.DepartmentHeadDelegate, dDelegateinput.DepartmentID), "HOD"))
					{
						RemoveDeptHeadRoleFromUser(dDelegate.DepartmentHeadDelegate, dDelegate.DepartmentID);
					}
				}
			
			
		}

		public static void AddDeptHeadRoleToUser(string fullname, string depid)
		{
			string username = DisbursementLogic.GetUserName(fullname, depid);
			Roles.RemoveUserFromRole(username, "Employee");
			Roles.AddUserToRole(username, "HOD");
		}
		public static void RemoveDeptHeadRoleFromUser(string fullname, string depid)
		{
			string username = DisbursementLogic.GetUserName(fullname, depid);
			Roles.RemoveUserFromRole(username, "HOD");
			Roles.AddUserToRole(username, "Employee");
		}


		







































































































































































































































































































		public List<InventoryCatalogue> SearchBy(string value)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues.Where(i => i.ItemID.Contains(value) || i.Description.Contains(value)).ToList();
            }
        }

        public static List<InventoryCatalogue> DeleteOrder(List<InventoryCatalogue> _itemList, string ItemID)
        {
            List<InventoryCatalogue> itemList = _itemList;
            InventoryCatalogue removeRequest = itemList.Where(i => i.ItemID == ItemID).First();
            itemList.Remove(removeRequest);
            return itemList;
        }

        public IQueryable<InventoryCatalogue> GetInventoryCatalogues()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues;
            }
        }
    }
    }