﻿using System;
using System.Collections.Generic;
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
       

        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (!IsPostBack)
            {
                BindGrid();
            }
            Upl.Update();
            populate();
            //totalLbl.Text = total.ToString("C0");
            //Response.Redirect("ViewPurchaseOrder?Name=Pandian");
        }
        protected void BindGrid()
        {
            PORecordDetail poRecordDetails = new PORecordDetail();
            List<PORecordDetail> poRecordDetailsList = new List<PORecordDetail>();
            poRecordDetailsList.Add(poRecordDetails);
            GridViewPO.DataSource = poRecordDetailsList;
            GridViewPO.DataBind();

        }

        protected void populate()
        {

            string[] supplierID = { "ALPA", "CHEP", "BANE" };
            if (!IsPostBack)
            {
                DdlSli.DataSource = supplierID;
                DdlSli.DataBind();
            }
        }



        protected void btnSfa_Click(object sender, EventArgs e)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                PODateLbl.Text = DateTime.Today.ToString();
                string userName = User.Identity.Name;
                RstLbl.Text = userName;
                string Deliverto = TxtDlt.Text;
                string SupplierID = DdlSli.Text;
                string Address = TxtAds.Text;
                BusinessLogic.PurchasingLogic.AddText(Deliverto, Address);




                //Response.Redirect("~/StoreClerk/ViewPurchaseOrder.aspx?Deliverto=" + TxtDlt);
                //Response.Redirect("~/StoreClerk/ViewPurchaseOrder.aspx?SupplierID=" + DdlSli);
                //Response.Redirect("~/StoreClerk/ViewPurchaseOrder.aspx?Address=" + TxtAds);
                Response.Redirect("~/StoreClerk/ViewPurchaseOrder.aspx?POnumber=" + 999);
            }
           
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtSid.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
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
            List<PORecordDetail> poRecordDetailsList = new List<PORecordDetail>();
            foreach (GridViewRow r in GridViewPO.Rows)
            {
                PORecordDetail poRecordDetails = new PORecordDetail();
                poRecordDetails.ItemID = (r.FindControl("Txtitemid") as TextBox).Text;
                poRecordDetails.UOM = (r.FindControl("DdlUOM") as DropDownList).SelectedValue;
                poRecordDetails.Quantity = int.Parse((r.FindControl("Txtquantity") as TextBox).Text);
                poRecordDetailsList.Add(poRecordDetails);
            }
            PORecordDetail poRecordDetailsNew = new PORecordDetail();
            poRecordDetailsList.Add(poRecordDetailsNew);
            GridViewPO.DataSource = poRecordDetailsList;
            GridViewPO.DataBind();

            Label temp = (Label)UpdatePanel1.FindControl("Label1");
            temp.Text = total.ToString("C0");
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
            {
                PORecordDetail poR = (PORecordDetail)e.Row.DataItem;

                string itemId = poR.ItemID;
                double poRPrice = (double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * poR.Quantity);

                Label DesLbl = (e.Row.FindControl("DesLbl") as Label);
                if (DesLbl != null)
                    DesLbl.Text = InventoryLogic.GetItemName(itemId);
                Label UnpLbl = (e.Row.FindControl("UnpLbl") as Label);
                if (UnpLbl != null)
                    UnpLbl.Text = PurchasingLogic.GetUnitPrice(itemId, "BANE").ToString();
                DropDownList DdlUOM = (e.Row.FindControl("DdlUOM") as DropDownList);
                if (DdlUOM != null)
                    DdlUOM.Text = poR.UOM;

                TextBox Txtquantity = e.Row.FindControl("Txtquantity") as TextBox;
                int Quantity = int.Parse(Txtquantity.Text);
                Label PriceLbl = (e.Row.FindControl("PriceLbl") as Label);
                if (PriceLbl != null)
                {

                    PriceLbl.Text = ((double)(PurchasingLogic.GetUnitPrice(itemId, "BANE") * Quantity)).ToString();
                    total += (PurchasingLogic.GetUnitPrice(itemId, "BANE") * Quantity);
                }

            }
        }
        protected void Txtitemid_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            TextBox Txtitemid = currentRow.FindControl("Txtitemid") as TextBox;
            string inventoryItem = InventoryLogic.GetItemName(Txtitemid.Text);

            string ItemID = Txtitemid.Text;

            Label DesLbl = currentRow.FindControl("DesLbl") as Label;
            DesLbl.Text = InventoryLogic.GetItemName(ItemID);
            Label UnpLbl = currentRow.FindControl("UnpLbl") as Label;
            UnpLbl.Text = PurchasingLogic.GetUnitPrice(ItemID, "BANE").ToString();

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
                poRecordDetails.UOM = (r.FindControl("DdlUOM") as DropDownList).Text;
                poRecordDetails.UnitPrice = (double)(PurchasingLogic.GetUnitPrice(poRecordDetails.ItemID, "BANE"));
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
            PurchasingLogic pl = new PurchasingLogic();
            List<PORecordDetail> poRecordDetaillist = new List<PORecordDetail>();
            string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
           
            foreach (GridViewRow r in GridViewPO.Rows)
            {
                string itemID = (r.FindControl("Txtitemid") as TextBox).Text;
                int quantity = int.Parse((r.FindControl("Txtquantity") as TextBox).Text);
                string uom = (r.FindControl("DdlUOM") as Label).Text;
                double unitPrice = (double)PurchasingLogic.GetUnitPrice(itemID,"BANE");
                pl.CreatePurchaseOrderDetails(itemID, quantity, uom, unitPrice);
            }

           // pl.Submitforapproval(poNo, clerkName);

           //Session["PONumber"] = poNo;
           // Server.Transfer("ViewPurchaseOrder.aspx", true);
           // statusMessage.ForeColor = System.Drawing.Color.Green;
           // statusMessage.Text = "PO" + poNo.ToString() + "submitted successfully";
        }

    }
    }

    