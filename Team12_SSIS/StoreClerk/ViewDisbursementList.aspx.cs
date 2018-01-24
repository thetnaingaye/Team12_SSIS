using System;
using System.Collections.Generic;
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
            DdlDept.DataSource = deptList;
            DdlDept.DataBind();
            DdlDept.SelectedIndex = 0;
            
            List<CollectionPoint> colPointList = DisbursementLogic.GetListofColPoint();
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
            List<DisbursementList> dList = DisbursementLogic.GetListOfDisbursements("DepartmentID", dept);
            GridViewDisbList.DataSource = dList;
            GridViewDisbList.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string status = DdlStatus.SelectedValue;
            int colPointId = int.Parse(DdlColPoint.SelectedValue);
            List<DisbursementList> dList = status == "All" ? DisbursementLogic.GetListOfDisbursements() : DisbursementLogic.GetListOfDisbursements("Status", status);
            dList = dList.Where(x => x.CollectionPointID == colPointId).ToList();

            GridViewDisbList.DataSource = dList;
            GridViewDisbList.DataBind();
        }

        protected void GridViewDisbList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "ViewForm")
            {
                Session["DisbId"] = int.Parse(e.CommandArgument.ToString());
                Server.Transfer("ViewDisbursementForm.aspx", true);
            }
        }
    }
}