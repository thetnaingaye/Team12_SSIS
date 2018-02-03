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
            try
            {
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
            }catch (Exception ex)
            {
                statusMessage.Text = "Error! Please enter an item before added new line item.";
                statusMessage.ForeColor = Color.Red;
                statusMessage.Visible = true;
                Console.WriteLine(ex.ToString());
                return;
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
                string adjValue = ((double)(InventoryLogic.GetInventoryPrice(itemId) * avR.Quantity)).ToString("c");

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
            statusMessage.Visible = false;
            try
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
            }catch(Exception ex)
            {
                statusMessage.ForeColor = Color.Red;
                statusMessage.Text = "Invalid Item Code Entered: ";
                Console.WriteLine(ex.ToString());
                statusMessage.Visible = true;
            }
        }

        protected void TxtAdjQty_TextChanged(object sender, EventArgs e)
        {
            statusMessage.Visible = false;

            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            TextBox txtItemCode = currentRow.FindControl("TxtItemCode") as TextBox;
            TextBox txtAdjQty = currentRow.FindControl("TxtAdjQty") as TextBox;
            int AdjQty;
            bool isInteger = int.TryParse(txtAdjQty.Text, out AdjQty);
            if (!isInteger)
            {
                statusMessage.Text = "Invalid Quantity.";
                statusMessage.ForeColor = Color.Red;
                statusMessage.Visible = true;
                return;
            }
            string adjValue = (InventoryLogic.GetInventoryPrice(txtItemCode.Text) * AdjQty).ToString("c");

            Label LblValue = currentRow.FindControl("LblValue") as Label;
            if (LblValue != null)
                LblValue.Text = adjValue;
        }

        protected void BtnSendReq_Click(object sender, EventArgs e)
        {
            statusMessage.Visible = false;
            InventoryLogic il = new InventoryLogic();
            string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            int avRId = InventoryLogic.CreateAdjustmentVoucherRequest(clerkName, DateTime.Now.Date);
            bool isAbove250 = false;
            try
            {
                foreach (GridViewRow r in GridViewAdjV.Rows)
                {
                    string itemID = (r.FindControl("TxtItemCode") as TextBox).Text;
                    string itemName = (r.FindControl("LblDesc") as Label).Text;
                    string type = (r.FindControl("DdlAdjType") as DropDownList).SelectedValue;
                    int quantity = int.Parse((r.FindControl("TxtAdjQty") as TextBox).Text);
                    string uom = (r.FindControl("LblUOM") as Label).Text;
                    string reason = (r.FindControl("TxtReason") as TextBox).Text;
                    double unitPrice = InventoryLogic.GetInventoryPrice(itemID);

                    if (!InventoryLogic.IsUnitsInStock(itemID, quantity) && type == "Minus")
                    {
                        statusMessage.Text = "Error! Insufficient stock for adjustment. " + itemName;
                        statusMessage.ForeColor = Color.Red;
                        statusMessage.Visible = true;
                        return;
                    }

                    InventoryLogic.CreateAdjustmentVoucherRequestDetails(avRId, itemID, type, quantity, uom, reason, unitPrice);
                    isAbove250 = (quantity * unitPrice > 250 ? true : false);
                    InventoryLogic.SendAdjRequentEmail(avRId, isAbove250, clerkName);
                }
            }catch (Exception ex)
            {
                statusMessage.Text = "Error! Invalid Submission Request.";
                statusMessage.ForeColor = Color.Red;
                statusMessage.Visible = true;
                Console.WriteLine(ex.ToString());
                return;
            }

            string successMsg = "Request Sent. Inventory Adjustment Voucher Request ID: " + avRId.ToString() + " has been created";
            Session["AdjustVID"] = avRId;
            Session["AdjVSuccess"] = successMsg;
            Response.Redirect("~/StoreClerk/ViewAdjustmentVoucherDetails.aspx");
            BtnSendReq.Enabled = true;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            statusMessage.Visible = false;

            try
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
            }catch(Exception ex)
            {
                statusMessage.Text = "Invalid delete action.";
                statusMessage.ForeColor = Color.Red;
                statusMessage.Visible = true;
            }
        }
    }
}