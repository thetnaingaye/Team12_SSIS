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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (Session["CartList"] != null && ((List<RequisitionRecordDetail>)Session["CartList"]).Count != 0)
            {
                List<RequisitionRecordDetail> cartList = (List<RequisitionRecordDetail>)Session["CartList"];
                GridViewCheckOut.DataSource = cartList;
                GridViewCheckOut.DataBind();
                GridViewCheckOut.Visible = true;
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
            GridViewAddRequest.DataBind();
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
                foreach (GridViewRow r in GridViewCheckOut.Rows)
                {
                    int i = 0;
                    TextBox txtReqQty = r.FindControl("TxtRequestedQuantity") as TextBox;
                    RequisitionRecordDetail cartItem = cartList.ElementAt(i);
                    int reqQtyInt;
                    bool isValidInt = int.TryParse(txtReqQty.Text, out reqQtyInt);
                    reqQtyInt = isValidInt == false ? 12 : reqQtyInt;
                    cartItem.RequestedQuantity = reqQtyInt;
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
            Response.Redirect("~/DepartmentEmployee/ViewCatalogue.aspx");
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

        protected void TxtRequestedQuantity_TextChanged(object sender, EventArgs e)
        {
            //List<InventoryCatalogue> rrd = new List<InventoryCatalogue>();
            //List<int> iid = new List<int>();
            //for (int i = 0; i < GridViewCheckOut.Rows.Count; i++)
            //{
            //    string ItemID = (GridViewCheckOut.Rows[i].FindControl("LblItemID") as Label).Text;
            //    string Description = (GridViewCheckOut.Rows[i].FindControl("LblDescription") as Label).Text;
            //    int RequestedQuantity;
            //    bool isNumber = int.TryParse((GridViewCheckOut.Rows[i].FindControl("TxtRequestedQuantity") as TextBox).Text, out RequestedQuantity);
            //    RequestedQuantity = isNumber ? RequestedQuantity : 0;

            //    InventoryCatalogue r = new InventoryCatalogue();
            //    r.ItemID = ItemID;
            //    r.Description = Description;
            //    rrd.Add(r);
            //    iid.Add(RequestedQuantity);
            //}

            //GridViewCheckOut.DataSource = rrd;
            //GridViewCheckOut.DataBind();
            //for (int i = 0; i < GridViewCheckOut.Rows.Count; i++)
            //{
            //    TextBox txtReqQty = GridViewCheckOut.Rows[i].FindControl("TxtRequestedQuantity") as TextBox;
            //    txtReqQty.Text = iid.ElementAt(i).ToString();
            //}

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
    }
}