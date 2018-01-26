using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreManager
{
    public partial class ListOfAdjustmentVouchers : System.Web.UI.Page
    { 
            List<AVRequest> requestList=null;
            string id = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindGrid();
                DdlStatus.SelectedValue = "ForApproval";
                GetForApprovalList();
                GridBind(requestList);

                LblMsg.Visible = false;
            }
        
        }

        protected void BindGrid()
        {
            List<AVRequest> avRequestList = InventoryLogic.GetListOfAdjustmentRequests();
            avRequestList = avRequestList.Where(x => x.Status == "Pending").ToList();
            GridViewAdjV.DataSource = avRequestList;
            GridViewAdjV.DataBind();
       }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton LBtnRequestId = (e.Row.FindControl("LBtnRequestId") as LinkButton);
            LinkButton LBtnVoucherId = (e.Row.FindControl("LBtnVoucherId") as LinkButton);
            Label LblProcessDate = (e.Row.FindControl("LblProcessDate") as Label);
            if (e.Row.RowType == DataControlRowType.DataRow && ((AVRequest)e.Row.DataItem).Status == "Approved")
            {
                AVRequest avR = (AVRequest)e.Row.DataItem;
                LBtnRequestId.Visible = false;
                LBtnVoucherId.Visible = true;
                LBtnVoucherId.Text = "AV" + InventoryLogic.GetAdjustmentVoucherApproveID(avR.AVRID).ToString("0000");
            }
            if (e.Row.RowType == DataControlRowType.DataRow && ((AVRequest)e.Row.DataItem).DateProcessed != null)
            {
                AVRequest avR = (AVRequest)e.Row.DataItem;
                DateTime processedDate = (DateTime)((AVRequest)e.Row.DataItem).DateProcessed;
                LblProcessDate.Text = processedDate.ToString("d");
            }
        }

        protected void GridViewAdjV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                Session["AdjustVID"] = int.Parse(e.CommandArgument.ToString());
                Server.Transfer("ViewAdjustmentVoucherDetails.aspx", true);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAdjV.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void DdlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = DdlStatus.SelectedValue;
            
            //List<AVRequest> requestList = (status == "All" ? InventoryLogic.GetListOfAdjustmentRequests() : InventoryLogic.GetListOfAdjustmentRequests(status));
            if (status=="All")
            {
                requestList = InventoryLogic.GetListOfAdjustmentRequests();
                LblMsg.Visible = false;
            }
            else if(status== "Pending" | status == "Approved" | status == "Rejected")
            {
                requestList = InventoryLogic.GetListOfAdjustmentRequests(status);
                LblMsg.Visible = false;

            }
            else if(status == "For Approval")
            {

                GetForApprovalList();
            }
            GridBind(requestList);
           
        }

        public void GridBind(List<AVRequest> requestList)
        {
            GridViewAdjV.DataSource = requestList;
            GridViewAdjV.DataBind();
        }



        public void GetForApprovalList()
        {

            if (User.IsInRole("Supervisor"))
            {
                id = "Supervisor";
            }
            if (User.IsInRole("Manager"))
            {
                id = "Manager";
            }
            requestList = InventoryLogic.GetadvReq(id);
            if (requestList.Count == 0)
            {
                LblMsg.Visible = true;
                LblMsg.Text = "You have no more pending request for approval!";
            }
        }
    }
}
