//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewAdjustmentVoucherDetails : System.Web.UI.Page
    {
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;

            if (Session["AdjustVID"] == null)
            {
                Response.Redirect("~/StoreClerk/ListOfAdjustmentVouchers.aspx");
            }
            else
            {
                int avRId = (int)Session["AdjustVID"];
                BindGird(avRId);
            }

            //If it is redirected from Create Adjustment Voucher Page.
            if (Session["AdjVSuccess"] != null)
            {
                string statusMsg = (string)Session["AdVSuccess"];
                statusMessage.Text = statusMsg;
                statusMessage.ForeColor = Color.Green;
                statusMessage.Visible = true;
                Session["AdjVSuccess"] = null;
            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((AVRequestDetail)e.Row.DataItem).ItemID != null)
            {
                AVRequestDetail avR = (AVRequestDetail)e.Row.DataItem;
                string itemId = avR.ItemID;
                string itemName = InventoryLogic.GetItemName(itemId);
                string adjValue = ((double)(InventoryLogic.GetInventoryPrice(itemId) * avR.Quantity)).ToString("c");

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = itemName;
                Label LblValue = (e.Row.FindControl("LblValue") as Label);
                if (LblValue != null)
                    LblValue.Text = adjValue;
            }
        }

        protected void BindGird(int avRId)
        {
            AVRequest aVRequest = InventoryLogic.GetAdjustmentVoucherRequest(avRId);
            List<AVRequestDetail> aVRDetaillist = InventoryLogic.GetAdjustmentVoucherDetailsList(avRId);
            //Set the approriate display
            RequestOrProcessedView(aVRequest);
            GridViewAdjV.DataSource = aVRDetaillist;
            GridViewAdjV.DataBind();
        }

        protected void RequestOrProcessedView(AVRequest aVRequest)
        {
            DateTime dateReq = (DateTime)aVRequest.DateRequested;
            LblDateReq.Text = dateReq.ToString("d");
            LblReqBy.Text = aVRequest.RequestedBy;
            LblStatus.Text = aVRequest.Status;
            switch (aVRequest.Status)
            {
                case ("Approved"):
                    {
                        LblPageTitle.Text = "Inventory Adjustment Voucher";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher ID: ";
                        LblRequestID.Text = "AV" + InventoryLogic.GetAdjustmentVoucherApproveID(aVRequest.AVRID).ToString("0000");
                        LblHandledBy.Text = aVRequest.HandledBy;
                        LblRemarks.Text = aVRequest.Remarks;
                        LblRmk.Visible = true;
                        LblRemarks.Visible = true;
                        DateTime dateProcessed = (DateTime)aVRequest.DateProcessed;
                        LblDateProcessed.Text = dateProcessed.ToString("d");
                        break;
                    }
                case ("Rejected"):
                    {
                        LblPageTitle.Text = "Inventory Adjustment Voucher Request";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = "AVR" + aVRequest.AVRID.ToString("0000");
                        LblHandledBy.Text = aVRequest.HandledBy;
                        LblRemarks.Text = aVRequest.Remarks;
                        LblRmk.Visible = true;
                        LblRemarks.Visible = true;
                        DateTime dateProcessed = (DateTime)aVRequest.DateProcessed;
                        LblDateProcessed.Text = dateProcessed.ToString("d");
                        break;
                    }
                case ("Cancelled"):
                    {
                        LblPageTitle.Text = "Inventory Adjustment Voucher Request";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = "AVR" + aVRequest.AVRID.ToString("0000");
                        LblHandledByLabel.Visible = false;
                        LblHandledBy.Visible = false;
                        LblDateProcessedLabel.Visible = false;
                        LblDateProcessed.Visible = false;
                        BtnCancelReq.Visible = false;
                        break;
                    }
                default:
                    {

                        LblPageTitle.Text = "Inventory Adjustment Voucher Request";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = "AVR" + aVRequest.AVRID.ToString("0000");
                        LblHandledByLabel.Visible = false;
                        LblHandledBy.Visible = false;
                        LblDateProcessedLabel.Visible = false;
                        LblDateProcessed.Visible = false;
                        LblRmk.Visible = false;
                        LblRemarks.Visible = false;
                        BtnCancelReq.Visible = true;
                        break;
                    }
            }
        }

        protected void BtnCancelReq_Click(object sender, EventArgs e)
        {
            int aVRId = Utility.Utility.GetValidPrimaryKeyInt(LblRequestID.Text);
            if (InventoryLogic.CancelAdjustmentVoucherRequest(aVRId))
            {
                statusMessage.ForeColor = Color.Green;
                statusMessage.Text = "Inventory Adjustment Voucher Request ID: " + aVRId.ToString() + " has been cancelled.";
            }
            else
            {
                statusMessage.ForeColor = Color.Red;
                statusMessage.Text = "Inventory Adjustment Voucher Request ID: " + aVRId.ToString() + " cannot be cancelled.";
            }
            Response.Redirect("~/StoreClerk/ViewAdjustmentVoucherDetails.aspx");
        }       
    }
}