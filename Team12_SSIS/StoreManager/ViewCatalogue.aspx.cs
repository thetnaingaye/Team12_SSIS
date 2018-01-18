using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreManager
{
    public partial class ViewCatalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                GridView1.DataSource = entities.InventoryCatalogues.ToList<InventoryCatalogue>();
                GridView1.DataBind();
            }
        }
    }
}