using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;
using System.Drawing;

namespace Team12_SSIS.StoreManager
{
    public partial class ViewAdjustmentVoucherDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdjustVID"] == null)
            {
                Response.Redirect("~/StoreManager/ListOfAdjustmentVouchers.aspx");
            }
            else
            {
                int avRId = (int)Session["AdjustVID"];
                BindGird(avRId);
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((AVRequestDetail)e.Row.DataItem).ItemID != null)
            {
                AVRequestDetail avR = (AVRequestDetail)e.Row.DataItem;
                string itemId = avR.ItemID;
                string itemName = InventoryLogic.GetItemName(itemId);
                string adjValue = (InventoryLogic.GetInventoryPrice(itemId) * avR.Quantity).ToString();

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
                        LblRequestID.Text = InventoryLogic.GetAdjustmentVoucherApproveID(aVRequest.AVRID).ToString();
                        LblHandledBy.Text = aVRequest.HandledBy;
                        DateTime dateProcessed = (DateTime)aVRequest.DateProcessed;
                        LblDateProcessed.Text = dateProcessed.ToString("d");
                        break;
                    }
                case ("Rejected"):
                    {
                        LblPageTitle.Text = "Inventory Adjustment Voucher Request";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledBy.Text = aVRequest.HandledBy;
                        DateTime dateProcessed = (DateTime)aVRequest.DateProcessed;
                        LblDateProcessed.Text = dateProcessed.ToString("d");
                        break;
                    }
                case ("Cancelled"):
                    {
                        LblPageTitle.Text = "Inventory Adjustment Voucher Request";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledByLabel.Visible = false;
                        LblHandledBy.Visible = false;
                        LblDateProcessedLabel.Visible = false;
                        LblDateProcessed.Visible = false;
                      
                        break;
                    }
                case ("Pending"):
                    {
                        LblPageTitle.Text = "Inventory Adjustment Voucher Request";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledByLabel.Visible = false;
                        LblHandledBy.Visible = false;
                        LblDateProcessedLabel.Visible = false;
                        LblDateProcessed.Visible = false;


                        break;
                    }
                default:
                    {

                        LblPageTitle.Text = "Inventory Adjustment Voucher Request";
                        LblRequestIDLabel.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledByLabel.Visible = false;
                        LblHandledBy.Visible = false;
                        LblDateProcessedLabel.Visible = false;
                        LblDateProcessed.Visible = false;
                         break;
                    }
            }
        }

        protected void BtnCancelReq_Click(object sender, EventArgs e)
        {
            int aVRId = int.Parse(LblRequestID.Text);
            Label statusMessage = this.Master.FindControl("LblStatus") as Label;
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
            Response.Redirect("~/StoreManager/ViewAdjustmentVoucherDetails.aspx");
        }

        protected void Btnapprove_Click(object sender, EventArgs e)
        {

        }
    }

}
  

