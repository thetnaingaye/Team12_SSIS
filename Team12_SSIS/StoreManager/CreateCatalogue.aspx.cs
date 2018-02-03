//Written by Yishu and Pradeep
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


namespace Team12_SSIS.StoreManager
{
    public partial class CreateCatalogue : System.Web.UI.Page
    {
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            statusMessage.Visible = false;
            if (!IsPostBack)
            {

                BindControl();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
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
                int BufferStockLevel = 0;
                int BFSProportion = 10;


                string supplier1 = DdlSupplier1.SelectedValue;
                string supplier2 = DdlSupplier2.SelectedValue;
                string supplier3 = DdlSupplier3.SelectedValue;
                double price1;
                double price2;
                double price3;
                bool isprice1legit = false;
                if (Double.TryParse(TxtPriceS1.Text, out price1) && price1 > 0)
                {
                    isprice1legit = true;
                }
                bool isprice2legit = false;
                if (Double.TryParse(TxtPriceS2.Text, out price2) && price2 > 0)
                {
                    isprice2legit = true;
                }
                bool isprice3legit = false;
                if (Double.TryParse(TxtPriceS3.Text, out price3) && price3 > 0)
                {
                    isprice3legit = true;
                }


                string input = TxtItemID.Text;
                //This part is written by Pradeep
                //Here call a list of all InventoryCatalogue, and check if the itemID exist. InventoryCatalogues.;
                bool Exist = InventoryLogic.GetAllCatalogue().Any(i => i.ItemID == input);
                if (!Exist)
                {

                    if (supplier1 != string.Empty)
                    {

                        if (isprice1legit)
                        {


                            if (supplier2 != string.Empty)
                            {
                                if (supplier1 != supplier2)
                                {
                                    if (isprice2legit)
                                    {

                                        if (supplier3 != string.Empty)
                                        {
                                            if (supplier1 != supplier3 && supplier2 != supplier3)
                                            {
                                                if (isprice3legit)
                                                {
                                                    BusinessLogic.InventoryLogic.AddCatalogue(ItemID, BIN, Shelf, Level, CategoryID, Description,
                                                    ReorderLevel, UnitsInStock, ReorderQty, UOM, Discontinued, UnitsOnOrder, BufferStockLevel, BFSProportion);
                                                    InventoryLogic.AddSupplierCatalogue(supplier1, ItemID, price1, 1, UOM);
                                                    InventoryLogic.AddSupplierCatalogue(supplier2, ItemID, price2, 2, UOM);
                                                    InventoryLogic.AddSupplierCatalogue(supplier3, ItemID, price3, 3, UOM);
                                                    Response.Redirect("ViewCatalogue.aspx");
                                                }
                                                else
                                                {
                                                    statusMessage.Text = "Please enter a valid price for 3rd Supplier";
                                                    statusMessage.Visible = true;
                                                    statusMessage.ForeColor = Color.Red;
                                                }
                                            }
                                            else
                                            {
                                                statusMessage.Text = "Please choose different suppliers";
                                                statusMessage.Visible = true;
                                                statusMessage.ForeColor = Color.Red;
                                            }
                                        }
                                        else
                                        {
                                            BusinessLogic.InventoryLogic.AddCatalogue(ItemID, BIN, Shelf, Level, CategoryID, Description,
                                            ReorderLevel, UnitsInStock, ReorderQty, UOM, Discontinued, UnitsOnOrder, BufferStockLevel, BFSProportion);
                                            InventoryLogic.AddSupplierCatalogue(supplier1, ItemID, price1, 1, UOM);
                                            InventoryLogic.AddSupplierCatalogue(supplier2, ItemID, price2, 2, UOM);
                                            Response.Redirect("ViewCatalogue.aspx");
                                        }
                                    }
                                    else
                                    {
                                        statusMessage.Text = "Please enter a valid price for 2nd Supplier";
                                        statusMessage.Visible = true;
                                        statusMessage.ForeColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    statusMessage.Text = "Please choose different suppliers";
                                    statusMessage.Visible = true;
                                    statusMessage.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                BusinessLogic.InventoryLogic.AddCatalogue(ItemID, BIN, Shelf, Level, CategoryID, Description,
                                ReorderLevel, UnitsInStock, ReorderQty, UOM, Discontinued, UnitsOnOrder, BufferStockLevel, BFSProportion);
                                InventoryLogic.AddSupplierCatalogue(supplier1, ItemID, price1, 1, UOM);
                                Response.Redirect("ViewCatalogue.aspx");
                            }


                        }
                        else
                        {
                            statusMessage.Text = "Please enter a valid price for 1st Supplier";
                            statusMessage.Visible = true;
                            statusMessage.ForeColor = Color.Red;
                        }


                    }
                    else
                    {
                        statusMessage.Text = "Please choose a supplier";
                        statusMessage.Visible = true;
                        statusMessage.ForeColor = Color.Red;
                    }
                }

                else
                {
                    statusMessage.Text = "Item already exists";
                    statusMessage.Visible = true;
                    statusMessage.ForeColor = Color.Red;
                }
            }
            catch
            {
                statusMessage.Text = "Input is required for all fields";
                statusMessage.Visible = true;
                statusMessage.ForeColor = Color.Red;
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
            List<SupplierList> sList = PurchasingLogic.ListSuppliers();
            DdlSupplier1.DataSource = sList;
            DdlSupplier1.DataBind();
            DdlSupplier1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DdlSupplier1.SelectedIndex = 0;
            DdlSupplier2.DataSource = sList;
            DdlSupplier2.DataBind();
            DdlSupplier2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DdlSupplier2.SelectedIndex = 0;
            DdlSupplier3.DataSource = sList;
            DdlSupplier3.DataBind();
            DdlSupplier3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DdlSupplier3.SelectedIndex = 0;

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