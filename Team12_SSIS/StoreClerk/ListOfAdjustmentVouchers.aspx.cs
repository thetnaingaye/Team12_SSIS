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
    public partial class ListOfAdjustmentVouchers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
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
            if (e.Row.RowType == DataControlRowType.DataRow && ((AVRequest)e.Row.DataItem).Status == "Approved")
            {
                AVRequest avR = (AVRequest)e.Row.DataItem;
                LBtnRequestId.Visible = false;
                LBtnVoucherId.Visible = true;
                LBtnVoucherId.Text = "AV" + InventoryLogic.GetAdjustmentVoucherApproveID(avR.AVRID).ToString();
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

        }
    }
}
