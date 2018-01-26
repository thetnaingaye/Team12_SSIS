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
        List<CatalogueCategory> cList;
        List<InventoryCatalogue> allList;


        protected void Page_Load(object sender, EventArgs e)
        {
            InventoryLogic i = new InventoryLogic();
            if (!IsPostBack)
            {
                //-------loading the dropdown list with catagoryName--------//

                cList = i.getCatalogue();
                CatalogueCategory cat = new CatalogueCategory();
                cat.CatalogueName = "All";
                cat.CategoryID = "All";
                cList.Add(cat);
                DdlCatagory.DataSource = cList;

                DdlCatagory.DataTextField = "CatalogueName";
                DdlCatagory.DataValueField = "CatalogueName";
                DdlCatagory.DataBind();
                controlVisibleFalse();
                gridBind();
                DdlCatagory.SelectedValue = "All";

            }

        }

        //-------------------------------------Binding all the records from inventory table to datagrid view-----------------------------//
        public void gridBind()
        {
            allList = i.GetAllCatalogue();
            datagridBind(allList);
        }
      
        //-----------------------------------Controlling the visiblility og controls----based on user selection diffrent view----------//
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
        //--------------------------------datagrid view binding method-----------------------------//
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

        //------------------------------dataGridview footer and header text control on row bind event----------------//
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
        //-------------------------------------Rowcommand event.ItemId is stored in session.redirect to stockcard page--------//
        protected void GridViewDisbList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "show")
            {
                Session["Itemid"] = e.CommandArgument.ToString();
                Response.Redirect("ViewStockCard.aspx");
            }
        }

        //----------------------------------------search button click event.---------------------------------------------------//
        protected void Btnsearch_Click(object sender, EventArgs e)
        {
            if (ChbId.Checked == true && ChbCatagory.Checked == true && DdlCatagory.SelectedValue != "All")
            {
                string status = DdlCatagory.SelectedValue;
                iList = InventoryLogic.GetInventoryByIdandCategory(TxtId.Text, status);

                GridViewInventory.DataSource = iList;
                GridViewInventory.DataBind();
            }
            else if (ChbId.Checked == true && ChbCatagory.Checked == false)
            {
                LblMsg.Text = "*Item Code" + " " + "\" " + TxtId.Text + "\"" + " " + "is selected";
                iList = i.getInventoryByItemcode(TxtId.Text);
                datagridBind(iList);
            }
            else if (ChbId.Checked == false && ChbCatagory.Checked == true && DdlCatagory.SelectedValue != "All")
            {
                LblMsg.Text = "*Catagory" + " " + "\"" + DdlCatagory.SelectedItem.Text + "\" " + "is selected";
                iList = i.getInventoryByCatagory(DdlCatagory.SelectedItem.Text);

                LblReorderQtyD.Text = Convert.ToString(iList[0].ReorderQty);
                LblReorderD.Text = Convert.ToString(iList[0].ReorderLevel);
                LblUOMD.Text = iList[0].UOM;
                LblIdD.Text = iList[0].CategoryID;
                LblCatNameD.Text = i.getCatalogue(DdlCatagory.SelectedItem.Text).CatalogueName;

                datagridBind(iList);
            }
            else if (ChbId.Checked == false && ChbCatagory.Checked == true && DdlCatagory.SelectedValue == "All")
            {
                gridBind();
            }
        }

        
    }
}