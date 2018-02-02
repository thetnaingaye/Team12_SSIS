//Author - Pradeep Elango

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ManageDepartmentRep : System.Web.UI.Page
    {
		Label statusMessage;
		protected void Page_Load(object sender, EventArgs e)
        {
			statusMessage = this.Master.FindControl("LblStatus") as Label;
			if (!IsPostBack)
			{
				statusMessage.Visible = false;
				//Show current rep
				CurrentRepLbl.Text = DisbursementLogic.GetDeptRepFullName(DisbursementLogic.GetCurrentDep());
				BindDdl();
			}

        }

		protected void BindDdl()
		{
			EmployeesDdl.DataSource = DisbursementLogic.GetAllEmployeeFullNamesFromDept(DisbursementLogic.GetCurrentDep());
			EmployeesDdl.DataBind();
		}
		protected void AssignRepBtn_Click(object sender, EventArgs e)
		{
			
			//Getting new representative name from dropdown list
			string newrepfullname = EmployeesDdl.SelectedValue;
			//Update new rep and delete old rep by passing in new representative name and current department
			DisbursementLogic.UpdateDeptRep(newrepfullname,DisbursementLogic.GetCurrentDep());
			
			//Update current representative
			CurrentRepLbl.Text = DisbursementLogic.GetDeptRepFullName(DisbursementLogic.GetCurrentDep());
			statusMessage.Text = newrepfullname + " has been assigned as the new representative.";
			statusMessage.Visible = true;
			statusMessage.ForeColor = Color.Green;
			BindDdl();
			AssignRepBtn.Enabled = true;


		}
	}
}