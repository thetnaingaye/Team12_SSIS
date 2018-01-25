using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class PastRequisitionOrders : System.Web.UI.Page
    {
        RequisitionLogic r = new RequisitionLogic();
        InventoryLogic i = new InventoryLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblDetails.Text = "";

                // Populating the first gridview with all past req records
                GridViewReqList.DataSource = r.ListPastRequisitionRecord();
                GridViewReqList.DataBind();

                // Populating the dropdownlist
                List<string> temp1 = new List<string>();
                temp1.Add("All");
                temp1.AddRange(r.GetDeptNameList());
                DdlDeptList.DataSource = temp1;
                DdlDeptList.DataBind();
            }

        }


        // Retrieving selected col values from the diff tables - To populate into the respective GridViews
        public string GetDepartmentName(string deptID)
        {
            string temp = r.GetDepartmentName(deptID);
            return temp.ToString();
        }

        public string GetItemDescription(string itemID)
        {
            string temp = i.GetItemDescription(itemID);
            return temp.ToString();
        }

        public string GetUnitsOfMeasure(string itemID)
        {
            string temp = i.GetUnitsOfMeasure(itemID);
            return temp.ToString();
        }


        // Populating the details (2nd GridView) below
        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tempText = btn.CommandArgument.ToString();
            int reqID = Convert.ToInt32(tempText);

            
            // Retrieve details list
            var tempList = r.RetrieveRequisitionRecordDetails(reqID, "Processed");
            if (tempList.Count() != 0)
            {
                // Populating the labels associated with the gridview
                LblSelected.Text = "Request ID: ";
                LblItemIDInfo.Text = "RQ" + tempText;
                LblDetails.Text = "Details";
            } else
            {
                // Populating the labels associated with the gridview
                LblSelected.Text = "No past records were retrieved.";
                LblSelected.ForeColor = System.Drawing.Color.Red;
                LblItemIDInfo.Text = "";
                LblDetails.Text = "Details";
            }

            // Binding the grid view
            GridViewDetails.DataSource = tempList;
            GridViewDetails.DataBind();
        }

        protected void DdlDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the value currently selected in the dropdownlist
            string val = DdlDeptList.SelectedValue;
            List<RequisitionRecord> temp;

            if (val == "All")
            {
                // Populating all past req records
                temp = r.ListPastRequisitionRecord();
                GridViewReqList.DataSource = temp;
            }
            else
            {
                // Populating the first gridview based on the selected department
                temp = r.ListPastRequisitionRecordsByDept(val);
                GridViewReqList.DataSource = temp;
            }
            GridViewReqList.DataBind();

            // Clearing the details gridview
            LblDetails.Text = null;
            LblSelected.Text = null;
            LblItemIDInfo.Text = null;
            GridViewDetails.DataSource = null;
            GridViewDetails.DataBind();
        }
    }
}