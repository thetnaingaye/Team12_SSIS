using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS.StoreManager.StoreSupervisor
{
    public partial class ApprovePurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["POnumber"] == null)
            {
                Response.Redirect("~/StoreClerk/ListOfPurchaseOrder.aspx");
            }
            else
            {
                int poNo = (int)Session["POnumber"];
                BindGird(poNo);
            }

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((ApprovePurchaseOrder)e.Row.DataItem).ItemID != null)
            {
                ApprovePurchaseOrder Apo= (ApprovePurchaseOrder)e.Row.DataItem;

                string itemId = Apo.ItemID;
                double ApoPrice = (double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * Apo.Quantity);

                Label DesLbl = (e.Row.FindControl("DesLbl") as Label);
                if (DesLbl != null)
                    DesLbl.Text = InventoryLogic.GetItemName(itemId);
                Label UnpLbl = (e.Row.FindControl("UnpLbl") as Label);
                if (UnpLbl != null)
                    UnpLbl.Text = PurchasingLogic.GetUnitPrice(itemId, "BANE").ToString();
                DropDownList DdlUOM = (e.Row.FindControl("DdlUOM") as DropDownList);
                if (DdlUOM != null)
                    DdlUOM.Text = poR.UOM;

                TextBox Txtquantity = e.Row.FindControl("Txtquantity") as TextBox;
                int Quantity = int.Parse(Txtquantity.Text);
                Label PriceLbl = (e.Row.FindControl("PriceLbl") as Label);
                if (PriceLbl != null)
                {

                    PriceLbl.Text = ((double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * Quantity)).ToString();
                    total += (PurchasingLogic.GetUnitPrice(itemId, "BANE") * Quantity);
                }

            }
        }
    }
    }
