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
    public partial class CreateAdjustmentVoucherRequest : System.Web.UI.Page
    {
        Label statusMessage; 
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (!IsPostBack)
            {
                BindGrid();
            }
            Up1.Update();
        }

        protected void BindGrid()
        {
            AVRequestDetail adjVDetail = new AVRequestDetail();
            List<AVRequestDetail> adjDetailList = new List<AVRequestDetail>();
            adjDetailList.Add(adjVDetail);
            GridViewAdjV.DataSource = adjDetailList;
            GridViewAdjV.DataBind();
        }

        protected void BtnAddItem_Click(object sender, EventArgs e)
        {
            List<AVRequestDetail> adjDetailList = new List<AVRequestDetail>();
            foreach (GridViewRow r in GridViewAdjV.Rows)
            {
                AVRequestDetail adjVDetail = new AVRequestDetail();
                adjVDetail.ItemID = (r.FindControl("TxtItemCode") as TextBox).Text;
                adjVDetail.Type = (r.FindControl("DdlAdjType") as DropDownList).SelectedValue;
                adjVDetail.Quantity = int.Parse((r.FindControl("TxtAdjQty") as TextBox).Text);
                adjVDetail.Reason = (r.FindControl("TxtReason") as TextBox).Text;
                adjVDetail.UOM = (r.FindControl("LblUOM") as Label).Text;
                adjDetailList.Add(adjVDetail);
            }
            AVRequestDetail adjVDetailNew = new AVRequestDetail();
            adjDetailList.Add(adjVDetailNew);
            GridViewAdjV.DataSource = adjDetailList;
            GridViewAdjV.DataBind();
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
                DropDownList DdlType = (e.Row.FindControl("DdlAdjType") as DropDownList);
                if (DdlType != null)
                    DdlType.Text = avR.Type;
            }
        }
        protected void TxtItemCode_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            TextBox txtItemCode = currentRow.FindControl("TxtItemCode") as TextBox;
            InventoryCatalogue inventoryItem = InventoryLogic.GetInventoryItem(txtItemCode.Text);
            string itemName = inventoryItem.Description;
            string uom = inventoryItem.UOM;
            Label lblDesc = currentRow.FindControl("LblDesc") as Label;
            Label lblUOM = currentRow.FindControl("LblUOM") as Label;
            if (lblDesc != null)
                lblDesc.Text = itemName;
            if (lblUOM != null)
                lblUOM.Text = uom;
        }

        protected void TxtAdjQty_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            TextBox txtItemCode = currentRow.FindControl("TxtItemCode") as TextBox;
            TextBox txtAdjQty = currentRow.FindControl("TxtAdjQty") as TextBox;
            string adjValue = (InventoryLogic.GetInventoryPrice(txtItemCode.Text) * double.Parse(txtAdjQty.Text)).ToString();

            Label LblValue = currentRow.FindControl("LblValue") as Label;
            if (LblValue != null)
                LblValue.Text = adjValue;
        }

        protected void BtnSendReq_Click(object sender, EventArgs e)
        {
            InventoryLogic il = new InventoryLogic();
            List<AVRequestDetail> adjDetailList = new List<AVRequestDetail>();
            string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            int avRId = il.CreateAdjustmentVoucherRequest(clerkName, DateTime.Now.Date);
            bool isAbove250 = false;

            foreach (GridViewRow r in GridViewAdjV.Rows)
            {                
                string itemID = (r.FindControl("TxtItemCode") as TextBox).Text;
                string type = (r.FindControl("DdlAdjType") as DropDownList).SelectedValue;
                int quantity = int.Parse((r.FindControl("TxtAdjQty") as TextBox).Text);
                string uom = (r.FindControl("LblUOM") as Label).Text;
                string reason = (r.FindControl("TxtReason") as TextBox).Text;
                double unitPrice = InventoryLogic.GetInventoryPrice(itemID); 
                il.CreateAdjustmentVoucherRequestDetails(avRId, itemID, type, quantity, uom, reason, unitPrice);
                isAbove250 = (quantity * unitPrice > 250 ? true : false);
            }

            il.SendAdjRequentEmail(avRId, isAbove250, clerkName);

            Session["AdjustVID"] = avRId;
            Server.Transfer("ViewAdjustmentVoucherDetails.aspx", true);
            statusMessage.ForeColor = Color.Green;
            statusMessage.Text = "Request Sent. Inventory Adjustment Voucher Request ID: " + avRId.ToString() + " has been created";
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label LblSn = GridViewAdjV.Rows[e.RowIndex].Cells[0].FindControl("LblSn") as Label;
            int sN = int.Parse(LblSn.Text);

            List<AVRequestDetail> adjDetailList = new List<AVRequestDetail>();
            foreach (GridViewRow r in GridViewAdjV.Rows)
            {
                AVRequestDetail adjVDetail = new AVRequestDetail();
                adjVDetail.ItemID = (r.FindControl("TxtItemCode") as TextBox).Text;
                adjVDetail.Type = (r.FindControl("DdlAdjType") as DropDownList).SelectedValue;
                adjVDetail.Quantity = int.Parse((r.FindControl("TxtAdjQty") as TextBox).Text);
                adjVDetail.Reason = (r.FindControl("TxtReason") as TextBox).Text;
                adjVDetail.UOM = (r.FindControl("LblUOM") as Label).Text;
                adjDetailList.Add(adjVDetail);
            }
            AVRequestDetail adjVDetailNew = new AVRequestDetail();
            adjDetailList.RemoveAt(sN - 1);
            GridViewAdjV.DataSource = adjDetailList;
            GridViewAdjV.DataBind();
        }
    }
}