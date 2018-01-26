using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Team12_SSIS.StoreManager
{
    public partial class ViewSupplierList : System.Web.UI.Page
    {
        PurchasingLogic purchasing = new PurchasingLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                GridViewSupplier.DataSource = entities.SupplierLists.ToList<SupplierList>();
                GridViewSupplier.DataBind();
            }
        }

        protected void GridViewSupplier_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string SupplierID = Convert.ToString(GridViewSupplier.DataKeys[e.RowIndex].Values[0]);
            BusinessLogic.PurchasingLogic.DeleteSupplier(SupplierID);
            BindGrid();
        }

        protected void GridViewSupplier_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewSupplier.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewSupplier_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewSupplier.Rows[e.RowIndex];

            string SupplierID = Convert.ToString(GridViewSupplier.DataKeys[e.RowIndex].Values[0]);
            string SupplierName = Convert.ToString((row.FindControl("TxtSupplierName") as TextBox).Text);
            string GSTRegistrationNo = Convert.ToString((row.FindControl("TxtGSTRegistrationNo") as TextBox).Text);
            string ContactName = Convert.ToString((row.FindControl("TxtContactName") as TextBox).Text);

            int PhoneNo = Convert.ToInt32((row.FindControl("TxtPhoneNo") as TextBox).Text);
            int FaxNo = Convert.ToInt32((row.FindControl("TxtFaxNo") as TextBox).Text);
            string Address = Convert.ToString((row.FindControl("TxtAddress") as TextBox).Text);
            int OrderLeadTime = Convert.ToInt32((row.FindControl("TxtOrderLeadTime") as TextBox).Text);
            BusinessLogic.PurchasingLogic.UpdateSupplier(SupplierID, SupplierName, GSTRegistrationNo, ContactName, PhoneNo, FaxNo, Address, OrderLeadTime);
            GridViewSupplier.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewSupplier_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewSupplier.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SupplierList supplier = (SupplierList)e.Row.DataItem;
                string SupplierID = supplier.SupplierID;
            }
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateSupplier.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string temp = TxtSearch.Text;
            GridViewSupplier.DataSource = purchasing.SearchBy(temp);
            GridViewSupplier.DataBind();
        }

        protected void GridViewSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewSupplier.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}