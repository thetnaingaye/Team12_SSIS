using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
        List<InventoryCatalogue> sList;
           


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

                DdlCatagory.DataTextField = "CatalogueName";
                DdlCatagory.DataValueField = "CatalogueName";

                DdlCatagory.DataSource = cList;
                DdlCatagory.DataBind();
                controlVisibleFalse();
                
        //-----------------Loads all inventory items when the page loads for the first time------------------------//
                gridBind();
                DdlCatagory.SelectedValue = "All";

            }

        }

        //-------------------------------------Binding all the records from inventory table to datagrid view-----------------------------//
        public void gridBind()
        {
            allList = i.GetAllCatalogue();
            Session["list"] = allList;
            datagridBind(allList);
        }
      
        //-----------------------------------Controlling the visiblility of controls----based on user selection, diffrent view----------//
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
        //--------------------------------datagrid view binding method----------------------------------------------//
        public void datagridBind(List<InventoryCatalogue> bList)
        {
            GridViewInventory.DataSource = bList;
            Session["list"] = bList;
            GridViewInventory.DataBind();

        }
        //-----------------------------------------Allows datagrid view paging---------------------------------------//
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewInventory.PageIndex = e.NewPageIndex;
            iList =(List<InventoryCatalogue>) Session["list"];
            this.datagridBind(iList);
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
                e.Row.Cells[6].Text = " Reorder Level";
                e.Row.Cells[7].Text = "Units In Order";
                e.Row.Cells[8].Text = "Buffer Stock Level";
                e.Row.Cells[9].Text = "Discontinue Status";
            }

        }
        //-------------------------------------Rowcommand event.ItemId is stored in session.Redirect to stockcard page--------//
        protected void GridViewDisbList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "show")
            {
                Session["Itemid"] = e.CommandArgument.ToString();
                Response.Redirect("ViewStockCard.aspx");
            }
        }



        //keyword search...textchange event--------------------------//

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            controlVisibleFalse();
            DdlCatagory.SelectedItem.Text = "All";
            DdlUIS.SelectedItem.Text = "All";

            string keyword = TxtSearch.Text;
            sList = InventoryLogic.SearchInventory(keyword);
            Session["list"] = sList;

            GridViewInventory.DataSource = sList;
            GridViewInventory.DataBind();
            LblMsg.Text = "*Showing result for"+" "+keyword;

        }

        //------------------------------Highlight the  search string in the gridview search result
        protected string HighlightText(string searchWord, string inputText)
        {

            Regex expression = new Regex(searchWord.Replace(" ", "|"), RegexOptions.IgnoreCase);

            return expression.Replace(inputText, new MatchEvaluator(ReplaceKeywords));
        }
        //--------------------------------highlight styling-----------------------------------------//
        public string ReplaceKeywords(Match m)
        {
            return "<span class='highlight' >" + m.Value + "</span>";
        }


        //----------------------------------------search button click event.---------------------------------------------------//
        protected void Btnsearch_Click(object sender, EventArgs e)
        {
            //---------------------------------retrieve all the items under the selected category from the inventory list------Category<=>All------------------//
            TxtSearch.Text = string.Empty;
            if (DdlCatagory.SelectedValue != "All" && DdlUIS.SelectedValue == "0")
            {
                iList = i.getInventoryByCatagory(DdlCatagory.SelectedItem.Text);
                Session["list"] = iList;
                controlVisibleTrue();

                LblReorderQtyD.Text = Convert.ToString(iList[0].ReorderQty);
                LblReorderD.Text = Convert.ToString(iList[0].ReorderLevel);

                LblIdD.Text = iList[0].CategoryID;
                LblCatNameD.Text = i.getCatalogue(DdlCatagory.SelectedItem.Text).CatalogueName;

                datagridBind(iList);

                LblMsg.Text = "*Showing result for category" + " " + DdlCatagory.SelectedItem.Text;

            }
            //---------------------------------filter the inventory list based on  selected category and stock level---Category<=>stockSeleted---------//
            else if (DdlCatagory.SelectedValue != "All" && DdlUIS.SelectedValue != "0" && DdlUIS.SelectedValue != "1")
            {
                string category = DdlCatagory.SelectedItem.Text;

                int uis = Convert.ToInt32(DdlUIS.SelectedValue);
                iList = InventoryLogic.GetInventoryByCategoryNQuantity(category, uis);
                Session["list"] = iList;

                datagridBind(iList);

                LblMsg.Text = "*Showing result for category" + " " + DdlCatagory.SelectedItem.Text + " " +  " ," + "stock qunatity" + " " + DdlUIS.SelectedItem.Text;
            }
            //----------------------based on category and selected stock level-----Category<=>ReorderLevel------------------------//
            else if (DdlCatagory.SelectedValue != "All" && DdlUIS.SelectedValue == "1")
            {
                string category = DdlCatagory.SelectedItem.Text;
                iList = InventoryLogic.GetInventoryByCategorybelowReorder(category);
                Session["list"] = iList;
                datagridBind(iList);

                LblMsg.Text = "*Showing result for category" + " " + DdlCatagory.SelectedItem.Text + " " +  ",stock less than reorder level";
            }
            //-----------------------------all inventory  items below the selected stock level------All<=>ReorderLevel--------------------//
            else if (DdlCatagory.SelectedValue == "All" && DdlUIS.SelectedValue == "1")
            {
                string category = DdlCatagory.SelectedItem.Text;
                iList = InventoryLogic.GetAllInventorybelowReorder();
                Session["list"] = iList;
                datagridBind(iList);

                LblMsg.Text = "*Showing result for inventory items" + " " + ",stock less than" + DdlUIS.SelectedValue;
            }
            //---------------------------get all the inventory items(All<=>All combination)-------------------------------//
            else if (DdlCatagory.SelectedValue == "All" && DdlUIS.SelectedValue == "0")
            {
                gridBind();
                LblMsg.Text = "*Showing result for All inventory items";

            }
            //----------------------Get inventory items below the selected stock level--------All<=>StockSelected----------------------------//
            else if (DdlCatagory.SelectedValue == "All" && DdlUIS.SelectedValue != "0" && DdlUIS.SelectedValue != "1")
            {
                int stock = Convert.ToInt32(DdlUIS.SelectedValue);
                iList = InventoryLogic.GetAllInventorybelowStock(stock);
                Session["list"] = iList;
                datagridBind(iList);

                LblMsg.Text = "*Showing result for All inventory items,stock less than"+" "+DdlUIS.SelectedValue;


            }

        }

        protected void DdlCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSearch.Text = string.Empty;
        }

        protected void DdlUIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSearch.Text = string.Empty;
        }
    }



}
