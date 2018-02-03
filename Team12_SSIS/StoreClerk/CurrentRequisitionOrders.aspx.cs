using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;

//----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

namespace Team12_SSIS.StoreClerk
{
    public partial class CurrentRequisitionOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblDetails.Text = "";
                var temp = RequisitionLogic.ListCurrentRequisitionRecord();
                if (temp == null)
                {
                    LblMessage.Text = "There are no requisition orders at present.";
                }
                else
                {
                    LoadData();
                }
            }
        }


        // Retrieving selected col values from the diff tables - To populate into the respective GridViews
        protected string GetDepartmentName(string deptID)
        {
            string temp = RequisitionLogic.GetDepartmentName(deptID);
            return temp.ToString();
        }

        protected string GetItemName(string itemID)
        {
            string temp = InventoryLogic.GetItemDescription(itemID);
            return temp.ToString();
        }

        protected string GetUnitsOfMeasure(string itemID)
        {
            string temp = InventoryLogic.GetUnitsOfMeasure(itemID);
            return temp.ToString();
        }

        // Populating the details (2nd GridView) below
        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tempText = btn.CommandArgument.ToString();
            int reqID = Convert.ToInt32(tempText);
            
            // Populating the labels associated with the gridview
            LblSelected.Text = "Request ID: ";
            LblItemIDInfo.Text = "RQ" + tempText;
            LblDetails.Text = "Details";

            // Changing the visibility of the button
            var tempList = RequisitionLogic.RetrieveRequisitionRecordDetails(reqID, "Approved");

            // Binding the gridview
            GridViewDetails.DataSource = tempList;
            GridViewDetails.DataBind();
        }

        // Creating pagination
        protected void GridViewReqList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewReqList.PageIndex = e.NewPageIndex;
            LoadData();
        }

        // Populating main gridview
        protected void LoadData()
        {
            var temp = RequisitionLogic.ListCurrentRequisitionRecord();
            GridViewReqList.DataSource = temp;
            GridViewReqList.DataBind();
        }
    }
}