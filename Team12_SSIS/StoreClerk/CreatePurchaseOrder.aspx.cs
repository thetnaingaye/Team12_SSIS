//Author Lim Chang Siang and Li Jianing
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class CreatePurchaseOrder : System.Web.UI.Page
    {
        Label statusMessage;
        double total;
        string inventoryItem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            statusMessage.Visible = false;
            if (!IsPostBack)
            {
                BindGrid();
                DisplayLabel();
            }
            Upl.Update();
        }
        protected void BindGrid()
        {
            PORecordDetail poRecordDetails = new PORecordDetail();
            List<PORecordDetail> poRecordDetailsList = new List<PORecordDetail>();
            poRecordDetailsList.Add(poRecordDetails);
            GridViewPO.DataSource = poRecordDetailsList;
            GridViewPO.DataBind();
        }

        void DisplayLabel()
        {
            LblPODate.Text = DateTime.Now.Date.ToString("d");
            LblRequest.Text = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            List<SupplierList> sList = PurchasingLogic.ListSuppliers();
            DdlSli.DataSource = sList;
            DdlSli.DataBind();
            DdlSli.SelectedIndex = 0;
            TxtDlt.Text = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            TxtAds.Text = "21 Lower Kent Ridge Rd, Singapore 119077";
            LblTotal.Text = total.ToString("c");
        }

        protected void GridViewPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<PORecordDetail> emptyPO = new List<PORecordDetail>();
                PORecordDetail p = new PORecordDetail();
                emptyPO.Add(p);
                GridViewPO.DataSource = emptyPO;
                GridViewPO.DataBind();
            }
        }
        protected void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<PORecordDetail> poRecordDetailsList = new List<PORecordDetail>();
                foreach (GridViewRow r in GridViewPO.Rows)
                {
                    PORecordDetail poRecordDetails = new PORecordDetail();
                    poRecordDetails.ItemID = (r.FindControl("Txtitemid") as TextBox).Text;
                    poRecordDetails.UOM = PurchasingLogic.GetUOM(poRecordDetails.ItemID, DdlSli.SelectedValue);
                    poRecordDetails.Quantity = int.Parse((r.FindControl("Txtquantity") as TextBox).Text);
                    poRecordDetails.UnitPrice = PurchasingLogic.GetUnitPrice(poRecordDetails.ItemID, DdlSli.SelectedValue);
                    poRecordDetailsList.Add(poRecordDetails);
                }
                PORecordDetail poRecordDetailsNew = new PORecordDetail();
                poRecordDetailsList.Add(poRecordDetailsNew);
                GridViewPO.DataSource = poRecordDetailsList;
                GridViewPO.DataBind();
            }
            //In the event when a wrong Supplier was selected or Invalid Item ID is entered.
            catch (Exception)
            {
                statusMessage.Text = "Error! Please check that the correct Supplier and ItemID has been selected.";
                statusMessage.ForeColor = System.Drawing.Color.Red;
                statusMessage.Visible = true;
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
            {
                PORecordDetail poR = (PORecordDetail)e.Row.DataItem;

                string itemId = poR.ItemID;
                double poRPrice = (double)(PurchasingLogic.GetUnitPrice(itemId, DdlSli.SelectedValue) * poR.Quantity);

                Label DesLbl = (e.Row.FindControl("LblDes") as Label);
                if (DesLbl != null)
                    DesLbl.Text = InventoryLogic.GetItemName(itemId);
                Label UnpLbl = (e.Row.FindControl("LblUnp") as Label);
                if (UnpLbl != null)
                    UnpLbl.Text = PurchasingLogic.GetUnitPrice(itemId, DdlSli.SelectedValue).ToString("c");
               Label LblUOM = (e.Row.FindControl("LblUOM") as Label);
                if (LblUOM != null)
                    LblUOM.Text = PurchasingLogic.GetUOM(itemId, DdlSli.SelectedValue);
                Label LblPrice = (e.Row.FindControl("LblPrice") as Label);
                if (LblPrice != null)
                    LblPrice.Text = ((double)(poR.Quantity * PurchasingLogic.GetUnitPrice(itemId, DdlSli.SelectedValue))).ToString("c");

                TextBox Txtquantity = e.Row.FindControl("Txtquantity") as TextBox;
                int Quantity = int.Parse(Txtquantity.Text);
                total += (PurchasingLogic.GetUnitPrice(itemId, DdlSli.SelectedValue) * Quantity);
                LblTotal.Text = total.ToString("c");
            }
        }

        protected void Txtitemid_TextChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
                TextBox Txtitemid = currentRow.FindControl("Txtitemid") as TextBox;
                inventoryItem = InventoryLogic.GetItemName(Txtitemid.Text);
                string ItemID = Txtitemid.Text;
                string UOM = PurchasingLogic.GetUOM(ItemID, DdlSli.SelectedValue);
                double unitPrice = PurchasingLogic.GetUnitPrice(ItemID, DdlSli.SelectedValue);
                TextBox TxtQuantity = currentRow.FindControl("TxtQuantity") as TextBox;
                int quantity;

                Label DesLbl = currentRow.FindControl("LblDes") as Label;
                DesLbl.Text = inventoryItem;
                Label UnpLbl = currentRow.FindControl("LblUnp") as Label;
                UnpLbl.Text = PurchasingLogic.GetUnitPrice(ItemID, DdlSli.SelectedValue).ToString("C");
                Label LblUOM = currentRow.FindControl("LblUOM") as Label;
                LblUOM.Text = PurchasingLogic.GetUOM(ItemID, DdlSli.SelectedValue);

                if (int.TryParse(TxtQuantity.Text, out quantity))
                {
                    Label LblPrice = currentRow.FindControl("LblPrice") as Label;
                    LblPrice.Text = (quantity * unitPrice).ToString("c");
                    total += (quantity * unitPrice);
                }
            }
            catch
            {
                statusMessage.Text = "Some items entered are not provided by this supplier.";
                statusMessage.Visible = true;
            }
           
        }
        protected void Txtquantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            TextBox Txtquantity = currentRow.FindControl("Txtquantity") as TextBox;
            int Quantity = int.Parse(Txtquantity.Text);

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label LblSn = GridViewPO.Rows[e.RowIndex].Cells[0].FindControl("LblSn") as Label;
            int sN = int.Parse(LblSn.Text);

            List<PORecordDetail> poRecordDetailList = new List<PORecordDetail>();
            foreach (GridViewRow r in GridViewPO.Rows)
            {
                PORecordDetail poRecordDetails = new PORecordDetail();
                poRecordDetails.ItemID = (r.FindControl("Txtitemid") as TextBox).Text;
                poRecordDetails.Quantity = Convert.ToInt32((r.FindControl("Txtquantity") as TextBox).Text.ToString());
                poRecordDetails.UOM = PurchasingLogic.GetUOM(poRecordDetails.ItemID, DdlSli.SelectedValue);
                poRecordDetails.UnitPrice = (double)(PurchasingLogic.GetUnitPrice(poRecordDetails.ItemID, DdlSli.SelectedValue));
                poRecordDetailList.Add(poRecordDetails);
            }
            poRecordDetailList.RemoveAt(sN - 1);
            GridViewPO.DataSource = poRecordDetailList;
            GridViewPO.DataBind();
        }

        protected string GetTotal()
        {
            return total.ToString("C0");
        }


        protected void BtnSfa_Click(object sender, EventArgs e)
        {
           
            
                try
                {
                    PurchasingLogic pl = new PurchasingLogic();
                    string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
                    string Deliverto = TxtDlt.Text;
                    string SupplierID = DdlSli.Text;
                    string Address = TxtAds.Text;
                    //Get Date from Http Input Textbox
                    DateTime ExpectedBy = DateTime.ParseExact(Request.Form["datepicker"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //Remember to rename AddText method.
                    int poNumber = BusinessLogic.PurchasingLogic.AddText(Deliverto, Address, SupplierID, DateTime.Now.Date, clerkName, ExpectedBy);

                    foreach (GridViewRow r in GridViewPO.Rows)
                    {
                        string itemID = (r.FindControl("Txtitemid") as TextBox).Text;
                        int quantity = int.Parse((r.FindControl("Txtquantity") as TextBox).Text);
                        string uom = PurchasingLogic.GetUOM(itemID, DdlSli.SelectedValue);
                        double unitPrice = (double)PurchasingLogic.GetUnitPrice(itemID, DdlSli.SelectedValue);
                        pl.CreatePurchaseOrderDetails(poNumber, itemID, quantity, uom, unitPrice);
                    }

                    string statusMsg = poNumber.ToString("0000") + " Created Successfully.";
                    Session["PONumber"] = poNumber;
                    Session["POstatusMsg"] = statusMsg;
                    Response.Redirect("~/StoreClerk/ViewPurchaseOrder.aspx");
                }
                catch
                {
                    statusMessage.Text = "Some items entered are not provided by this supplier.";
                    statusMessage.Visible = true;
                }
                // pl.Submitforapproval(poNo, clerkName);

                //Session["PONumber"] = poNo;
                // Server.Transfer("ViewPurchaseOrder.aspx", true);
                // statusMessage.ForeColor = System.Drawing.Color.Green;
                // statusMessage.Text = "PO" + poNo.ToString() + "submitted successfully";
            }
        }

        
        //Trying to clear all textbox in grid view
        //    foreach (GridViewRow row in GridViewPO.Rows)
        //    {
        //        foreach(TableCell cell in row.Cells)
        //        {
        //            foreach (var control in cell.Controls)
        //            {
        //                var box = control as TextBox;
        //                if(box!=null)
        //                {
        //                    box.Text = string.Empty;
        //                }
        //            }

        //        }
        //    }
        
    }



