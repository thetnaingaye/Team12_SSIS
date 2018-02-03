//Thet Naing Aye and SICAT JANE ESCALADA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Web.Profile;
using System.Web.Security;
using Team12_SSIS.Utility;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{


    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGrid();
            }
            
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Chart2_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Chart4_Load(object sender, EventArgs e)
        {

        }

        protected int GetReorders(String status)
        {

            List<ReorderRecord> list = PurchasingLogic.PopulateReorderTable();

            if (list == null)
            { return 0; }
            else
            {
                return list.Count;
            }



        }
        protected int GetDeliveryOrders(String status)
        {
            List<PORecord> plist = PurchasingLogic.GetListOfPO(status);
            return plist.Count;
        }

        private void BindGrid()
        {
            GridView1.DataSource = RequisitionLogic.ListCurrentRequisitionRecord();
            GridView1.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label l = e.Row.FindControl("LblDept") as Label;
                string id = l.Text;

                string deptname = RequisitionLogic.GetDepartmentName(id);
                l.Text = deptname;
            }

            
        }
    }
}