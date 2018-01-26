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
        SA45Team12AD entities = new SA45Team12AD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

                if (Session["CartList"] != null)
                {
                    List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];
                    LblCount.Text = "Number of items requested : " + (temp.Count() + 0).ToString();

                    GridViewCheckOut.Visible = true;
                    BtnCheckOut.Visible = true;
                    GridViewCheckOut.DataSource = temp;
                    GridViewCheckOut.DataBind();
                    return;
                }
                else
                {
                    List<InventoryCatalogue> temp = new List<InventoryCatalogue>();
                    Session["CartList"] = temp;
                    LblCount.Text = "You can make stationery requisition now.";
                    GridViewCheckOut.Visible = false;
                    BtnCheckOut.Visible = false;
                    return;
                }
            }

            List<InventoryCatalogue> temp1 = (List<InventoryCatalogue>)Session["CartList"];
            BindGrid();
            LblCount.Text = "Number of items requested : " + (temp1.Count() + 1).ToString();
            GridViewCheckOut.Visible = true;
            BtnCheckOut.Visible = true;
            GridViewCheckOut.DataSource = temp1;
            GridViewCheckOut.DataBind();
        }

        protected void BindGrid()
        {
            GridViewAddRequest.DataSource = entities.InventoryCatalogues.Select(i => new { i.ItemID, i.Description }
            ).ToList();
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
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string click = GridViewAddRequest.DataKeys[row.RowIndex].Values[0].ToString();
            string ItemIDclick = click;

            InventoryCatalogue ic = entities.InventoryCatalogues.Where(x => x.ItemID == ItemIDclick).First();
            List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];

            //Bottom GridView to use RequestionDetail
            //Modify Bottom GridView to have OnRowDataBound to show Description
            //Loop through botton GridView, get the quantity from the Textbox
            //Assign Textbox quantity to RequestDetail.Quantity
            //Update List<RequestitionDetail>
            //Add new item to the list
            //Assign to Session State
            //Response.Redirect

            //To cheat
            //Loop through the GridViewRow
            //Create List<int>, assign the quantity into the list.
            //OnRowDataBound for botton GridView, foreach int in List<int>, assign the value back to the TxtBox

            bool Exist = temp.Any(i => i.ItemID == ItemIDclick);
            if (!Exist)
            {
                temp.Add(ic);
                Session["CartList"] = temp;
                Response.Redirect("ViewCatalogue.aspx");
            }
            else
            {
                LblCount.Text = "You cannot request this item twice.";
                LblCount.ForeColor = Color.Red;
            }
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

        protected void GridViewCheckOut_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //To cheat
            //Loop through the GridViewRow
            //Create List<int>, assign the quantity into the list.
            //OnRowDataBound for botton GridView, foreach int in List<int>, assign the value back to the TxtBox
            
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<int> QuantityList = new List<int>();
                for (int i = 0; i < GridViewCheckOut.Rows.Count; i++)
                {
                    TextBox txtReqQty = GridViewCheckOut.Rows[i].FindControl("TxtRequestedQuantity") as TextBox;
                    int inputQty = Convert.ToInt32(txtReqQty.Text);
                    QuantityList.Add(inputQty);
                }

            

                for (int n = 0; n < QuantityList.Count; n++)
                {
                    int quantity = QuantityList[n];
                    (GridViewCheckOut.Rows[n].FindControl("TxtRequestedQuantity") as TextBox).Text = quantity.ToString();
                }
            }
        }
    }
}