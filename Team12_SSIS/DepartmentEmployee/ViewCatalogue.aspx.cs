using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class ViewCatalogue : Page
    {
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (!IsPostBack)
            {
                BindGrid();
            }
            //Check for a valid Shopping Cart activity. If available, grab it and put it into the gridList cart.
            if (Session["CartList"] != null && ((List<RequisitionRecordDetail>)Session["CartList"]).Count != 0)
            {
                List<RequisitionRecordDetail> cartList = (List<RequisitionRecordDetail>)Session["CartList"];
                //The problem is there of the Grid not catching the quantity is there.
                //BindCheckoutGrid(cartList);
                LblCount.Text = "Number of items requested: " + cartList.Count();
                BtnCheckOut.Visible = true;
            }
            else
            {
                LblCount.Text = "You can make stationery requisition now.";
                BtnCheckOut.Visible = false;
            }
        }

        protected void BindGrid()
        {
            InventoryLogic il = new InventoryLogic();
            List<InventoryCatalogue> itemList = il.GetAllCatalogue();
            GridViewAddRequest.DataSource = itemList;
            GridViewAddRequest.DataBind();
        }

        protected void GridViewAddRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAddRequest.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        RequisitionLogic requisitionLogic = new RequisitionLogic();
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string temp = TxtSearch.Text;
            GridViewAddRequest.DataSource = requisitionLogic.SearchBy(temp);
            GridViewAddRequest.DataBind();
        }

        protected void BtnAddRequest_Click(object sender, EventArgs e)
        {
            Button btnAddRequest = sender as Button;
            GridViewRow row = btnAddRequest.NamingContainer as GridViewRow;
            string itemId = GridViewAddRequest.DataKeys[row.RowIndex].Values[0].ToString();
            InventoryCatalogue item = InventoryLogic.GetInventoryItem(itemId);
            InventoryLogic il = new InventoryLogic();
            List<RequisitionRecordDetail> cartList;

            if (Session["CartList"] != null)
            {
                cartList = (List<RequisitionRecordDetail>)Session["CartList"];
                bool Exist= cartList.Any(x => x.ItemID == itemId);
                if (Exist)
                {
                    LblCount.Text = "You cannot request same item twice.";
                    LblCount.ForeColor = Color.Red;
                    return;
                }
                    cartList = (List<RequisitionRecordDetail>)Session["CartList"];
                    foreach (GridViewRow r in GridViewCheckOut.Rows)
                    {
                        int i = 0;
                        RequisitionRecordDetail cartItem = new RequisitionRecordDetail();
                        cartItem.ItemID = (r.FindControl("LblItemID") as Label).Text;
                        int reqQty;
                        if (int.TryParse(((r.FindControl("TxtRequestedQuantity") as TextBox).Text), out reqQty))
                            cartItem.RequestedQuantity = reqQty;
                        cartList.RemoveAt(i);
                        cartList.Add(cartItem);
                        i++;
                    }
                }
            else
            {
                cartList = new List<RequisitionRecordDetail>();
            }

            RequisitionRecordDetail rrd = new RequisitionRecordDetail();
            rrd.ItemID = itemId;
            cartList.Add(rrd);
            Session["CartList"] = cartList;
            BindCheckoutGrid(cartList);
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
                if(!int.TryParse((GridViewCheckOut.Rows[i].FindControl("TxtRequestedQuantity") as TextBox).Text, out RequestedQuantity))
                {
                    statusMessage.Text = "Error! Please enter a valid quantity!";
                    statusMessage.ForeColor = Color.Red;
                    statusMessage.Visible = true;
                }

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
            List<RequisitionRecordDetail> rrd =(List<RequisitionRecordDetail>)Session["CartList"];
            List<RequisitionRecordDetail> rrdNew = RequisitionLogic.DeleteOrder(rrd, ItemID);
            BindCheckoutGrid(rrdNew);
            Session["CartList"] = rrdNew;
            Response.Redirect("~/DepartmentEmployee/ViewCatalogue.aspx");
        }

        protected void GridViewCheckOut_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RequisitionRecordDetail rrd = (RequisitionRecordDetail)e.Row.DataItem;
                Label lblDesc = e.Row.FindControl("LblDescription") as Label;
                if (lblDesc != null)
                    lblDesc.Text = InventoryLogic.GetItemName(rrd.ItemID);
            }
        }

        protected void GridViewCheckOut_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<RequisitionRecordDetail> rrd = (List<RequisitionRecordDetail>)Session["CartList"];
            GridViewCheckOut.PageIndex = e.NewPageIndex;
            BindCheckoutGrid(rrd);
        }

        protected void BindCheckoutGrid(List<RequisitionRecordDetail> cartList)
        {
            GridViewCheckOut.DataSource = cartList;
            GridViewCheckOut.DataBind();
            GridViewCheckOut.Visible = true;
        }

    }
}