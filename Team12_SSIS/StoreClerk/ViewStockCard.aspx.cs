using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;
using System.Collections;
using System.Data;
using System.Globalization;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewStockCard : System.Web.UI.Page
    {
        InventoryCatalogue detFromInventory=new InventoryCatalogue();
        List<SupplierCatalogue> sCatList=null;
        List<StockCard> tList=null;
        List<string> idList;
        InventoryLogic i = new InventoryLogic();
        string itemId;
        DateTime date1;
        DateTime date2;


        protected void Page_Load(object sender, EventArgs e)
        {
            ControlVisibleFalse();
            LblMsg.Visible = false;

            //---------------------------retrieving the itemId from the session(from inventory page)----------------------------------//

            if (Session["Itemid"] != null)
            {
                ControlVisibleTrue();

                itemId = (string)Session["Itemid"];

                //---------------------populating the transaction details of the item seleted-------------------//

                details(itemId);
                tList = InventoryLogic.GetStockCardList(itemId);
                if (tList.Count != 0)
                {

                    GridViewStockCard.DataSource = tList;
                GridViewStockCard.DataBind();
                LblMsg.Visible = false;
                }
                else
                {
                    LblMsg.Visible = true;
             
                    LblMsg.Text = "No Transaction Records Found for" + " " + detFromInventory.Description;
                }


            }

        }


        protected void BtnFind_Click(object sender, EventArgs e)
        {
            try {
                DatgridViewRefresh();
                ControlVisibleTrue();
                try
                {
                    date1 = DateTime.ParseExact(Request.Form["datepicker"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    date2 = DateTime.ParseExact(Request.Form["datepicker2"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                catch
                { }



                string d1 = Convert.ToString(date1);
                string d2 = Convert.ToString(date2);

                //if user wont select a date default value is "1/1/0001 12:00:00 AM".setting that to null here-------------------------//
                if (d1 == "1/1/0001 12:00:00 AM" || d2 == "1/1/0001 12:00:00 AM")
                {
                    d1 = null;
                    d2 = null;

                }

                //-----------------------------Search based on item code &transaction dates
                //-----------------.Datagrid view load with transaction records of selected item within the selected dates

                if (TxtId.Text != string.Empty && d1 != null && d2 != null)
                {
                    tList = InventoryLogic.GetTransactionByDate(date1, date2, TxtId.Text);
                    details(TxtId.Text);
                    GridViewStockCard.DataSource = tList;
                    GridViewStockCard.DataBind();

                    LblMsg.Visible = false;

                }

                //-------------------------------Transaction records of selected item----here user not selected any dates---------------//
                else if (TxtId.Text != string.Empty && d1 == null && d2 == null)
                {
                    string id = TxtId.Text;
                    tList = InventoryLogic.GetStockCardList(TxtId.Text);
                    details(TxtId.Text);
                    GridViewStockCard.DataSource = tList;
                    GridViewStockCard.DataBind();
                    LblMsg.Visible = false;

                }
                //---------------------------------Transaction records within the selected date range-------------------------//
                else if (TxtId.Text == string.Empty && d1 != null && d2 != null)
                {
                    tList = InventoryLogic.GetAllTransactionByDate(date1, date2);
                    GridViewStockCard.DataSource = tList;
                    GridViewStockCard.DataBind();
                    LblMsg.Visible = false;
                    ControlVisibleFalse();
                }
                //--------------------user don't give any input.just click search button.then this condition will fire------------//
                else if (TxtId.Text == string.Empty && d1 == null && d2 == null)
                {
                    ControlVisibleFalse();
                    LblMsg.Visible = true;
                    LblMsg.Text = "Please give a valid data to search";
                }

            }
            catch
            {
                ControlVisibleFalse();
                LblMsg.Visible = true;
                LblMsg.Text = "Item code doesn't exist";
            }
            }

        
        
        //----------------------------To get the item details---------------------------------//
        public void details(string itemid)
        {
            //---------------------------from InventoryCatalogue table(BIN,Description,UOM)------//
            detFromInventory = i.getInventoryDetails(itemid);
            LblDesD.Text = detFromInventory.Description;
            LblUomD.Text = detFromInventory.UOM;
            LblBinD.Text = detFromInventory.BIN;
            LblIdD.Text = detFromInventory.ItemID;
            //---------------------------from SupplierCatalogue table(Supplier details)------//
            sCatList = i.getSCatalogueDetails(itemid);
            LblS1D.Text = sCatList[0].SupplierID;
            LblS2D.Text = sCatList[1].SupplierID;
            LblS3D.Text = sCatList[2].SupplierID;
        }

        protected void GridViewStockCard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
               // e.Row.Cells[0].Visible = false;
            
        }
        //-----------------------setting the visiblity of control false-------------------------------------//
        public void ControlVisibleFalse()
        {
            LblId.Visible = false;
            LblIdD.Visible = false;
            LbldDes.Visible = false;
            LblDesD.Visible = false;
            LblBin.Visible = false;
            LblBinD.Visible = false;
            LblS1.Visible = false;
            LblS1D.Visible = false;
            LblS2.Visible = false;
            LblS2D.Visible = false;
            LblS3.Visible = false;
            LblS3D.Visible = false;
            LblUom.Visible = false;
            LblUomD.Visible = false;

        }
        //----------------------------------------setting the visibilty of control true------------------------------//
        public void ControlVisibleTrue()
        {

            LblId.Visible =true;
            LblIdD.Visible = true;
            LbldDes.Visible = true;
            LblDesD.Visible = true;
            LblBin.Visible = true;
            LblBinD.Visible = true;
            LblS1.Visible = true;
            LblS1D.Visible = true;
            LblS2.Visible = true;
            LblS2D.Visible = true;
            LblS3.Visible = true;
            LblS3D.Visible = true;
            LblUom.Visible = true;
            LblUomD.Visible = true;

        }
        //-------------------------------------redirect to inventory page while click event------------------------------//

        protected void BtnInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewInventoryList.aspx");
        }
        public  void DatgridViewRefresh()
        {
            DataTable ds = new DataTable();
            ds = null;
            GridViewStockCard.DataSource = ds;
            GridViewStockCard.DataBind();
        }
       
    }
}