using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreManager
{
    public partial class ViewCatalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                GridViewCatalogue.DataSource = entities.InventoryCatalogues.ToList<InventoryCatalogue>();
                GridViewCatalogue.DataBind();
            }
        }

        protected void GridViewCatalogue_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ItemID = Convert.ToString(GridViewCatalogue.DataKeys[e.RowIndex].Values[0]);
            BusinessLogic.InventoryLogic.DeleteCatalogue(ItemID);
            BindGrid();
        }

        protected void GridViewCatalogue_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCatalogue.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewCatalogue_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewCatalogue.Rows[e.RowIndex];
            string ItemID = Convert.ToString(GridViewCatalogue.DataKeys[e.RowIndex].Values[0]);
            string Description = Convert.ToString((row.FindControl("TxtDescription") as TextBox).Text);
            int ReorderLevel = Convert.ToInt32((row.FindControl("TxtReorderLevel") as TextBox).Text);
            int ReorderQty = Convert.ToInt32((row.FindControl("TxtReorderQty") as TextBox).Text);
            string UOM = Convert.ToString((row.FindControl("TxtUOM") as TextBox).Text);
            BusinessLogic.InventoryLogic.UpdateCatalogue(ItemID, Description, ReorderLevel, ReorderQty, UOM);
            GridViewCatalogue.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewCatalogue_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCatalogue.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewCatalogue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InventoryCatalogue catalogue = (InventoryCatalogue)e.Row.DataItem;
                string ItemID = catalogue.ItemID;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCatalogue.aspx");
        }

        InventoryLogic inventoryLogic = new InventoryLogic();
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string temp= TxtSearch.Text;
            GridViewCatalogue.DataSource = inventoryLogic.SearchBy(temp);
            GridViewCatalogue.DataBind();
        }

        protected void GridViewCatalogue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCatalogue.PageIndex= e.NewPageIndex;
            BindGrid();
        }

        //protected void BtnPrint_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("CatalogueReport.aspx");
        //}
    }
}