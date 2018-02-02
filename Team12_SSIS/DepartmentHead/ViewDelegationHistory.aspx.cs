//Author - Pradeep Elango

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ViewDelegationHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{   //Getting delegate history from database
				BindGrid();
			}

        }

		public void BindGrid()
		{
			GridViewDelegationHistory.DataSource = RequisitionLogic.ListDelegateDetails(DisbursementLogic.GetCurrentDep());
			GridViewDelegationHistory.DataBind();
			
		}

		protected void SearchBtn_Click(object sender, EventArgs e)
		{
			//Show list of all users found on data grid view 
			GridViewDelegationHistory.DataSource = RequisitionLogic.FindDelegateDetailsByEmployeeName(SearchTxt.Text,DisbursementLogic.GetCurrentDep());
			GridViewDelegationHistory.DataBind();
		}

		protected void ViewAllBtn_Click(object sender, EventArgs e)
		{
			SearchTxt.Text = "";
			BindGrid();
		}
	}
}