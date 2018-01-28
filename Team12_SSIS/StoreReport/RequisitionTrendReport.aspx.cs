using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreReport
{
    public partial class RequisitionTrendReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["DepartmentList"] = new List<Department>();
                ReportViewerDeptReq.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.ParseExact(Request.Form["datepickerStart"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Request.Form["datepickerEnd"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            SA45Team12ADDataSetReqTrend.RequisitionTrendDataTable dt = new SA45Team12ADDataSetReqTrend.RequisitionTrendDataTable();
            SA45Team12ADDataSetReqTrendTableAdapters.RequisitionTrendTableAdapter ta = new SA45Team12ADDataSetReqTrendTableAdapters.RequisitionTrendTableAdapter();
            SA45Team12ADDataSetReqTrend ds = new SA45Team12ADDataSetReqTrend();
            ta.Fill(dt, startDate, endDate);
            


            ReportParameter startDateParam = new ReportParameter("StartDate", startDate.ToString("d"));
            ReportParameter endDateParam = new ReportParameter("EndDate", endDate.ToString("d"));
            ReportViewerDeptReq.LocalReport.SetParameters(new ReportParameter[] { startDateParam, endDateParam});
            ReportDataSource dataSource = new ReportDataSource("SA45Team12ADDataSetReqTrend", (DataTable)dt);
            ReportViewerDeptReq.LocalReport.DataSources.Clear();
            ReportViewerDeptReq.LocalReport.DataSources.Add(dataSource);
            ReportViewerDeptReq.LocalReport.Refresh();
            ReportViewerDeptReq.Visible = true;
        }
    }
}