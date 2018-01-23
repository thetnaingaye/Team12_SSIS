using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;

namespace Team12_SSIS.StoreClerk
{
    public partial class ChangeOrderLeadTime : System.Web.UI.Page
    {
		
		protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				SuppliersDdl.DataSource = PurchasingLogic.ListSuppliers();
				SuppliersDdl.DataTextField = "SupplierName";
				SuppliersDdl.DataValueField = "SupplierID";
				SuppliersDdl.DataBind();
				LblCurrentOrderLeadTime.Text = PurchasingLogic.GetCurrentOrderLeadTime(SuppliersDdl.SelectedValue).ToString();

			}
			else
				ChangedLbl.Visible = true;
			
			
        }

		protected void SaveBtn_Click(object sender, EventArgs e)
		{
			int orderLeadTime = Int32.Parse(OrderLeadTimeTxt.Text);
			string supplier = SuppliersDdl.SelectedValue;
			PurchasingLogic.UpdateOrderLeadTime(orderLeadTime, supplier);
			ChangedLbl.Text = "Supplier " + SuppliersDdl.SelectedItem + "'s Order Lead Time has changed to " + orderLeadTime.ToString() + " day(s).";
			//Response.Redirect("~/StoreClerk/ChangeOrderLeadTime.aspx");
			
		}

		protected void SuppliersDdl_SelectedIndexChanged(object sender, EventArgs e)
		{
			LblCurrentOrderLeadTime.Text = PurchasingLogic.GetCurrentOrderLeadTime(SuppliersDdl.SelectedValue).ToString();
		}
	}
}