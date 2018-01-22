using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;
using Team12_SSIS.BusinessLogic;


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
                //GridViewDisbursement.DataBind();

            }
        }
        //-------------------------find rep button click event-----------//
        protected void BtnFindrep_Click(object sender, EventArgs e)
        {
            string sal = DdlSal.SelectedItem.Text;
            dList = disbursement.getDisbursementByRep(sal + " " + TxtRep.Text);
            GridViewDisbursement.DataSource = dList;
            GridViewDisbursement.DataBind();

        }

         protected void DateChange(object sender, EventArgs e)
    {
        TextBox1.Text = CaldatePickerstartdate.SelectedDate.ToShortDateString();
        TextBox2.Text= CalDatePickerenddate.SelectedDate.ToShortDateString();
        }

        protected void BtnFindDate_Click(object sender, EventArgs e)
        {
            DateChange(sender, e);
            DateTime d1 = Convert.ToDateTime(TextBox1.Text);
            DateTime d2 = Convert.ToDateTime(TextBox2.Text);
            dateList=disbursement.getDisbursementByDate(d1, d2);
            GridViewDisbursement.DataSource = dateList;
            GridViewDisbursement.DataBind();

        }
        //void GridViewDisbursement_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    ((HyperLink)e.Row.Cells[1].Controls[0]).NavigateUrl = "yoururl";
        //    //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    ////    {
        //    //        var firstCell = e.Row.Cells[0];
        //    //        firstCell.Controls.Clear();
        //    //        firstCell.Controls.Add(new HyperLink { NavigateUrl = firstCell.Text, Text = firstCell.Text });
        //    //    }



        //}


    }
}