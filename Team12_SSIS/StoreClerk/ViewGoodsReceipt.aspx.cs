//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewGoodsReceipt : System.Web.UI.Page
    {
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
        }

        protected void BtnRetrieveGR_Click(object sender, EventArgs e)
        {
            statusMessage.Text = string.Empty;
            PurchasingLogic pl = new PurchasingLogic();
            int grNumber = Utility.Utility.GetValidPrimaryKeyInt(TxtGRNumber.Text);
            GoodReceipt goodReceipt = pl.GetGoodsReceipt(grNumber);
            List<GoodReceiptDetail> grDetailList = pl.GetGoodsReceiptDetails(grNumber);
            if (grDetailList.Count == 0 || grNumber == -1)
            {
                ClearAllControls();
                statusMessage.Text = "No such Goods Receipt number exist.";
                statusMessage.ForeColor = Color.Red;
                DisplayEmptyGrid();
            }
            else
            {
                LblDoNumber.Text = goodReceipt.DONumber;
                LblPoNumber.Text = goodReceipt.PONumber.ToString();
                LblClerkName.Text = goodReceipt.ReceivedBy;
                LblGRDate.Text = ((DateTime)goodReceipt.DateProcessed).ToString("d");
                GridViewGR.DataSource = grDetailList;
                GridViewGR.DataBind();
            }

        }
        protected void DisplayEmptyGrid()
        {
            List<GoodReceiptDetail> emptyList = new List<GoodReceiptDetail>();
            GoodReceiptDetail n = new GoodReceiptDetail();
            emptyList.Add(n);
            GridViewGR.DataSource = emptyList;
            GridViewGR.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((GoodReceiptDetail)e.Row.DataItem).ItemID != null)
            {
                GoodReceiptDetail pR = (GoodReceiptDetail)e.Row.DataItem;
                string itemId = pR.ItemID;
                string itemName = InventoryLogic.GetItemName(itemId);

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = itemName;

            }
        }

        protected void ClearAllControls()
        {
            LblDoNumber.Text = string.Empty;
            LblPoNumber.Text = string.Empty;
            LblClerkName.Text = string.Empty;
            LblGRDate.Text = string.Empty;
        }
    }
}