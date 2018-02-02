using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

//Yishu's code
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
            List<InventoryCatalogue> cList = InventoryLogic.GetAllCatalogue();
            GridViewCatalogue.DataSource = cList;
            GridViewCatalogue.DataBind();
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
            string CategoryID = Convert.ToString((row.FindControl("DdlCategoryID") as DropDownList).Text);
            string BIN= Convert.ToString((row.FindControl("TxtBIN") as TextBox).Text);
            string Shelf= Convert.ToString((row.FindControl("TxtShelf") as TextBox).Text);
            int Level=Convert.ToInt32((row.FindControl("TxtLevel") as TextBox).Text);
            int ReorderLevel = Convert.ToInt32((row.FindControl("TxtReorderLevel") as TextBox).Text);
            int UnitsInStock = Convert.ToInt32((row.FindControl("TxtUnitsInStock") as TextBox).Text);
            int ReorderQty = Convert.ToInt32((row.FindControl("TxtReorderQty") as TextBox).Text);
            string UOM = Convert.ToString((row.FindControl("TxtUOM") as TextBox).Text);
            string Discontinued=Convert.ToString((row.FindControl("DdlDiscontinued") as DropDownList).Text);
            int UnitsOnOrder = Convert.ToInt32((row.FindControl("TxtUnitsOnOrder") as TextBox).Text);
            int BufferStockLevel = Convert.ToInt32((row.FindControl("TxtBufferStockLevel") as TextBox).Text);
            int BFSProportion = Convert.ToInt32((row.FindControl("TxtBFSProportion") as TextBox).Text);
            InventoryLogic.UpdateCatalogue(ItemID, Description, CategoryID, BIN, Shelf, Level,
                ReorderLevel, UnitsInStock, ReorderQty, UOM, Discontinued,
              UnitsOnOrder, BufferStockLevel, BFSProportion);
            GridViewCatalogue.EditIndex = -1;
            BindGrid();
        }
        

        protected void GridViewCatalogue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InventoryCatalogue catalogue = (InventoryCatalogue)e.Row.DataItem;
                string ItemID = catalogue.ItemID;

                Label lblCatName = e.Row.FindControl("LblCatalogueName") as Label;
                if (lblCatName != null)
                    lblCatName.Text = InventoryLogic.GetCatalogueName(catalogue.CategoryID);

                DropDownList ddl = e.Row.FindControl("DdlCategoryID") as DropDownList;
                if (ddl != null)
                {
                    ddl.DataSource = InventoryLogic.CategoryID();
                    ddl.DataTextField = "CategoryID";
                    ddl.DataValueField = "CategoryID";
                    ddl.DataBind();
                }
            }
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

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCatalogue.aspx");
        }

        protected void GridViewCatalogue_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCatalogue.EditIndex = -1;
            BindGrid();
        }

        protected void DdlCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            ddl = row.FindControl("DdlCategoryID") as DropDownList;
            Label LblCatalogueNameAuto = row.FindControl("LblCatalogueNameAuto") as Label;
            string CategoryID = Convert.ToString(ddl.SelectedItem);
            if (LblCatalogueNameAuto != null)
                LblCatalogueNameAuto.Text = InventoryLogic.GetCatalogueName(CategoryID);
        }
    }
}