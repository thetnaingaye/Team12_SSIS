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
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SupplierList"] = new List<SupplierList>();
                ReportViewer1.Visible = false;
                BindControls();
            }
        }

        void BindControls()
        {
            List<SupplierList> sList = PurchasingLogic.ListSuppliers();
            SupplierList selectAll = new SupplierList();
            selectAll.SupplierID = "All";
            selectAll.SupplierName = "All";
            sList.Add(selectAll);
            DdlSupplier.DataSource = sList;
            DdlSupplier.DataBind();
            DdlSupplier.SelectedIndex = sList.Count() - 1;
        }

        protected void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            List<SupplierList> sList = PurchasingLogic.ListSuppliers();
            string supplierID = DdlSupplier.SelectedValue;
            if(supplierID == "All")
            {
                BindGrid(sList);
            }
            else
            {
                sList = (List<SupplierList>)Session["SupplierList"];
                SupplierList selectItem = PurchasingLogic.ListSuppliers().Where(x => x.SupplierID == supplierID).FirstOrDefault();
                sList.Add(selectItem);
                Session["SupplierList"] = sList;
                BindGrid(sList);

            }

        }

        void BindGrid(List<SupplierList> sList)
        {
            GridViewSupplier.DataSource = sList;
            GridViewSupplier.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string itemCode = TxtItemCode.Text;
            DateTime startDate = DateTime.ParseExact(Request.Form["datepickerStart"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Request.Form["datepickerEnd"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            SA45Team12ADDataSet.StoreOrderHistoryDataTable dt = new SA45Team12ADDataSet.StoreOrderHistoryDataTable();
            SA45Team12ADDataSetTableAdapters.StoreOrderHistoryTableAdapter ta = new SA45Team12ADDataSetTableAdapters.StoreOrderHistoryTableAdapter();
            SA45Team12ADDataSet ds = new SA45Team12ADDataSet();

            if (DdlSupplier.SelectedValue == "All")
            {
                ta.Fill(dt, startDate, endDate, itemCode, "*");
            }
            else
            {
                foreach(GridViewRow r in GridViewSupplier.Rows)
                {
                    string supplierId = (r.FindControl("LblSupplierID") as Label).Text;
                    dt.Merge(ta.GetData(startDate, endDate, itemCode, supplierId));                     
                }
            }

            ReportParameter startDateParam = new ReportParameter("StartDate", startDate.ToString("d"));
            ReportParameter endDateParam = new ReportParameter("EndDate", endDate.ToString("d"));
            ReportParameter itemDescParam = new ReportParameter("ItemDescription", InventoryLogic.GetItemName(itemCode));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { startDateParam, endDateParam, itemDescParam });
            ReportDataSource dataSource = new ReportDataSource("SA45Team12ADDataSet", (DataTable)dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }
    }
}