//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class ViewDisbursementList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindDdls();
            }

        }

        protected void GridViewDisbList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (DisbursementList)e.Row.DataItem != null)
            {
                DisbursementList dL = (DisbursementList)e.Row.DataItem;
                string dept = DisbursementLogic.GetListofDepartments().Where(x => x.DeptID == dL.DepartmentID).Select(x => x.DepartmentName).FirstOrDefault();
                string colPoint = DisbursementLogic.GetCurrentCPWithTimeByID(dL.CollectionPointID);

                Label lblDept = e.Row.FindControl("LblDept") as Label;
                if (lblDept != null)
                    lblDept.Text = dept;
                Label lblColPoint = e.Row.FindControl("LblColPoint") as Label;
                if (lblColPoint != null)
                    lblColPoint.Text = colPoint;

            }
        }


        private void BindDdls()
        {
            List<Department> deptList = DisbursementLogic.GetListofDepartments();
            Department allDept = new Department();
            allDept.DepartmentName = "All";
            allDept.DeptID = "All";
            deptList.Add(allDept);
            DdlDept.DataSource = deptList;
            DdlDept.DataBind();
            DdlDept.SelectedIndex = 0;

            List<CollectionPoint> colPointList = DisbursementLogic.GetListofColPoint();
            CollectionPoint allColPoint = new CollectionPoint();
            allColPoint.CollectionPointID = -1;
            allColPoint.CollectionPoint1 = "All";
            colPointList.Add(allColPoint);
            DdlColPoint.DataSource = colPointList;
            DdlColPoint.DataBind();
            DdlColPoint.SelectedIndex = 0;

        }

        private void BindGrid()
        {
            GridViewDisbList.DataSource = DisbursementLogic.GetDisbursementList();
            GridViewDisbList.DataBind();
        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            string dept = DdlDept.SelectedValue;
            List<DisbursementList> dList;
            switch (dept)
            {
                case ("All"):
                    dList = DisbursementLogic.GetListOfDisbursements();
                    break;
                default:
                    dList = DisbursementLogic.GetListOfDisbursements("DepartmentID", dept);
                    break;
            }
            GridViewDisbList.DataSource = dList;
            GridViewDisbList.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string status = DdlStatus.SelectedValue;
            int colPointId = int.Parse(DdlColPoint.SelectedValue);
            DateTime collectionDate;
            List<DisbursementList> dList = status == "All" ? DisbursementLogic.GetListOfDisbursements() : DisbursementLogic.GetListOfDisbursements("Status", status);
            dList =  colPointId == -1 ? dList : dList.Where(x => x.CollectionPointID == colPointId).ToList();
            if ((DateTime.TryParseExact(Request.Form["datepicker"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out collectionDate)))
                dList = dList.Where(x => x.CollectionDate == collectionDate).ToList();
            
            GridViewDisbList.DataSource = dList;
            GridViewDisbList.DataBind();
        }

        protected void GridViewDisbList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewForm")
            {
                Session["DisbId"] = int.Parse(e.CommandArgument.ToString());
                Server.Transfer("ViewDisbursementForm.aspx", true);
            }
        }
    }
}