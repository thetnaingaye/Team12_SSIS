//Author - Pradeep Elango and SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class ChangeBufferStockLevel : System.Web.UI.Page
    {
		Label statusMessage;
		protected void Page_Load(object sender, EventArgs e)
        {
			
			statusMessage = this.Master.FindControl("LblStatus") as Label;
			if (!IsPostBack)
			{
				TxtProportional.Visible = false;
				TxtAbsolute.Visible = false;
				statusMessage.Visible = false;
				MultiView1.ActiveViewIndex = 0;
			}
        }

		protected void FindBtn_Click(object sender, EventArgs e)
		{
			string itemcode = TxtItemCode.Text;
			int bufferstocklevel;
			LblItemCode.Text = itemcode;
			try
			{
				InventoryCatalogue i = InventoryLogic.GetInventoryItem(itemcode);
				bufferstocklevel = PurchasingLogic.GetCurrentBufferStock(itemcode);
				if (bufferstocklevel >= 0)
				{
					AutomationStatusLbl.Text = "The current buffer stock level is " + bufferstocklevel + ".";
				}
				else
				{
					AutomationStatusLbl.Text = "The buffer stock level is currently calculated automatically.";
				}
				LblItemDescription.Text = i.Description;
				MultiView1.ActiveViewIndex = 1;
				statusMessage.Visible = false;
			}
			catch
			{
				statusMessage.Text = "Item does not exist.";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Red;
			}
		}

		protected void BtnBack_Click(object sender, EventArgs e)
		{
			MultiView1.ActiveViewIndex = 0;
			statusMessage.Visible = false;
			TxtAbsolute.Text = "";
			TxtProportional.Text = "";
		}

		protected void ProportionalRbtn_CheckedChanged(object sender, EventArgs e)
		{
			if (ProportionalRbtn.Checked)
			{
				TxtProportional.Visible = true;
				TxtAbsolute.Visible = false;
			}
			else if (!ProportionalRbtn.Checked)
			{
				TxtProportional.Visible = false;
			}
		}

		protected void AbsoluteRbtn_CheckedChanged(object sender, EventArgs e)
		{
			if (AbsoluteRbtn.Checked)
			{
				TxtAbsolute.Visible = true;
				TxtProportional.Visible = false;

			}
			else if (!AbsoluteRbtn.Checked)
			{
				TxtAbsolute.Visible = false;
			}
		}

		protected void AutomationRbtn_CheckedChanged(object sender, EventArgs e)
		{
			TxtProportional.Visible = false;
			TxtAbsolute.Visible = false;
		}

		protected void SaveBtn_Click(object sender, EventArgs e)
		{
			int newbufferstocklevel;
			int proportional;
			if(AbsoluteRbtn.Checked)
			{
				if(Int32.TryParse(TxtAbsolute.Text,out newbufferstocklevel))
				{
					PurchasingLogic.UpdateBufferStockLevel(TxtItemCode.Text, newbufferstocklevel);
					AutomationStatusLbl.Text = "The current buffer stock level is " + newbufferstocklevel.ToString() + ".";
					statusMessage.Text = "The buffer stock level has been changed to "+newbufferstocklevel+".";
					statusMessage.Visible = true;
					statusMessage.ForeColor = Color.Green;
				}
				else
				{
					statusMessage.Text = "Please enter a positive integer or 0.";
					statusMessage.Visible = true;
					statusMessage.ForeColor = Color.Red;
				}

			}
			else if(ProportionalRbtn.Checked)
			{
				if (Int32.TryParse(TxtProportional.Text, out proportional))
				{
                    // From Khair with love ~
                    PurchasingLogic.SetProportionalBFS(TxtItemCode.Text, proportional);
                    AutomationStatusLbl.Text = "The current buffer stock level is " + PurchasingLogic.GetCurrentBufferStock(TxtItemCode.Text) + ".";
                    statusMessage.Text = "The buffer stock level has been changed to be " + proportional + "% of the item's forecasted value.";
                    statusMessage.Visible = true;
					statusMessage.ForeColor = Color.Green;
				}
				else
				{
					statusMessage.Text = "Please enter a positive integer or 0.";
					statusMessage.Visible = true;
					statusMessage.ForeColor = Color.Red;
				}
			}
			else if(AutomationRbtn.Checked)
			{
                // From Khair with love ~
                AutomationLogic.SetAutomatedlBFS(TxtItemCode.Text);
                AutomationStatusLbl.Text = "The current buffer stock level is " + PurchasingLogic.GetCurrentBufferStock(TxtItemCode.Text) + ".";
                statusMessage.Text = "The buffer stock level has been changed to be 10% of the item's forecasted value.";
                statusMessage.Visible = true;
                statusMessage.ForeColor = Color.Green;
            }
			else
			{
				statusMessage.Text = "Please choose an option.";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Red;
			}
			TxtAbsolute.Text = "";
			TxtProportional.Text = "";
		}
	}
}