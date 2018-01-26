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
        List<InventoryCatalogue> allList;

        protected void Page_Load(object sender, EventArgs e)
        {
            InventoryLogic i = new InventoryLogic();
            if (!IsPostBack)
            {
                //-------loading the dropdown list with catagoryName--------//
                DdlCatagory.DataSource = i.getCatalogue();
                DdlCatagory.DataTextField = "CatalogueName";
                DdlCatagory.DataValueField = "CatalogueName";
                DdlCatagory.DataBind();
                controlVisibleFalse();
                gridBind();



            }

        }
        public void gridBind()
        {
            allList = i.GetAllCatalogue();
            datagridBind(allList);
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
                TxtId.Text = string.Empty;
                TxtId.Enabled = false;
                DdlCatagory.Enabled = true;


            }
            else if (RbtnFilter.SelectedItem.Value == "3")
            {
                LblMsg.Visible = false; ;
                gridBind();
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

            datagridBind(cList);
        }




        protected void BtnId_Click(object sender, EventArgs e)
        {

            LblMsg.Text = "*Item Code" + " " + "\" " + TxtId.Text + "\"" + " " + "is selected";
            iList = i.getInventoryByItemcode(TxtId.Text);
            datagridBind(iList);

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
            LblId.Visible = true;
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
        public void datagridBind(List<InventoryCatalogue> bList)
        {
            GridViewInventory.DataSource = bList;
            GridViewInventory.DataBind();

        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewInventory.PageIndex = e.NewPageIndex;
            this.gridBind();
        }

        protected void GridViewInventory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Page " + (GridViewInventory.PageIndex + 1) + " of " + GridViewInventory.PageCount;
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Item Code";
                e.Row.Cells[1].Text = "Description";
                e.Row.Cells[2].Text = "BIN";
                e.Row.Cells[3].Text = "Shelf";
                e.Row.Cells[4].Text = "Level";
                e.Row.Cells[5].Text = "Units In Stock";
                e.Row.Cells[6].Text = "Units In Order";
                e.Row.Cells[7].Text = "Buffer Stock Level";
                e.Row.Cells[8].Text = "Discontinue Status";
            }

        }
    }
}