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
    public partial class CurrentRequisitionOrders : System.Web.UI.Page
    {
        RequisitionLogic r = new RequisitionLogic();
        InventoryLogic i = new InventoryLogic();

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
                    GridViewReqList.DataSource = temp;
                    GridViewReqList.DataBind();
                }
            }
        }


        // Retrieving selected col values from the diff tables - To populate into the respective GridViews
        public string GetDepartmentName(string deptID)
        {
            string temp = r.GetDepartmentName(deptID);
            return temp.ToString();
        }

        public string GetItemName(string itemID)
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
    }
}