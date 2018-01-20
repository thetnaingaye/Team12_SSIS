using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Utility;
using Team12_SSIS.Model;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Globalization;

namespace Team12_SSIS.StoreClerk
{
    public partial class CreateGoodsReceipt : System.Web.UI.Page
    {
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (!IsPostBack)
            {
                statusMessage.Visible = false;
                DisplayEmptyGrid();
            }

        }

        protected void TxtGRDate_OnClick(object sender, EventArgs e)
        {
        }

        protected void BtnRetrievePO_Click(object sender, EventArgs e)
        {
            PurchasingLogic pl = new PurchasingLogic();
            List<PORecordDetail> poDetailList = pl.GetPurchaseOrdersForGR(int.Parse(TxtPONumber.Text.ToString()));
            if (poDetailList.Count == 0)
            {
                statusMessage.Text = "Invalid PO Number";
                statusMessage.ForeColor = Color.Red;
                DisplayEmptyGrid();
            }
            else
            {
                GridViewGR.DataSource = pl.GetPurchaseOrdersForGR(int.Parse(TxtPONumber.Text.ToString()));
                GridViewGR.DataBind();
                BtnPostGR.Visible = true;
            }
            HiddenFieldPONumber.Value = TxtPONumber.Text;
        }

        protected void DisplayEmptyGrid()
        {
            List<PORecordDetail> emptyList = new List<PORecordDetail>();
                PORecordDetail n = new PORecordDetail();
                emptyList.Add(n);
            GridViewGR.DataSource = emptyList;
            GridViewGR.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
            {
                PORecordDetail pR = (PORecordDetail)e.Row.DataItem;
                string itemId = pR.ItemID;
                string itemName = InventoryLogic.GetItemName(itemId);

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = itemName;

            }
        }

        protected void BtnPostGR_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.ParseExact(Request.Form["datepicker"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            string doNumber = TxtDoNumber.Text;
            int poNumber = int.Parse(HiddenFieldPONumber.Value.ToString());
            PurchasingLogic pl = new PurchasingLogic();
            InventoryLogic il = new InventoryLogic();
            PORecord pr = pl.GetPORecords(poNumber);

            int grNumber = pl.CreateGoodsReceipt(date, poNumber, clerkName, doNumber);
            foreach (GridViewRow r in GridViewGR.Rows)
            {
                string itemID = (r.FindControl("LblItemCode") as Label).Text;
                int quantity = int.Parse((r.FindControl("TxtQty") as TextBox).Text);
                string uom = (r.FindControl("LblUom") as Label).Text;
                string remarks = (r.FindControl("TxtRemarks") as TextBox).Text;
                pl.CreateGoodsReceiptDetails(grNumber, itemID, quantity, uom, remarks);

                string stockCardDesc = "Goods Receipt - " + grNumber + " Supplier " + pr.SupplierID;
                il.UpdateStockCard(stockCardDesc, itemID, date, "Add", quantity, uom);
            }
            poNumber = -1;
            statusMessage.Text = "Goods Receipt " + grNumber + " Posted Successfully.";
            statusMessage.ForeColor = Color.Green;
            statusMessage.Visible = true;
            DisplayEmptyGrid();
        }
    }
}