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
    public partial class ChangeBufferStockLevel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if(!IsPostBack)
			{
				MultiView1.ActiveViewIndex = 0;
			}
        }

		protected void FindBtn_Click(object sender, EventArgs e)
		{
			string itemcode = TxtItemCode.Text;
			LblItemCode.Text = itemcode;
			InventoryCatalogue i = InventoryLogic.GetInventoryItem(itemcode);
			LblItemDescription.Text = i.Description;
			MultiView1.ActiveViewIndex = 1;
		}

		protected void BtnBack_Click(object sender, EventArgs e)
		{
			MultiView1.ActiveViewIndex = 0;
		}
	}
}