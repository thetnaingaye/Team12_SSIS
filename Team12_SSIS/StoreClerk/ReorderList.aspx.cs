using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

//----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

namespace Team12_SSIS.StoreClerk
{
    public partial class ReorderList : System.Web.UI.Page
    {
        List<ReorderRecord> tempList = new List<ReorderRecord>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }

        // Retrieving selected col values from the diff tables - To populate into the respective GridViews
        protected string GetSuppilerName(string suppID)
        {
            string temp = PurchasingLogic.GetSuppilerName(suppID);
            return temp.ToString();
        }

        protected string GetItemDescription(string itemID)
        {
            string temp = InventoryLogic.GetItemDescription(itemID);
            return temp.ToString();
        }

        protected string GetQuantity(string itemID)
        {
            int temp = InventoryLogic.GetQuantity(itemID);
            return temp.ToString();
        }

        protected string GetUnitsOfMeasure(string itemID)
        {
            string temp = InventoryLogic.GetUnitsOfMeasure(itemID);
            return temp.ToString();
        }

        // Populating the details (2nd GridView) below
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tempText = btn.CommandArgument.ToString();
            string[] tempArray = tempText.Split(',');

            PurchasingLogic.RemoveReorderRecord(tempArray[0], tempArray[1]);
            PopulateGridView();
        }

        // Submit ALL reorder records for approval
        protected void BtnSubmitAll_Click(object sender, EventArgs e)
        {
            var temp = PurchasingLogic.PopulateReorderTable();

            if (temp != null && temp.Count > 0)
            {
                string s = PurchasingLogic.CreateMultiplePO(temp);

                if (s.Contains("successfully"))
                {
                    BtnSubmitAll.Visible = false;
                    LblMessage.Text = "All are successfully submitted to supervisor for approval.";
                }

                // Sending a pop up message
                ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + s + "');", true);
            }
            else
            {
                LblMessage.Text = "Submission unsuccessful.";
            }
        }

        protected void PopulateGridView()
        {
            tempList = PurchasingLogic.PopulateReorderTable();

            if (tempList == null)
            {
                BtnSubmitAll.Visible = false;
            }

            // Populating the gridview
            GridViewReorderList.DataSource = tempList;
            GridViewReorderList.DataBind();
        }
    }
}