using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ManageDepartmentRep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
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
			NewRepAssignedLbl.Text = newrepfullname + "has been assigned as the new representative.";
			BindDdl();
			

		}
	}
}