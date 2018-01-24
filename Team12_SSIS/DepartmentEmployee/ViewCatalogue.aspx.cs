using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class ViewCatalogue : System.Web.UI.Page
    {
        SA45Team12AD entities = new SA45Team12AD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                if (Session["CartList"] != null)
                {
                    List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];
                    LblCount.Text = "Number of items requested : " + (temp.Count() + 0).ToString();
                }
                else
                {
                    List<InventoryCatalogue> temp = new List<InventoryCatalogue>();
                    Session["CartList"] = temp;
                    LblCount.Text = "Number of items requested : " + (temp.Count() + 0).ToString();
                }


            }
            else
            {
                List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];
                BindGrid();
                LblCount.Text = "Number of items requested : " + (temp.Count() + 1).ToString();
            }
        }
        protected void BindGrid()
        {
            GridViewAddRequest.DataSource = entities.InventoryCatalogues.Select(i => new { i.ItemID, i.Description }
            ).ToList();
            GridViewAddRequest.DataBind();
        }

        RequisitionLogic requisitionLogic = new RequisitionLogic();
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string temp = TxtSearch.Text;
            GridViewAddRequest.DataSource = requisitionLogic.SearchBy(temp);
            GridViewAddRequest.DataBind();
        }

        protected void LinkButtonCount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOutRequest.aspx");
        }

        protected void BtnAddRequest_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string click = GridViewAddRequest.DataKeys[row.RowIndex].Values[0].ToString();
            string ItemID = click;
            InventoryCatalogue ic = entities.InventoryCatalogues.Where(x => x.ItemID == ItemID).First();
            List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];
            temp.Add(ic);
            Session["CartList"] = temp;
        }
    }
}