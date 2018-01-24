using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;
using System.Globalization;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewDisbursementList : System.Web.UI.Page
    {
        List<DisbursementList> dsList;
        List<DisbursementList> uList;
        DisbursementLogic disbursement = new DisbursementLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                uList = disbursement.GetDisbursementList();
                GridViewDisbursement.DataSource = uList;
                GridViewDisbursement.DataBind();

                DdlDep.DataSource = disbursement.GetDepartmentList();
                DdlDep.DataTextField = "DepartmentName";
                DdlDep.DataValueField = "DepartmentName";
                DdlDep.DataBind();
               
            }
        }
        //-------------------------Filter by dep-----------//
        protected void BtnFindrep_Click(object sender, EventArgs e)
        {
           string dep = DdlDep.SelectedItem.Text;
           dsList = disbursement.GetDepartmentListByDep(dep);
           GridViewDisbursement.DataSource = dsList;
           GridViewDisbursement.DataBind();

        }
        //-------------------------filter by date range----------//
        protected void BtnFindDate_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.ParseExact(Request.Form["datepicker"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(Request.Form["datepicker2"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            dsList = disbursement.GetDisbursementByDate(d1, d2);
            GridViewDisbursement.DataSource = dsList;
            GridViewDisbursement.DataBind();

        }

        //-------------------------gridview details link button click event.........//
        //-------------------------  directing to Disbursement detail page---//
        protected void Btndetailclick(Object sender, CommandEventArgs e)
        {
            int dId = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("ViewDisbursementList.aspx?DisbursementID=" + dId);

        }


    }
}
        
    
