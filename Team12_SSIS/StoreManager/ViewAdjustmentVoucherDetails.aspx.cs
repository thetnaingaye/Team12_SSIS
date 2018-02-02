
//-------------------------------Written by Thanisha-------------------------------------------------------------------//


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
        string remarks;
        protected void Page_Load(object sender, EventArgs e)
        {
//--------------------------Getting AdjustmentVoucherId from teh session----------------------------------------------//
            int avID = (int)Session["AdjustVID"];
            BindGrid(avID);
        }

//----------------------Bibding datatgrid with data-------------------------------------------------------------------//
        protected void BindGrid(int avRId)
        {
            AVRequest aVRequest = InventoryLogic.GetAdjustmentVoucherRequest(avRId);
            List<AVRequestDetail> aVRDetaillist = InventoryLogic.GetAdjustmentVoucherDetailsList(avRId);
            statusView(aVRequest);
            GridViewAdjVoucher.DataSource = aVRDetaillist;
            GridViewAdjVoucher.DataBind();
        }

//-------------------Changing the view according the the adjustment voucher request.----------------------------------//
        protected void statusView(AVRequest aVRequest)
        {
            DateTime dateReq = (DateTime)aVRequest.DateRequested;
            LblDateReqD.Text = dateReq.ToString("d");
            LblReqByD.Text = aVRequest.RequestedBy;
            LblStatusD.Text = aVRequest.Status;
            switch (aVRequest.Status)
            {
                case ("Approved"):
                    {
                       
                        LblReqID.Text = "Inventory Adjustment Voucher ID: ";
                        LblRequestID.Text = InventoryLogic.GetAdjustmentVoucherApproveID(aVRequest.AVRID).ToString();
                        LblHandledByD.Text = aVRequest.HandledBy;
                        DateTime dateProcessed = (DateTime)aVRequest.DateProcessed;
                        LblDateProcessedD.Text = dateProcessed.ToString("d");
                        Btnapprove.Visible = false;
                        Btnreject.Visible = false;
                        TxtRemarks.Visible = false;
                        LblRemarks.Visible = false;
                        LblMsg.Visible = false;
                        break;
                    }
                case ("Rejected"):
                    {
                      
                        LblReqID.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledByD.Text = aVRequest.HandledBy;
                        DateTime dateProcessed = (DateTime)aVRequest.DateProcessed;
                        LblDateProcessedD.Text = dateProcessed.ToString("d");
                        Btnapprove.Visible = false;
                        Btnreject.Visible = false;
                        LblMsg.Visible = false;
                        TxtRemarks.Visible = false;
                        LblRemarks.Visible = false;
                        break;
                    }
                case ("Cancelled"):
                    {
                        
                        LblReqID.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledByD.Text = aVRequest.HandledBy;
                        DateTime dateProcessed = (DateTime)aVRequest.DateProcessed;
                        LblDateProcessedD.Text = dateProcessed.ToString("d");
                        Btnapprove.Visible = false;
                        Btnreject.Visible = false;
                        LblMsg.Visible = false;
                        TxtRemarks.Visible = false;
                        LblRemarks.Visible = false;
                        break;
                    }

 //------------------------------------If it is the case of pending there are two cases.
 //-------------Pending request need to handle by the user and request that hasn't to be handle by the user logged in
                case ("Pending"):
                    {

 //---------checking weather the request is under the category of "For Approval.
 //----------------------------------------------If it is "Approve" or "Reject" button is visible----------------//
                        if (((User.IsInRole("Supervisor")&& (aVRequest.HandledBy=="Supervisor"))|((User.IsInRole("Manager") && (aVRequest.HandledBy == "Manager")))))
                            { 
                      
                        LblReqID.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledBy.Visible = false;
                        LblHandledByD.Visible = false;
                        LblDateProcessed.Visible = false;
                        LblDateProcessedD.Visible = false;
                        Btnapprove.Visible = true;
                        Btnreject.Visible = true;
                            LblMsg.Visible = false;
                           
                            break;
                        }
                        else
                        {
                           
                            LblReqID.Text = "Inventory Adjustment Voucher Request ID: ";
                            LblRequestID.Text = aVRequest.AVRID.ToString();

                            LblHandledBy.Visible = false;
                            LblHandledByD.Visible = false;
                            LblDateProcessed.Visible = false;
                            LblDateProcessedD.Visible = false;
                            Btnapprove.Visible = false;
                            Btnreject.Visible = false;
                            TxtRemarks.Visible = false;
                            LblRemarks.Visible = false;
                            LblMsg.Visible = false;
                            break;
                           
                        }
                    }
                default:
                    {

                      
                        LblReqID.Text = "Inventory Adjustment Voucher Request ID: ";
                        LblRequestID.Text = aVRequest.AVRID.ToString();
                        LblHandledBy.Visible = false;
                        LblHandledByD.Visible = false;
                        LblDateProcessed.Visible = false;
                        LblDateProcessedD.Visible = false;
                        Btnapprove.Visible = false;
                        Btnreject.Visible = false;
                        TxtRemarks.Visible = false;
                        LblMsg.Visible =false;
                        break;
                    }
            }
        }

//--------------------------OnRowDataBoundEvent------------------------------------------------------------------------//
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
                    LblValue.Text = "$"+adjValue;
            }
        }
//-------------------------------------Approve Button click event----------------------------------------------------//
        protected void Btnapprove_Click(object sender, EventArgs e)
        {
            Btnreject.Visible = false;
            Btnapprove.Visible = false;
            int avID = (int)Session["AdjustVID"];
            remarks = TxtRemarks.Text;
            InventoryLogic.ApproveAvRequest(avID,remarks);
            LblMsg.Visible = true;
            LblMsg.Text = "*Successfully approved the adjustment voucher request";
            LblStatusD.Text = "Approved";
        
        }
//------------------------------------Reject Button click event------------------------------------------------------//
        protected void Btnreject_Click(object sender, EventArgs e)
        {
            Btnreject.Visible = false;
            Btnapprove.Visible = false;
            int avID = (int)Session["AdjustVID"];
            remarks = TxtRemarks.Text;
            InventoryLogic.RejectAvRequest(avID,remarks);
            LblMsg.Visible = true;
            LblMsg.Text = "*Adjustment voucher request is rejected";
            LblStatusD.Text = "Rejected";

        }
    }
}

    
  

