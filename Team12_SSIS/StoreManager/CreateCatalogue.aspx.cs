using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

using static Team12_SSIS.Utility.Validator;


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
                int ReorderQty = Convert.ToInt32(TxtReorderQty.Text);
                string UOM = TxtUOM.Text;
                string Discontinued = "N";
                BusinessLogic.InventoryLogic.AddCatalogue(ItemID, BIN, Shelf, Level, CategoryID, Description, ReorderLevel, ReorderQty, UOM, Discontinued);
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
    }
}