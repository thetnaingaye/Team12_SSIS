using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using  Team12_SSIS.Model;
using System.Collections;



namespace Team12_SSIS.StoreClerk
{
    public partial class ViewStockCard : System.Web.UI.Page
    {
        InventoryCatalogue detFromInventory;
        List<SupplierCatalogue> sCatList;
        InventoryLogic i = new InventoryLogic();
        string itemId;

        protected void Page_Load(object sender, EventArgs e)
        {
            controlVisibleFalse();
            if (Session["Itemid"]!=null)
            {
                controlVisibleTrue();

                itemId = (string) Session["Itemid"];
                details(itemId);

                
                GridViewStockCard.DataSource = i.GetStockCardList(itemId);
                GridViewStockCard.DataBind();
                

            }
         
        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            //Calling method  controlVisibleTrue() to make all the control visible.
            controlVisibleTrue();


            //--------------Methods from InventoryLogic class------------------------//
           
            //--------------------------------------stockCard table records-------------//
            GridViewStockCard.DataSource = i.GetStockCardList(TxtId.Text);
            GridViewStockCard.DataBind();

            details(TxtId.Text);

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
        public void controlVisibleFalse()
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
        public void controlVisibleTrue()
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewInventoryList.aspx");
        }
    }
}