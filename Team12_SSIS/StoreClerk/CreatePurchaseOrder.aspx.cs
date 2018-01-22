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
    public partial class CreatePurchaseOrder : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string[] supplierID = { "ALPA", "CHEP", "BANE" };
            if (!IsPostBack)
            {
                DdlSli.DataSource = supplierID;
                DdlSli.DataBind();
            }
            Upl.Update();

        }
        protected void btnSfa_Click(object sender, EventArgs e)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                string Deliverto = TxtDlt.Text;
                string SupplierID = DdlSli.Text;
                string Address = TxtAds.Text;



                BusinessLogic.PurchasingLogic.AddText(Deliverto, Address);
                Response.Redirect("ViewPurchaseOrder.aspx");


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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
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
            }
            PORecordDetail poRecordDetailsNew = new PORecordDetail();
            poRecordDetailsList.Add(poRecordDetailsNew);
            GridViewPO.DataSource = poRecordDetailsList;
            GridViewPO.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((PORecordDetail)e.Row.DataItem).ItemID != null)
            {
                //PORecordDetail poR = (PORecordDetail)e.Row.DataItem;
                //string itemId = poR.ItemID;
                //string porPrice = (Logic.GetUnitPrice(itemId) * poR.Quantity).ToString();

                //Label DesLbl = (e.Row.FindControl("DesLbl") as Label);
                //if (DesLbl != null)
                //    DesLbl.Text = ?;
                //Label UnpLbl = (e.Row.FindControl("UnpLbl") as Label);
                //if (UnpLbl != null)
                //    UnpLbl.Text =poR.UnitPrice;
                //DropDownList DdlUOM = (e.Row.FindControl("DdlUOM") as DropDownList);
                //if (DdlUOM != null)
                //    DdlUOM.Text = poR.UOM;
            }
        }
        protected void Txtitemid_TextChanged(object sender, EventArgs e)
        {
            //GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            //TextBox Txtitemid = currentRow.FindControl("Txtitemid") as TextBox;
            //PORecordDetail poRecordItem = PurchasingLogic.poRecordItem(Txtitemid.Text);
            //string ItemID = Txtitemid.Text;
            //Label DesLbl = currentRow.FindControl("DesLbl") as Label;
            //DesLbl.Text = ItemID;


        }
        protected void Txtquantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            TextBox txtItemCode = currentRow.FindControl("TxtItemCode") as TextBox;
            TextBox Txtquantity = currentRow.FindControl("Txtquantity") as TextBox;

        }
    }
}