using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewPurchaseOrder : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Populate();
                prevPage = Request.UrlReferrer.ToString();
            }
        }

        private void Populate()
        {
            if (Request.QueryString["ID"] != "")
            {
                int purchaseOrderID = int.Parse(Request.QueryString["ID"]);
                using (PurchaseOrderDetails pod = new PurchaseOrderDetails())
                {
                    PurchaseOrder po = pod.FindPurchaseOrderByDate(purchaseOrderDate);
                    PODateLbl.Text = po.PODate;
                    RequestLbl.Text = po.Requestedby.ToString();
                    StatusLbl.Text = po.POStatus.ToString();
                    CodeLbl.Text = po.SupplierID.ToString();
                    lblSupplier.Text = po.Supplier.CompanyName;
                    List<PurchaseOrderItem> items = po.PurchaseOrderItems.ToList<PurchaseOrderItem>();
                    this.gvPODetails.DataSource = items;
                    this.gvPODetails.DataBind();
                }
    }

    
}