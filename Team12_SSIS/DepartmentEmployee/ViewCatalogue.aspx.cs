using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class ViewCatalogue : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
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

        SA45Team12AD entities = new SA45Team12AD();
        protected void BtnAddRequest_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //string tempText = btn.CommandArgument.ToString();
            //string ItemID = Convert.ToString(tempText);
            //InventoryCatalogue inventoryCatalogue= entities.InventoryCatalogues.Where(i => i.ItemID == ItemID).First();
            //List<InventoryCatalogue> temp = (List<InventoryCatalogue>)Session["CartList"];
            //temp.Add(inventoryCatalogue);
            //Session["CartLists"] = temp;
        }
    }
}