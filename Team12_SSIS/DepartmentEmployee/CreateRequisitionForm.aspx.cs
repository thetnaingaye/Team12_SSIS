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
        List<RequisitionRecordDetail> rrdList;
        SA45Team12AD entities = new SA45Team12AD();
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (!IsPostBack)
            {
                BindGrid();
            }

            rrdList = (List<RequisitionRecordDetail>)Session["CartList"];
        }

        protected void BindGrid()
        {
            rrdList = (List<RequisitionRecordDetail>)Session["CartList"];
            GridViewRequisitionForm.DataSource = rrdList;
            GridViewRequisitionForm.DataBind();
        }

        protected void BtnSubmitForm_Click(object sender, EventArgs e)
        {
            statusMessage.Text = "Stationery Requisition Form Submitted Successfully.";
            statusMessage.ForeColor = Color.Green;
            statusMessage.Visible = true;
            BtnSubmitForm.Visible = false;
            DisplayEmptyGrid();
            Session["CartList"] = null;
        }

        protected void DisplayEmptyGrid()
        {
            List<RequisitionRecordDetail> emptyList = new List<RequisitionRecordDetail>();
            RequisitionRecordDetail n = new RequisitionRecordDetail();
            emptyList.Add(n);
            GridViewRequisitionForm.DataSource = emptyList;
            GridViewRequisitionForm.DataBind();
        }

        protected void GridViewRequisitionForm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<RequisitionRecordDetail> rList = (List<RequisitionRecordDetail>) Session["CartList"];
            if(e.Row.RowType == DataControlRowType.DataRow && (RequisitionRecordDetail)e.Row.DataItem != null)
            {
                RequisitionRecordDetail r = (RequisitionRecordDetail)e.Row.DataItem;
                Label lblDesc = e.Row.FindControl("LblDescription") as Label;
                if (lblDesc != null)
                    lblDesc.Text = InventoryLogic.GetItemName(r.ItemID);
            }
        }

        protected void LinkButtonGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCatalogue.aspx");
        }
    }
}