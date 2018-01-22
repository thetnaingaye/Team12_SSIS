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
    public partial class ViewInventoryList : System.Web.UI.Page
    {
        InventoryLogic i = new InventoryLogic();
        List<InventoryCatalogue> iList;
        List<InventoryCatalogue> cList;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InventoryLogic i = new InventoryLogic();
            if (!IsPostBack)
            {
                DdlCatagory.DataSource = i.getCatalogue();
                DdlCatagory.DataTextField = "CatalogueName";
                DdlCatagory.DataValueField = "CatalogueName";
                DdlCatagory.DataBind();
                controlVisibleFalse();

            }
          
        }
        protected void Rbtn_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RbtnFilter.SelectedItem.Value == "1")
            {

                DdlCatagory.Enabled = false;
                TxtId.Enabled = true;


            }
            else if (RbtnFilter.SelectedItem.Value == "2")
            {
                TxtId.Enabled = false;
                DdlCatagory.Enabled = true;

            }
            else
            {
                LblMsg.Text = "Please Select";
            }
        }


        protected void BtnCatagory_Click(object sender, EventArgs e)
        {
            
                controlVisibleTrue();
                LblMsg.Text = "*Catagory" + " " + "\"" + DdlCatagory.SelectedItem.Text + "\" " + "is selected";
                cList = i.getInventoryByCatagory(DdlCatagory.SelectedItem.Text);

                LblReorderQtyD.Text = Convert.ToString(cList[0].ReorderQty);
                LblReorderD.Text = Convert.ToString(cList[0].ReorderLevel);
                LblUOMD.Text = cList[0].UOM;
                LblIdD.Text = cList[0].CategoryID;
                LblCatNameD.Text = i.getCatalogue(DdlCatagory.SelectedItem.Text).CatalogueName;

                GridViewInventory.DataSource = cList;
                GridViewInventory.DataBind();
            }
          

        

        protected void BtnId_Click(object sender, EventArgs e)
        {
            
            LblMsg.Text = "*Item Code" + " " + "\" " + TxtId.Text + "\"" + " " + "is selected";
            iList = i.getInventoryByItemcode(TxtId.Text);
            GridViewInventory.DataSource = iList;
            GridViewInventory.DataBind();

        }

        public void controlVisibleFalse()
        {
            LblId.Visible = false;
            LblIdD.Visible = false;
            LblReorderD.Visible = false;
            LblReorder.Visible = false;
            LblReorderQtyD.Visible = false;
            LblReorderQty.Visible = false;
            LblUOMD.Visible = false;
            LblUOM.Visible = false;
            LblCatName.Visible = false;
            LblCatNameD.Visible = false;

        }
        public void controlVisibleTrue()
        {
            LblId.Visible =true;
            LblIdD.Visible = true;
            LblReorderD.Visible = true;
            LblReorder.Visible = true;
            LblReorderQtyD.Visible = true;
            LblReorderQty.Visible = true;
            LblUOMD.Visible = true;
            LblUOM.Visible = true;
            LblCatName.Visible = true; ;
            LblCatNameD.Visible = true;


        }
        protected void GridViewInventory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;

        }
    }
}