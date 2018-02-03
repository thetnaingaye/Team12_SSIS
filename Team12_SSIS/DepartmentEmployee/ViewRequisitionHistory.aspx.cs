//Author: Jianing and SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI code here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class ViewRequisitionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            List<RequisitionRecord> reRecordList = RequisitionLogic.FindRequisitionRecordByReqName(RequisitionLogic.GetCurrentDeptUserName());
            
            GridViewVPR.DataSource = reRecordList;
            GridViewVPR.DataBind();
           
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton LBtnLBtnRID = (e.Row.FindControl("LBtnRID") as LinkButton);

        }

        protected void GridViewVPR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RequisitionRecord record = (RequisitionRecord)e.Row.DataItem;
                
                int ReuestID = record.RequestID;
                
                Label LblDateProcessed = e.Row.FindControl("LblDateProcessed") as Label;
                if (record.ApprovedDate != null)
                {
                    LblDateProcessed.Text = ((DateTime)record.ApprovedDate).ToString("d");
                }
                else
                {
                    LblDateProcessed.Text = "null";
                }

                RequisitionRecord re = (RequisitionRecord)e.Row.DataItem;
                int RequestID1 = re.RequestID;
                Label LblStatus = e.Row.FindControl("LblStatus") as Label;
                string status= RequisitionLogic.GetRecordStatus(re.RequestID);
                if (status != null)
                    LblStatus.Text = status;

            }
        }

        protected void LBtnRID_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            int reqID = Utility.Utility.GetValidPrimaryKeyInt(lb.Text);

            // Retrieve details list
            var tempList = RequisitionLogic.FindRequisitionRecordDetailsByReqID(reqID);
            if (tempList.Count() != 0)
            {
                // Populating the labels associated with the gridview
                LblSelected.Text = "Request ID: ";
                LblItemIDInfo.Text = lb.Text;
                LblDetails.Text = "Details";
            }
            else
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



        public string GetItemDescription(string itemID)
        {
            string temp = InventoryLogic.GetItemDescription(itemID);
            return temp.ToString();
        }

        public string GetUnitsOfMeasure(string itemID)
        {
            string temp = InventoryLogic.GetUnitsOfMeasure(itemID);
            return temp.ToString();
        }
    }   
}
    
   
  


    

    