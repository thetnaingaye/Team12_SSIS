using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;
using System.Globalization;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ViewDisbursementForm : System.Web.UI.Page
    {
        List<Object> dsList;
        DisbursementLogic disbursement = new DisbursementLogic();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dsList = disbursement.GetDisbursementForm();
                GridViewDisbursement.DataSource = dsList;
                GridViewDisbursement.DataBind();

            }
        }
        //-------------------------Filter by rep-----------//
       protected void BtnFindrep_Click(object sender, EventArgs e)
        {
            string sal = DdlSal.SelectedItem.Text;
            dsList = disbursement.GetDisbursementByRep(sal + " " + TxtRep.Text);
            GridViewDisbursement.DataSource = dsList;
            GridViewDisbursement.DataBind();

        }
        //-------------------------filter by date range----------//
        protected void BtnFindDate_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.ParseExact(Request.Form["datepicker"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime d2= DateTime.ParseExact(Request.Form["datepicker2"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            dsList =disbursement.GetDisbursementByDate(d1, d2);
            GridViewDisbursement.DataSource = dsList;
            GridViewDisbursement.DataBind();

        }

        protected void GridViewDisbursement_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;

        }

    }
}