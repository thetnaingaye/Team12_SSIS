//Author: Yuan Yishu
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

            if (Session["CartList"] != null && ((List<InventoryCatalogue>)Session["CartList"]).Count != 0)
            {
                List<InventoryCatalogue> cartList = (List<InventoryCatalogue>)Session["CartList"];

                GridViewCheckOut.Visible = true;
                GridViewCheckOut.DataSource = cartList;
                GridViewCheckOut.DataBind();

                LblCount.Text = "Number of items requested: " + cartList.Count();
                LblCount.ForeColor = Color.Black;

                BtnCheckOut.Visible = true;
            }
            else
            {
                LblCount.Text = "You can make stationery requisition now";
                LblCount.ForeColor = Color.Black;
                GridViewCheckOut.Visible = false;
                BtnCheckOut.Visible = false;
            }
        }

        protected void BindGrid()
        {
            InventoryLogic il = new InventoryLogic();
            List<InventoryCatalogue> itemList = InventoryLogic.GetAllCatalogue().Where(x => x.Discontinued != "Y").ToList();
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
            List<InventoryCatalogue> cartList;

            if (Session["CartList"] != null)
            {
                cartList = (List<InventoryCatalogue>)Session["CartList"];
                bool Exist = cartList.Any(x => x.ItemID == itemId);
                if (Exist)
                {
                    LblCount.Text = "You cannot request same item twice.";
                    LblCount.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    cartList.Add(item);
                    Session["CartList"] = cartList;
                    Response.Redirect("~/DepartmentEmployee/ViewCatalogue.aspx");

                }
            }

            else
            {
                cartList = new List<InventoryCatalogue>();
                cartList.Add(item);
                Session["CartList"] = cartList;
                Response.Redirect("~/DepartmentEmployee/ViewCatalogue.aspx");
            }
        }

        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateRequisitionForm.aspx");
        }

        protected void GridViewCheckOut_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ItemID = Convert.ToString(GridViewCheckOut.DataKeys[e.RowIndex].Values[0]);
            List<InventoryCatalogue> ic = (List<InventoryCatalogue>)Session["CartList"];
            List<InventoryCatalogue> icNew = RequisitionLogic.DeleteOrder(ic, ItemID);
            GridViewCheckOut.DataSource = icNew;
            GridViewCheckOut.DataBind();
            Session["CartList"] = icNew;
            Response.Redirect("~/DepartmentEmployee/ViewCatalogue.aspx");
        }

        protected void GridViewCheckOut_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InventoryCatalogue ic = (InventoryCatalogue)e.Row.DataItem;
                string ItemID = ic.ItemID;
            }
        }

        protected void GridViewCheckOut_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<InventoryCatalogue> ic = (List<InventoryCatalogue>)Session["CartList"];
            GridViewCheckOut.PageIndex = e.NewPageIndex;
            GridViewCheckOut.DataSource = ic;
            GridViewCheckOut.DataBind();
        }

    }
}