using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class CheckOutRequest : System.Web.UI.Page
    {
        List<InventoryCatalogue> itemRequested;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                if (Session["CartList"] == null)
                {
                    BtnCheckOut.Visible = false;
                    LblStatus.Text = "There is no item in shopping cart. Please visit catalogue page to add items to cart";
                }
            }
        }

        protected void BindGrid()
        {
            itemRequested = (List<InventoryCatalogue>)Session["CartList"];
            GridViewCheckOut.DataSource = itemRequested;
            GridViewCheckOut.DataBind();

        }

        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {

        }
        //protected void GridViewCheckOut_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string itemID = Convert.ToString(GridViewCheckOut.DataKeys[e.RowIndex].Values[0]);
        //    List<InventoryCatalogue> currentList = (List<InventoryCatalogue>)Session["CartList"];
        //    List<InventoryCatalogue> itemRequested2 = BusinessLogic.DeleteOrder(itemRequested2, itemID);
        //    BindGrid();
        //    Session["CartList"] = bList2;
        //}
    }
}