using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

//----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

namespace Team12_SSIS.DepartmentHead
{
    public partial class ViewRequisitionFormList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Here we set 'Pending' as the default status of the page (for ease of the user)
                GridViewReqList.DataSource = RequisitionLogic.ListAllRRBySpecificDeptAndStatus(DisbursementLogic.GetCurrentDep(), "Pending");
                GridViewReqList.DataBind();
            }
        }

        protected void DdlStatusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the value currently selected in the dropdownlist
            string val = DdlStatusList.SelectedValue;
            
            // Populating the gridview according to the status specified in the dropdownlist
            if (val == "All")
            {
                GridViewReqList.DataSource = RequisitionLogic.ListAllRRBySpecificDept(DisbursementLogic.GetCurrentDep());
            }
            else if (val == "Approved")
            {
                GridViewReqList.DataSource = RequisitionLogic.ListAllRRBySpecificDeptAndStatus(DisbursementLogic.GetCurrentDep(), "Approved");
            }
            else if (val == "Processed")
            {
                GridViewReqList.DataSource = RequisitionLogic.ListAllRRBySpecificDeptAndStatus(DisbursementLogic.GetCurrentDep(), "Processed");
            }
            else if (val == "Rejected")
            {
                GridViewReqList.DataSource = RequisitionLogic.ListAllRRBySpecificDeptAndStatus(DisbursementLogic.GetCurrentDep(), "Rejected");
            }
            else
            {
                // Default list (aka 'Pending)
                GridViewReqList.DataSource = RequisitionLogic.ListAllRRBySpecificDeptAndStatus(DisbursementLogic.GetCurrentDep(), "Pending");
            }
            GridViewReqList.DataBind();
        }

        // Processing 'processed date' for better UI aesthetics
        protected string GetApprovedDate(DateTime? approvedDate)
        {
            try
            {
                string temp = approvedDate.Value.ToString("MM/dd/yyyy");
                return temp;
            }
            catch
            {
                return "Nil";
            }
        }

        // Retrieving status of the req for better UI aesthetics
        protected string GetStatus(int reqID)
        {
            string temp = RequisitionLogic.GetStatus(reqID);
            return temp.ToString();
        }

        // Redirecting to the details page where you can approve and reject
        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tempText = btn.CommandArgument.ToString();

            // Passing the request ID to the inventory retrieval list
            Response.Redirect("~/DepartmentHead/ViewRequisitionFormDetails.aspx?RequestID=" + tempText);
        }
    }
}