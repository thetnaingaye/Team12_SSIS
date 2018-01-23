using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ManageDelegation : System.Web.UI.Page
    {
		Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
			statusMessage = this.Master.FindControl("LblStatus") as Label;
			if (!IsPostBack)
			{
				statusMessage.Visible = false;
				EmployeesDdl.DataSource = DisbursementLogic.GetAllEmployeeFullNamesFromDept(DisbursementLogic.GetCurrentDep());
				EmployeesDdl.DataBind();
			}
        }

		protected void ApplyBtn_Click(object sender, EventArgs e)
		{
			DateTime startdate = CalStart.SelectedDate;
			DateTime enddate = CalEnd.SelectedDate;
			string delegatefullname = EmployeesDdl.Text;
			string delegateusername = DisbursementLogic.GetUserName(delegatefullname, DisbursementLogic.GetCurrentDep());
			if (startdate < DateTime.Today || startdate > enddate || startdate == null || enddate ==null )
			{
				statusMessage.Text = "Please enter a valid period";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Red;
			}
			else
			{
				RequisitionLogic.AddDelegate(delegatefullname,startdate, enddate, DisbursementLogic.GetCurrentDep());
				statusMessage.Text=(delegatefullname + " has been delegated as the department head from " + startdate.ToShortDateString() + " to " + enddate.ToShortDateString());
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Green;
			}
			
		}
	}
}