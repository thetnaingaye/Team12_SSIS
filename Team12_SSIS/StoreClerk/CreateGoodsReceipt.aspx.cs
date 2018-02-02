//Author Lim Chang Siang
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

        protected void BtnRetrievePO_Click(object sender, EventArgs e)
        {
            PurchasingLogic pl = new PurchasingLogic();
            List<PORecordDetail> poDetailList = pl.GetPurchaseOrdersForGR(int.Parse(TxtPONumber.Text.ToString()));
            if (poDetailList.Count == 0)
            {
                statusMessage.Text = "No such Purchase Order exist.";
                statusMessage.ForeColor = Color.Red;
                DisplayEmptyGrid();
            }
            else
            {
                GridViewGR.DataSource = poDetailList;
                GridViewGR.DataBind();
                BtnPostGR.Visible = true;
            }
            HiddenFieldPONumber.Value = TxtPONumber.Text;
            statusMessage.Visible = false;
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
            if (!ValidQty())
                return;

            DateTime date = DateTime.ParseExact(Request.Form["datepicker"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            string doNumber = TxtDoNumber.Text;
            int poNumber = int.Parse(HiddenFieldPONumber.Value.ToString());
            PurchasingLogic pl = new PurchasingLogic();
            InventoryLogic il = new InventoryLogic();
            PORecord pr = pl.GetPORecords(poNumber);

            if (!Utility.Validator.IsDateRangeValid(date, DateTime.Now.Date, true))
            {
                statusMessage.Text = "Error! You cannot make a future date Goods Receipt!";
                statusMessage.ForeColor = Color.Red;
                statusMessage.Visible = true;
                return;
            }            
            int grNumber = pl.CreateGoodsReceipt(date, poNumber, clerkName, doNumber);
            foreach (GridViewRow r in GridViewGR.Rows)
            {
                string itemID = (r.FindControl("LblItemCode") as Label).Text;
                int quantity = int.Parse((r.FindControl("TxtQty") as TextBox).Text);
                string uom = (r.FindControl("LblUom") as Label).Text;
                string remarks = (r.FindControl("TxtRemarks") as TextBox).Text;

                pl.CreateGoodsReceiptDetails(grNumber, itemID, quantity, uom, remarks);

                string stockCardDesc = "Goods Receipt - GR" + grNumber.ToString("0000") + " Supplier " + pr.SupplierID;
                il.UpdateStockCard(stockCardDesc, itemID, date, "Add", quantity, uom);
            }
            //Here will check if the PO is already completed
            pl.GetPurchaseOrdersForGR(poNumber);
            poNumber = -1;
            LblQtyValid.Visible = false;
            DisplaySuccessMessage(grNumber);
            DisplayEmptyGrid();
        }

        bool ValidQty()
        {
            bool isValid = true;
            foreach (GridViewRow r in GridViewGR.Rows)
            {
                string itemName = (r.FindControl("LblDesc") as Label).Text;
                int quantityOrd = int.Parse((r.FindControl("LblOrd") as Label).Text);
                int quantityRecd = int.Parse((r.FindControl("TxtQty") as TextBox).Text);

                if (Utility.Validator.IsIntMoreThan(quantityRecd, quantityOrd) || quantityRecd < 0)
                {
                    LblQtyValid.Text = "Error! Invalid Goods Receipt Quantity " + itemName;
                    LblQtyValid.ForeColor = Color.Red;
                    LblQtyValid.Visible = true;
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }

        void DisplaySuccessMessage(int grNumber)
        {
            statusMessage.Text = "Goods Receipt GR" + grNumber.ToString("0000") + " Posted Successfully.";
            statusMessage.ForeColor = Color.Green;
            statusMessage.Visible = true;
            BtnPostGR.Visible = false;
            TxtPONumber.Text = string.Empty;
            TxtDoNumber.Text = string.Empty;
            DisplayEmptyGrid();

        }
    }
}