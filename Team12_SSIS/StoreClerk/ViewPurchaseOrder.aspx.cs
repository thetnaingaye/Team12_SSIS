//Author: Li Jianing and Lim Chang Siang
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
        Label Status;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Status = this.Master.FindControl("LblStatus") as Label;
            if(!IsPostBack)
            {
                Status.Visible = false;
            }
            
            if(Session["POstatusMsg"]!=null)
            {
                Status.Text = (string)Session["POstatusMsg"];
                Status.Visible = true;
                Status.ForeColor=System.Drawing.Color.Green;
                Session["POstatusMsg"] = null;
            }
            if (Session["PONumber"] != null)
            {
                int PONumber = (int)Session["PONumber"];
                BindGird(PONumber);
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            double totalPrice = 0;
            if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
            {
                PORecordDetail poR = (PORecordDetail)e.Row.DataItem;
                string itemId = poR.ItemID;
                double poRPrice = (double) (poR.UnitPrice * poR.Quantity);

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = InventoryLogic.GetItemName(itemId);
                Label PriceLbl = (e.Row.FindControl("LblPrice") as Label);
                if (PriceLbl != null)
                {
                    PriceLbl.Text = ((double)(poR.UnitPrice * poR.Quantity)).ToString("c");
                }
                LblTotal.Text = PurchasingLogic.FindTotalByPONum(poR.PONumber).ToString("c");
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

        protected void RequestOrProcessedView(PORecord poRecord)
        {
            LblRst.Text = poRecord.CreatedBy;
            LblStatus.Text = poRecord.Status;
            LblDeliver.Text = poRecord.CreatedBy;
            LblAddress.Text = poRecord.DeliveryAddress;
            LblSupplier.Text = PurchasingLogic.ListSuppliers().Where(x => x.SupplierID == poRecord.SupplierID).Select(x => x.SupplierName).FirstOrDefault();
            LblSupply.Text = ((DateTime)poRecord.ExpectedDelivery).ToString("d");
            LblNumber.Text = poRecord.PONumber.ToString();
            }
        }
    }



        