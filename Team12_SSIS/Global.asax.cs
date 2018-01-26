using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS
{
    public class Global : System.Web.HttpApplication
    {

		protected void Application_Start(object sender, EventArgs e)
		{
			Application["count"] = 0;
			Thread thread = new Thread(new ThreadStart(ThreadFunc));
			thread.IsBackground = true;
			thread.Name = "ThreadFunc";
			thread.Start();

		}
		protected void ThreadFunc()
		{
			System.Timers.Timer t = new System.Timers.Timer();
			t.Elapsed += new System.Timers.ElapsedEventHandler(AddDeptHeadRoleToUserWithDateCheck);
			
			t.Interval = 5000;
			t.Enabled = true;
			t.AutoReset = true;
			t.Start();
		}

        //Send reminder email to department rep 2 days before the collection date
        //This Thread will trigger every 24 hours
        protected void ThreadFuncForCollectionReminder()
        {
            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(SendCollectionReminder);

            t.Interval = 86400000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }

        protected void SendCollectionReminder(object sender, System.Timers.ElapsedEventArgs e)
        {
            DisbursementLogic.SendCollectionReminder(DateTime.Now.Date);
        }
        protected void AddDeptHeadRoleToUserWithDateCheck(object sender, System.Timers.ElapsedEventArgs e)
		{
			List<Department> depwithdelegateslist = new List<Department>();
			List<Department> deplist = new List<Department>();
			List<DDelegateDetail> delegatelist = new List<DDelegateDetail>();
			List<DateTime> startdates = new List<DateTime>();
			List<DateTime> enddates = new List<DateTime>();
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				//get list of current delegates
				delegatelist = entities.DDelegateDetails.ToList();
				deplist = entities.Departments.ToList();
				foreach(Department u in deplist)
				{
					if(u.HasDelegate == 1)
					{
						depwithdelegateslist.Add(u);
					}
				}

				if (depwithdelegateslist != null)
				{
					foreach (Department u in depwithdelegateslist)
					{
						delegatelist.Add(RequisitionLogic.GetLatestDelegate(u.DeptID));
					}
					foreach (DDelegateDetail u in delegatelist)
					{
						//get username for delegates
						string username = DisbursementLogic.GetUserName(u.DepartmentHeadDelegate, u.DepartmentID);
						//add depthead role to user after checking period
						if (DateTime.Today>=u.StartDate && DateTime.Today<=u.EndDate && Roles.IsUserInRole(username,"Employee"))
						{
							RequisitionLogic.AddDeptHeadRoleToUser(u.DepartmentHeadDelegate, u.DepartmentID);
						}
					}
					
				}

			}
			RemoveDeptHeadRoleFromUserWithDateCheck(sender,e);
		}

		protected void RemoveDeptHeadRoleFromUserWithDateCheck(object sender, System.Timers.ElapsedEventArgs e)
		{
			List<Department> depwithdelegateslist = new List<Department>();
			List<Department> deplist = new List<Department>();
			List<DDelegateDetail> delegatelist = new List<DDelegateDetail>();
			List<DateTime> startdates = new List<DateTime>();
			List<DateTime> enddates = new List<DateTime>();
			using (SA45Team12AD entities = new SA45Team12AD())
			{
				//get list of current delegates
				delegatelist = entities.DDelegateDetails.ToList();
				deplist = entities.Departments.ToList();
				foreach (Department u in deplist)
				{
					if (u.HasDelegate == 1)
					{
						depwithdelegateslist.Add(u);
					}
				}

				if (depwithdelegateslist != null)
				{
					foreach (Department u in depwithdelegateslist)
					{
						delegatelist.Add(RequisitionLogic.GetLatestDelegate(u.DeptID));
					}
					foreach (DDelegateDetail u in delegatelist)
					{
						//get username for delegates
						string username = DisbursementLogic.GetUserName(u.DepartmentHeadDelegate, u.DepartmentID);
						//remove depthead role from user after checking period
						if (DateTime.Today > u.EndDate && Roles.IsUserInRole(username, "HOD"))
						{
							RequisitionLogic.RemoveDeptHeadRoleFromUser(u.DepartmentHeadDelegate, u.DepartmentID);
							Department department = entities.Departments.Where(x => x.DeptID == u.DepartmentID).First();
							department.HasDelegate = 0;
							entities.SaveChanges();
						}
					}

				}

			}
		}



		protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}