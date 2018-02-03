//-- Author: Pradeep Elango and Yuan Yishu
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
    public partial class EditCatalogue : System.Web.UI.Page
    {
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {

            statusMessage = this.Master.FindControl("LblStatus") as Label;
            statusMessage.Visible = false;
            if (!IsPostBack)
            {
                string itemID = Request.QueryString["itemID"];
                if (!Utility.Validator.IsProductIdFormat(itemID))
                    Response.Redirect("ViewCatalogue.aspx");
                BindControl(itemID);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string ItemID = TxtItemID.Text;
            string uom = InventoryLogic.GetUnitsOfMeasure(ItemID);
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

                                            InventoryLogic.UpdateSupplierCatalogue(supplier1, ItemID, price1, 1);
                                            if (InventoryLogic.DoesSupplierExistInSupplierCatalogueForItemID(2, ItemID))
                                            {
                                                InventoryLogic.UpdateSupplierCatalogue(supplier2, ItemID, price2, 2);
                                            }
                                            else
                                            {
                                                InventoryLogic.AddSupplierCatalogue(supplier2, ItemID, price2, 2, uom);
                                            }
                                            if (InventoryLogic.DoesSupplierExistInSupplierCatalogueForItemID(3, ItemID))
                                            {
                                                InventoryLogic.UpdateSupplierCatalogue(supplier3, ItemID, price3, 3);
                                            }
                                            else
                                            {
                                                InventoryLogic.AddSupplierCatalogue(supplier3, ItemID, price3, 3, uom);
                                            }
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
                                    InventoryLogic.UpdateSupplierCatalogue(supplier1, ItemID, price1, 1);
                                    if (InventoryLogic.DoesSupplierExistInSupplierCatalogueForItemID(2, ItemID))
                                    {
                                        InventoryLogic.UpdateSupplierCatalogue(supplier2, ItemID, price2, 2);
                                    }
                                    else
                                    {
                                        InventoryLogic.AddSupplierCatalogue(supplier2, ItemID, price2, 2, uom);
                                    }
                                    if (InventoryLogic.DoesSupplierExistInSupplierCatalogueForItemID(3, ItemID))
                                    {
                                        InventoryLogic.DeleteSupplierCatalogue(3, ItemID);
                                    }
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

                        InventoryLogic.UpdateSupplierCatalogue(supplier1, ItemID, price1, 1);
                        if (InventoryLogic.DoesSupplierExistInSupplierCatalogueForItemID(2, ItemID))
                        {
                            InventoryLogic.DeleteSupplierCatalogue(2, ItemID);
                        }
                        if (InventoryLogic.DoesSupplierExistInSupplierCatalogueForItemID(3, ItemID))
                        {
                            InventoryLogic.DeleteSupplierCatalogue(3, ItemID);
                        }
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

        protected void BindControl(string itemID)
        {
            List<SupplierList> sList = PurchasingLogic.ListSuppliers();
            DdlSupplier1.DataSource = sList;
            DdlSupplier1.DataBind();
            DdlSupplier1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DdlSupplier1.SelectedValue = InventoryLogic.GetFirstPrioritySupplierByItemID(itemID);
            DdlSupplier2.DataSource = sList;
            DdlSupplier2.DataBind();
            DdlSupplier2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            if (InventoryLogic.GetSecondPrioritySupplierByItemID(itemID) != null)
            {
                DdlSupplier2.SelectedValue = InventoryLogic.GetSecondPrioritySupplierByItemID(itemID);
            }
            else
            {
                DdlSupplier2.SelectedIndex = 0;
            }
            DdlSupplier3.DataSource = sList;
            DdlSupplier3.DataBind();
            DdlSupplier3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            if (InventoryLogic.GetThirdPrioritySupplierByItemID(itemID) != null)
            {
                DdlSupplier3.SelectedValue = InventoryLogic.GetThirdPrioritySupplierByItemID(itemID);
            }
            else
            {
                DdlSupplier3.SelectedIndex = 0;
            }
            TxtPriceS1.Text = InventoryLogic.GetFirstPrioritySupplierPriceByItemID(itemID);
            TxtPriceS2.Text = InventoryLogic.GetSecondPrioritySupplierPriceByItemID(itemID);
            TxtPriceS3.Text = InventoryLogic.GetThirdPrioritySupplierPriceByItemID(itemID);
            TxtItemID.Text = itemID;
            TxtItemID.ReadOnly = true;
            TxtDescription.Text = InventoryLogic.GetItemDescription(itemID);
            TxtDescription.ReadOnly = true;
            TxtCategory.Text = InventoryLogic.GetCatalogueName(InventoryLogic.GetInventoryItem(itemID).CategoryID);
            TxtCategory.ReadOnly = true;

        }
    }

}
