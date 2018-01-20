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

namespace Team12_SSIS.StoreClerk
{
    public partial class CreateGoodsReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }

        protected void TxtGRDate_OnClick(object sender, EventArgs e)
        {
            datepicker.Value.ToString();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            PurchasingLogic pl = new PurchasingLogic();
            GridViewGR.DataSource = pl.GetPurchaseOrdersForGR(1);
            GridViewGR.DataBind();
        }

        protected void BindGrid()
        {
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PORecordDetail pR = (PORecordDetail)e.Row.DataItem;
                string itemId = pR.ItemID;
                string itemName = InventoryLogic.GetItemName(itemId);

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = itemName;

            }*/
        }
    }
}