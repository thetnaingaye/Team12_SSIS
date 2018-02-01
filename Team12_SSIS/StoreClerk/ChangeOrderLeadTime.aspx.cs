//Author - Pradeep Elango 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;
using System.Drawing;

namespace Team12_SSIS.StoreClerk
{
    public partial class ChangeOrderLeadTime : System.Web.UI.Page
    {
		Label statusMessage;
		protected void Page_Load(object sender, EventArgs e)
        {
			statusMessage = this.Master.FindControl("LblStatus") as Label;
			if (!IsPostBack)
			{
				statusMessage.Visible = false;
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
			int a;
			if (Int32.TryParse(OrderLeadTimeTxt.Text,out a)&&a>=0)
			{
				int orderLeadTime = a;
				string supplier = SuppliersDdl.SelectedValue;
				PurchasingLogic.UpdateOrderLeadTime(orderLeadTime, supplier);
				statusMessage.Text = "The Order Lead Time Of Supplier " + SuppliersDdl.SelectedItem + " has been changed to " + orderLeadTime.ToString() + " day(s).";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Green;
				LblCurrentOrderLeadTime.Text = PurchasingLogic.GetCurrentOrderLeadTime(SuppliersDdl.SelectedValue).ToString();
				
			}
			else
			{
				statusMessage.Text = "Please enter a positive integer or 0.";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Red;
			}

		}

		protected void SuppliersDdl_SelectedIndexChanged(object sender, EventArgs e)
		{
			LblCurrentOrderLeadTime.Text = PurchasingLogic.GetCurrentOrderLeadTime(SuppliersDdl.SelectedValue).ToString();
			
		}

		
	}
}