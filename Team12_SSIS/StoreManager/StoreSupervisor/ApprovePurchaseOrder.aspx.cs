//Author: Li Jianing and Lim Chang Siang
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
        Label statusMessage;
        PurchasingLogic p = new PurchasingLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
           

            if (Session["POstatusMsg"] != null)
            {
                LblStatus.Text = (string)Session["POstatusMsg"];
                LblStatus.Visible = true;
                LblStatus.ForeColor = System.Drawing.Color.Green;
                Session["POstatusMsg"] = null;
            }
            if (!IsPostBack)
            {
                if(Session["PONumber"] != null)
                {
                    int PONumber = int.Parse(Session["PONumber"].ToString());
                    BindGrid(PONumber);
                    DisplayLabels(PONumber);
                }
            }

        }

        private void BindGrid(int pONumber)
        {
            List<PORecordDetail> poDetails = PurchasingLogic.GetListOfPORecorDetails(pONumber);
            GridViewAPO.DataSource = poDetails;
            GridViewAPO.DataBind();
        }

        void DisplayLabels(int pONumber)
        {
            PORecord poR = PurchasingLogic.ListPORecords().Where(x => x.PONumber == pONumber).FirstOrDefault();

            LblNumbeer.Text = pONumber.ToString();
            LblDate.Text = ((DateTime)poR.DateRequested).ToString("d");
            LblStatus.Text = poR.Status;
            LblDeliver.Text = poR.RecipientName;
            LblAddress.Text = poR.DeliveryAddress;
            LblRequest.Text = poR.CreatedBy;
            LblCode.Text = PurchasingLogic.ListSuppliers().Where(x => x.SupplierID == poR.SupplierID).Select(x => x.SupplierName).FirstOrDefault();
            if (poR.Status != "Pending")
            {
                btnapr.Visible = false;
                btncancel.Visible = false;
            }
            

        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
            {
                PORecordDetail poR = (PORecordDetail)e.Row.DataItem;
                string itemId = poR.ItemID;
                double poRPrice = (double)(poR.UnitPrice * poR.Quantity);

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = InventoryLogic.GetItemName(itemId);
                Label PriceLbl = (e.Row.FindControl("LblPrice") as Label);
                if (PriceLbl != null)
                {
                    PriceLbl.Text = ((double)(poR.UnitPrice * poR.Quantity)).ToString("c");
                }
            }
        }

        protected void btnapr_Click(object sender, EventArgs e)
        {
            //ponumber status dateprocessed handledby
            int poNumber = int.Parse(LblNumbeer.Text);
            string status = "Approved";
            LblStatus.Text = "Approved";
            DateTime dateProcessed = DateTime.Now.Date;
            string handledBy = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            PurchasingLogic.UpdatePurchaseOrderStatus(poNumber, status, dateProcessed, handledBy);
            statusMessage.Text = "Approved successfully";
            statusMessage.ForeColor = System.Drawing.Color.Green;
            btnapr.Visible = false;
            btncancel.Visible = false;


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            int poNumber = int.Parse(LblNumbeer.Text);
            string status = "Rejected";
            LblStatus.Text = "Rejected";
            DateTime dateProcessed = DateTime.Now.Date;
            string handledBy = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            PurchasingLogic.UpdatePurchaseOrderStatus(poNumber, status, dateProcessed, handledBy);
            statusMessage.Text = "Rejected successfully";
            statusMessage.ForeColor = System.Drawing.Color.Green;
            btnapr.Visible = false;
            btncancel.Visible = false;            
        }

    }
}
