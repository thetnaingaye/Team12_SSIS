using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

using static Team12_SSIS.Utility.Validator;

//Yishu's code
namespace Team12_SSIS.StoreManager
{
    public partial class CreateCatalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControl();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string ItemID = TxtItemID.Text;
                string BIN = TxtBIN.Text;
                string Shelf = TxtShelf.Text;
                int Level = Convert.ToInt32(TxtLevel.Text);
                string CategoryID = Convert.ToString(DdlCategoryID.SelectedValue);
                string Description = TxtDescription.Text;
                int ReorderLevel = Convert.ToInt32(TxtReorderLevel.Text);
                int UnitsInStock = Convert.ToInt32(TxtUnitsInStock.Text);
                int ReorderQty = Convert.ToInt32(TxtReorderQty.Text);
                string UOM = TxtUOM.Text;
                string Discontinued = "N";
                int UnitsOnOrder = Convert.ToInt32(TxtUnitsOnOrder.Text);
                int BufferStockLevel = Convert.ToInt32(TxtBufferStockLevel.Text);
                int BFSProportion = Convert.ToInt32(TxtBFSProportion.Text);
                BusinessLogic.InventoryLogic.AddCatalogue(ItemID, BIN, Shelf, Level, CategoryID, Description,
                    ReorderLevel, UnitsInStock, ReorderQty, UOM, Discontinued, UnitsOnOrder, BufferStockLevel, BFSProportion);
                Response.Redirect("ViewCatalogue.aspx");
            }
        }

        protected void BindControl()
        {
            DropDownList ddl = DdlCategoryID;
            if (ddl != null)
            {
                ddl.DataSource = BusinessLogic.InventoryLogic.CategoryID();
                ddl.DataTextField = "CatalogueName";
                ddl.DataValueField = "CategoryID";
                ddl.DataBind();
            }
        }
        protected void TxtItemID_TextChanged(object sender, EventArgs e)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string input = TxtItemID.Text;
                bool Exist = entities.InventoryCatalogues.Any(i => i.ItemID == input);
                if (Exist)
                {
                    LblExist.Visible = true;
                    LblExist.Text = "Item ID Already Exist!";
                    LblExist.ForeColor = Color.Red;
                    TxtItemID.Text = string.Empty;
                }
                else
                {
                    LblExist.Visible = false;
                }
            }
        }
    }
}