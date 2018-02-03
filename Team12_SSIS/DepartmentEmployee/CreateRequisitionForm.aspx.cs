//Author: Yuan Yishu
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class CreateRequisitionForm : System.Web.UI.Page
    {
        Label statusMessage;
        List<InventoryCatalogue> icList;

        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (!IsPostBack)
            {
                BindGrid();
            }

            icList = (List<InventoryCatalogue>)Session["CartList"];
        }

        protected void BindGrid()
        {
            icList = (List<InventoryCatalogue>)Session["CartList"];
            GridViewRequisitionForm.DataSource = icList;
            GridViewRequisitionForm.DataBind();
        }

        protected void BtnSubmitForm_Click(object sender, EventArgs e)
        {
            string deptId = HttpContext.Current.Profile.GetPropertyValue("department").ToString();
            string fullName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            DateTime requestDate = DateTime.Now;
            int requestId = RequisitionLogic.CreateRequisitionRecord(fullName, deptId, requestDate);

            for (int i = 0; i < GridViewRequisitionForm.Rows.Count; i++)
            {
                string ItemID = (GridViewRequisitionForm.Rows[i].FindControl("LblItemID") as Label).Text;
                int RequestedQuantity;
                if (!int.TryParse((GridViewRequisitionForm.Rows[i].FindControl("TxtRequestedQuantity") as TextBox).Text, out RequestedQuantity))
                {
                }

                string Status = "Pending";
                string Priority = "No";
                RequisitionRecordDetail r = RequisitionLogic.CreateRequisitionRecordDetail(requestId, ItemID, RequestedQuantity, Status, Priority);

            }


            statusMessage.Text = "Stationery Requisition Form Submitted Successfully.";
            statusMessage.ForeColor = Color.Green;
            statusMessage.Visible = true;
            BtnSubmitForm.Visible = false;
            GridViewRequisitionForm.DataSource = null;
            GridViewRequisitionForm.DataBind();
            LinkButtonGoBack.Visible = false;
            Session["CartList"] = null;
        }
        protected void GridViewRequisitionForm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InventoryCatalogue ic = (InventoryCatalogue)e.Row.DataItem;
                string ItemID = ic.ItemID;
            }
        }

        protected void LinkButtonGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCatalogue.aspx");
        }
    }
}