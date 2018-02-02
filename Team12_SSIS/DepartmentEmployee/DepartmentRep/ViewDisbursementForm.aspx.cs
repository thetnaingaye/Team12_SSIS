
//-------------------------------------------Written by Thanisha-------------------------------------------------------//
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

namespace Team12_SSIS.DepartmentEmployee.DepartmentRep
{
    public partial class ViewDisbursementForm : System.Web.UI.Page
    {
        List<DisbursementList> dsList;
        List<DisbursementList> uList;
      
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uList = DisbursementLogic.GetDisbursementForm();
             var lastNlist = uList.Skip(Math.Max(0, uList.Count() -10)).Take(10); ;

                GridViewDisbursement.DataSource = lastNlist;
                GridViewDisbursement.DataBind();
                LblMsg.Visible = false;

            }
        }
      
 //-------------------------Filter by rep------------------------------------------------------------------------------//
       protected void BtnFindrep_Click(object sender, EventArgs e)
        {
           
            dsList = DisbursementLogic.GetDisbursementByRep(TxtRep.Text);
            GridViewDisbursement.DataSource = dsList;
            GridViewDisbursement.DataBind();
            LblMsg.Visible = false;

        }
//-------------------------filter by date range-----------------------------------------------------------------------//
        protected void BtnFindDate_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.ParseExact(Request.Form["datepicker"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime d2= DateTime.ParseExact(Request.Form["datepicker2"], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string d0 = d1.ToString("yyyy-MM-dd");
            string d = d2.ToString("yyyy-MM-dd");
            dsList = DisbursementLogic.GetDisbursementByDate(d1, d2);
            GridViewDisbursement.DataSource = dsList;
            GridViewDisbursement.DataBind();
            LblMsg.Visible = true;
            LblMsg.Text= "* Showing disbursement list " +  "within the date range " + d0 + " and " + d;

        }


//------------Redirect to View Disbursementlist page to see the Disbursement details-----------------------------------//

        protected void GridViewDisbList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "show")
            {
                Session["dId"] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("ViewDisbursementList.aspx");
            }
        }

    }


}
