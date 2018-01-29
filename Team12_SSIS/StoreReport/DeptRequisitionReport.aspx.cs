﻿using Microsoft.Reporting.WebForms;
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
    public partial class DeptRequisitionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["DepartmentList"] = new List<Department>();
                ReportViewerDeptReq.Visible = false;
                BindControls();
            }
        }

        void BindControls()
        {
            List<Department> dList = DisbursementLogic.GetListofDepartments();
            Department selectAll = new Department();
            selectAll.DepartmentName = "All";
            selectAll.DeptID = "All";
            dList.Add(selectAll);
            DdlDept.DataSource = dList;
            DdlDept.DataBind();
            DdlDept.SelectedIndex = dList.Count() - 1;
        }

        protected void BtnAddDept_Click(object sender, EventArgs e)
        {
            List<Department> dList = DisbursementLogic.GetListofDepartments();
            string deptID = DdlDept.SelectedValue;
            if(deptID == "All")
            {
                BindGrid(dList);
            }
            else
            {
                dList = (List<Department>)Session["DepartmentList"];
                Department selectItem = DisbursementLogic.GetListofDepartments().Where(x => x.DeptID == deptID).FirstOrDefault();
                dList.Add(selectItem);
                Session["DepartmentList"] = dList;
                BindGrid(dList);

            }

        }

        void BindGrid(List<Department> dList)
        {
            GridViewDept.DataSource = dList;
            GridViewDept.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string itemCode = TxtItemCode.Text;
            DateTime startDate = DateTime.ParseExact(Request.Form["datepickerStart"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Request.Form["datepickerEnd"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            SA45Team12ADDataSetReqHx.RequisitionHistoryDataTable dt = new SA45Team12ADDataSetReqHx.RequisitionHistoryDataTable();
            SA45Team12ADDataSetReqHxTableAdapters.RequisitionHistoryTableAdapter ta = new SA45Team12ADDataSetReqHxTableAdapters.RequisitionHistoryTableAdapter();
            SA45Team12ADDataSetReqHx ds = new SA45Team12ADDataSetReqHx();

            if (DdlDept.SelectedValue == "All")
            {
                ta.Fill(dt, startDate, endDate, itemCode, "*");
            }
            else
            {
                foreach(GridViewRow r in GridViewDept.Rows)
                {
                    string deptId = (r.FindControl("LblDeptID") as Label).Text;
                    dt.Merge(ta.GetData(startDate, endDate, itemCode, deptId));                     
                }
            }

            ReportParameter startDateParam = new ReportParameter("StartDate", startDate.ToString("d"));
            ReportParameter endDateParam = new ReportParameter("EndDate", endDate.ToString("d"));
            ReportParameter itemDescParam = new ReportParameter("ItemDescription", InventoryLogic.GetItemName(itemCode));
            ReportViewerDeptReq.LocalReport.SetParameters(new ReportParameter[] { startDateParam, endDateParam, itemDescParam });
            ReportDataSource dataSource = new ReportDataSource("SA45Team12ADDataSetReqHx", (DataTable)dt);
            ReportViewerDeptReq.LocalReport.DataSources.Clear();
            ReportViewerDeptReq.LocalReport.DataSources.Add(dataSource);
            ReportViewerDeptReq.LocalReport.Refresh();
            ReportViewerDeptReq.Visible = true;
        }
    }
}