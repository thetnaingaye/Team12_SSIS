using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ManageDelegation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if(!IsPostBack)
			{
				
				EmployeesDdl.DataSource = DisbursementLogic.GetAllEmployeeFullNamesFromDept(DisbursementLogic.GetCurrentDep());
				EmployeesDdl.DataBind();
			}
        }
    }
}