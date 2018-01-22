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
        List<DisbursementList> dList;
        List<DisbursementList> dateList;
        DisbursementLogic disbursement = new DisbursementLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dList = disbursement.getDisbursement();
                GridViewDisbursement.DataSource = dList;
                GridViewDisbursement.DataBind();

            }
        }
        //-------------------------Filter by rep-----------//
       protected void BtnFindDate_Click(object sender, EventArgs e)
        {
            string sal = DdlSal.SelectedItem.Text;
            dList = disbursement.getDisbursementByRep(sal + " " + TxtRep.Text);
            GridViewDisbursement.DataSource = dList;
            GridViewDisbursement.DataBind();

        }
        //-------------------------filter by date range----------//
        protected void BtnFindrep_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.ParseExact(Request.Form["datepicker"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime d2= DateTime.ParseExact(Request.Form["datepicker2"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            TextBox1.Text = Convert.ToString(d1);
            dateList =disbursement.getDisbursementByDate(d1, d2);
            GridViewDisbursement.DataSource = dateList;
            GridViewDisbursement.DataBind();

        }
     
    }
}