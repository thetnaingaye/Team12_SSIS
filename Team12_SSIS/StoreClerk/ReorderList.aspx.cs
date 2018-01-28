﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class ReorderList : System.Web.UI.Page
    {
        PurchasingLogic p = new PurchasingLogic();
        InventoryLogic i = new InventoryLogic();
        List<ReorderRecord> tempList = new List<ReorderRecord>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        // Retrieving selected col values from the diff tables - To populate into the respective GridViews
        public string GetSuppilerName(string suppID)
        {
            string temp = p.GetSuppilerName(suppID);
            return temp.ToString();
        }

        public string GetItemDescription(string itemID)
        {
            string temp = i.GetItemDescription(itemID);
            return temp.ToString();
        }

        public string GetQuantity(string itemID)
        {
            int temp = InventoryLogic.GetQuantity(itemID);
            return temp.ToString();
        }

        public string GetUnitsOfMeasure(string itemID)
        {
            string temp = i.GetUnitsOfMeasure(itemID);
            return temp.ToString();
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
    }
}