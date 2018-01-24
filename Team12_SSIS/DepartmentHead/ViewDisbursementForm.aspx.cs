using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;
using System.Globalization;
using Team12_SSIS.Utility;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ViewDisbursementForm : System.Web.UI.Page
    {
        List<DisbursementList> dsList;
        List<DisbursementList> uList;
        DisbursementLogic disbursement = new DisbursementLogic();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uList = DisbursementLogic.GetDisbursementList();
                GridViewDisbursement.DataSource = uList;
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
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[5].Visible = false;

        }

        //-------------------------gridview details link button click event.........//
        //-------------------------  directing to Disbursement detail page---//
        protected void Btndetailclick(Object sender, CommandEventArgs e)
        {
            int dId = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("ViewDisbursementList.aspx?DisbursementID="+dId);

        }


    }
}