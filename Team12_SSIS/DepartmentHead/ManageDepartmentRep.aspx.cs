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
				CurrentRepLbl.Text = DisbursementLogic.GetDeptRep(DisbursementLogic.GetCurrentDep());
				EmployeesDdl.DataSource = DisbursementLogic.GetAllEmployeeFullNamesFromDept(DisbursementLogic.GetCurrentDep());
				EmployeesDdl.DataBind();
			}

        }

		protected void AssignRepBtn_Click(object sender, EventArgs e)
		{
			string newrep = EmployeesDdl.SelectedValue;
			DisbursementLogic.UpdateDeptRep(newrep);

		}
	}
}