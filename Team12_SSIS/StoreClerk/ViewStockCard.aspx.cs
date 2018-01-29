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
                tList = i.GetStockCardList(itemId);
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
            //Calling method  controlVisibleTrue() to make all the control visible.

            DatgridViewRefresh();
            ControlVisibleTrue();

            //--------------Methods from InventoryLogic class------------------------//

            //--------------------------------------stockCard table records-------------//
            itemId = TxtId.Text;
            try
            {
                tList = i.GetStockCardList(itemId);

                    details(TxtId.Text);
                    GridViewStockCard.DataSource = tList;
                    GridViewStockCard.DataBind();

                    LblMsg.Visible = false;
                
                    detFromInventory = i.getInventoryDetails(itemId);
               
            }
            catch
            {
                ControlVisibleFalse();
                LblMsg.Visible = true;
                LblMsg.Text = "Please enter valid item code";
               
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