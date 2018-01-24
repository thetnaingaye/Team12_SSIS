﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
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
            List<RequisitionRecordDetail> rrd = new List<RequisitionRecordDetail>();
            string deptId = HttpContext.Current.Profile.GetPropertyValue("department").ToString();
            string fullName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            DateTime requestDate = DateTime.Now;
            int requestId = RequisitionLogic.CreateRequisitionRecord(fullName, deptId, requestDate);
            if (rrd == null) return;
            for (int i = 0; i < GridViewCheckOut.Rows.Count; i++)
            {
                string ItemID = (GridViewCheckOut.Rows[i].FindControl("LblItemID") as Label).Text;
                string Description = (GridViewCheckOut.Rows[i].FindControl("LblDescription") as Label).Text;
                int RequestedQuantity;
                bool isNumber = int.TryParse((GridViewCheckOut.Rows[i].FindControl("TxtRequestedQuantity") as TextBox).Text, out RequestedQuantity);

                string Status = "Pending";
                string Priority = "No";
                RequisitionRecordDetail r = RequisitionLogic.CreateRequisitionRecordDetail(requestId, ItemID, RequestedQuantity, Status, Priority);
                rrd.Add(r);
            }
            Session["CartList"] = rrd;
            Response.Redirect("CreateRequisitionForm.aspx");
        }
        protected void GridViewCheckOut_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ItemID = Convert.ToString(GridViewCheckOut.DataKeys[e.RowIndex].Values[0]);
            List<InventoryCatalogue> currentList = (List<InventoryCatalogue>)Session["CartList"];
            List<InventoryCatalogue> icList2 = RequisitionLogic.DeleteOrder(currentList, ItemID);
            BindGrid();
            Session["CartList"] = icList2;
        }

        protected void LinkButtonViewCatalogue_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCatalogue.aspx");
        }

        protected void TxtRequestedQuantity_TextChanged(object sender, EventArgs e)
        {
            List<InventoryCatalogue> rrd = new List<InventoryCatalogue>();
            List<int> iid = new List<int>();
            for (int i = 0; i < GridViewCheckOut.Rows.Count; i++)
            {
                string ItemID = (GridViewCheckOut.Rows[i].FindControl("LblItemID") as Label).Text;
                string Description = (GridViewCheckOut.Rows[i].FindControl("LblDescription") as Label).Text;
                int RequestedQuantity;
                bool isNumber = int.TryParse((GridViewCheckOut.Rows[i].FindControl("TxtRequestedQuantity") as TextBox).Text, out RequestedQuantity);
                RequestedQuantity = isNumber ? RequestedQuantity : 0;

                InventoryCatalogue r = new InventoryCatalogue();
                r.ItemID = ItemID;
                r.Description = Description;

                rrd.Add(r);
                iid.Add(RequestedQuantity);
            }

            GridViewCheckOut.DataSource = rrd;
            GridViewCheckOut.DataBind();
            for (int i = 0; i < GridViewCheckOut.Rows.Count; i++)
            {
                TextBox txtReqQty = GridViewCheckOut.Rows[i].FindControl("TxtRequestedQuantity") as TextBox;
                txtReqQty.Text = iid.ElementAt(i).ToString();
            }

        }
    }
}