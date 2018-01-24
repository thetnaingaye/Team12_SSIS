using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class CheckOutRequest : System.Web.UI.Page
    {
        SA45Team12AD entities = new SA45Team12AD();
        List<InventoryCatalogue> icList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            icList = (List<InventoryCatalogue>)Session["CartList"];

            GridViewCheckOut.DataSource = icList;
            GridViewCheckOut.DataBind();
        }
        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateRequisitionForm.aspx");
        }
        protected void GridViewCheckOut_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ItemID = Convert.ToString(GridViewCheckOut.DataKeys[e.RowIndex].Values[0]);
            List<InventoryCatalogue> currentList = (List<InventoryCatalogue>)Session["CartList"];
            List<InventoryCatalogue> icList2 = BusinessLogic.RequisitionLogic.DeleteOrder(currentList, ItemID);
            BindGrid();
            Session["CartList"] = icList2;
        }

        protected void LinkButtonViewCatalogue_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCatalogue.aspx");
        }
        List<RequisitionRecordDetail> rrd;

        //protected void TxtRequestedQuantity_TextChanged(object sender, EventArgs e)
        //{
            //    rrd = (List<RequisitionRecordDetail>)Session["CartList"];
            //    if (rrd == null) return;
            //    for (int i = 0; i < GridViewCheckOut.Rows.Count; i++)
            //    {
            //        string ItemID = GridViewCheckOut.Rows[i].Cells[0].Text.ToString();
            //        string Description = ((Label)GridViewCheckOut.Rows[i].Cells[1].FindControl("LblDescription")).Text.ToString();
            //        string RequestedQuantity = ((TextBox)GridViewCheckOut.Rows[i].Cells[2].FindControl("TxtRequestedQuantity")).Text;

            //        rrd.Add(ItemID);
            //    }
            //    Session["CartList"] = rrd;
        //}
    }
}