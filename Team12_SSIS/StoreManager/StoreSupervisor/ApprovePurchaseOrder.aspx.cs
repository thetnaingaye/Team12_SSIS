using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreManager.StoreSupervisor
{
    public partial class ApprovePurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    BindGrid();
            //}

        }
    }
    //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
    //    {
    //        PORecordDetail poR = (PORecordDetail)e.Row.DataItem;
    //        string itemId = poR.ItemID;
    //        double poRPrice = (double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * poR.Quantity);

    //        Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
    //        if (LblDesc != null)
    //            LblDesc.Text = InventoryLogic.GetItemName(itemId);
    //        Label UnpLbl = (e.Row.FindControl("UnpLbl") as Label);
    //        if (UnpLbl != null)
    //            UnpLbl.Text = PurchasingLogic.GetUnitPrice(itemId, "BANE").ToString();
    //        Label PriceLbl = (e.Row.FindControl("PriceLbl") as Label);
    //        if (PriceLbl != null)
    //        {

    //            PriceLbl.Text = ((double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * poR.Quantity)).ToString();

    //        }
    //    }
    //}
    //protected void BindGird(int poNo)
    //{
    //    PORecord poRecord = PurchasingLogic.GetPurchaseOrderRecord(poNo);
    //    List<PORecordDetail> poRecordDetaillist = PurchasingLogic.GetListOfPORecorDetails(poNo);

    //    RequestOrProcessedView(poRecord);
    //    GridViewVPO.DataSource = poRecordDetaillist;
    //    GridViewVPO.DataBind();
    //}

}
