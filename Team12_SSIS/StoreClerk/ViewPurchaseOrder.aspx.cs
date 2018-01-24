using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewPurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["PONumber"] == null)
            {
                Response.Redirect("~/StoreClerk/ListOfPurchaseOrder.aspx");
            }
            else
            {
                int poNo = (int)Session["poNo"];
                BindGird(poNo);
            }



        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
            {
                PORecordDetail poR = (PORecordDetail)e.Row.DataItem;
                string itemId = poR.ItemID;
                double poRPrice = (double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * poR.Quantity);

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = InventoryLogic.GetItemName(itemId);
                Label UnpLbl = (e.Row.FindControl("UnpLbl") as Label);
                if (UnpLbl != null)
                    UnpLbl.Text = PurchasingLogic.GetUnitPrice(itemId, "BANE").ToString();
                Label PriceLbl = (e.Row.FindControl("PriceLbl") as Label);
                if (PriceLbl != null)
                {

                    PriceLbl.Text = ((double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * poR.Quantity)).ToString();

                }
            }
        }
        protected void BindGird(int poNo)
        {
            PORecord poRecord = PurchasingLogic.GetPurchaseOrderRecord(poNo);
            List<PORecordDetail> poRecordDetaillist = PurchasingLogic.GetListOfPORecorDetails(poNo);

            RequestOrProcessedView(poRecord);
            GridViewVPO.DataSource = poRecordDetaillist;
            GridViewVPO.DataBind();
        }


        protected string GetTotal()
        {
            PurchasingLogic p = new PurchasingLogic();
            int temp = Convert.ToInt32(LblNumber.Text);
            double res = p.FindTotalByPONum(temp);
            return res.ToString("C0");
        }
        protected void RequestOrProcessedView(PORecord poRecord)
        {
            string userName = User.Identity.Name;
            LblRequest.Text = userName;
            LblStatus.Text = poRecord.Status;
           
            switch (poRecord.Status)
            {
                case ("Approved"):
                    {
                        LblVpo.Text = "View Stationary Purchase Order ";
                        LblPON.Text = "PO Number: ";
                        LblNumber.Text = PurchasingLogic.GetPORecordApproveID(poRecord.PONumber).ToString();
                        break;
                    }
                case ("Rejected"):
                    {
                        LblVpo.Text = "Inventory Adjustment Voucher Request";
                        LblPON.Text = "PO Number: ";
                        LblNumber.Text = poRecord.PONumber.ToString();
                        break;
                    }
                case ("Cancelled"):
                    {
                        LblVpo.Text = "Inventory Adjustment Voucher Request";
                        LblPON.Text = "PO Number: ";
                        LblNumber.Text = poRecord.PONumber.ToString();
                        break;
                    }
                default:
                    {
                        LblVpo.Text = "Inventory Adjustment Voucher Request";
                        LblPON.Text = "PO Number: ";
                        LblNumber.Text = poRecord.PONumber.ToString();
                        LblRequest.Visible = false;
                        
                        break;
                    }
            }
        }
    }
}


        