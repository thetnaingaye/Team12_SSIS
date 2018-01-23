using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class ViewCatalogue : System.Web.UI.Page
    {
        SA45Team12AD entities = new SA45Team12AD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                //if (Session["CartList"] != null)
                //{
                    
                //    List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];
                //    LblCount.Text = "number of books in cart : " + (temp.Count() + 0).ToString();
                //    BindGrid();
                //}
                //else
                //{
                //    List<InventoryCatalogue> temp = new List<InventoryCatalogue>();
                //    Session["CartList"] = temp;
                //    LblCount.Text = "number of books in cart : " + (temp.Count() + 0).ToString();
                //    BindGrid();
                //}
            }
            //else
            //{
            //    List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];
            //    TxtSearch.Text = (temp.Count() + 1).ToString();
            //    LblCount.Text =  "number of books in cart : "+(temp.Count() + 1).ToString();
            //    BindGrid();

            //}
        }
        protected void BindGrid()
        {
            SA45Team12AD entities = new SA45Team12AD();
            GridViewAddRequest.DataSource = entities.InventoryCatalogues.Select(i => new { i.ItemID, i.Description }
            ).ToList();
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
            //Button btn = (Button)sender;
            //string tempText = btn.CommandArgument.ToString();
            //int bookID = Convert.ToInt32(tempText);

            //Book b = context.Books.Where(x => x.BookID == bookID).First();

            ////test
            ////txtSearchField.Text = b.Title;

            //List<Book> temp = (List<Book>)Session["CartList"];
            //temp.Add(b);
            //Session["CartLists"] = temp;
        }
    }
}