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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            controlVisibleFalse();
        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            //Calling method  controlVisibleTrue() to make all the control visible.
            controlVisibleTrue();


            //--------------Methods from InventoryLogic class------------------------//
            InventoryLogic i = new InventoryLogic();
            //--------------------------------------stockCard table records-------------//
            GridViewStockCard.DataSource = i.getStockCardList(TxtId.Text);
            GridViewStockCard.DataBind();

            //---------------------------from InventoryCatalogue table(BIN,Description,UOM)------//
             detFromInventory = i.getInventoryDetails(TxtId.Text);
            LblDesD.Text = detFromInventory.Description;
            LblUomD.Text = detFromInventory.UOM;
            LblBinD.Text = detFromInventory.BIN;
            LblIdD.Text = detFromInventory.ItemID;
            //---------------------------from SupplierCatalogue table(Supplier details)------//
            sCatList = i.getSCatalogueDetails(TxtId.Text);
            LblS1D.Text = sCatList[0].SupplierID;
            LblS2D.Text = sCatList[1].SupplierID;
            LblS3D.Text = sCatList[2].SupplierID;

        }
        protected void GridViewStockCard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
                e.Row.Cells[0].Visible = false;
            
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
            LblsS3.Visible = false;
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
            LblsS3.Visible = true;
            LblS3D.Visible = true;
            LblUom.Visible = true;
            LblUomD.Visible = true;

        }
        



    }
}