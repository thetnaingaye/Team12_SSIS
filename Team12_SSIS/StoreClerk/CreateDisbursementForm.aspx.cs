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
    public partial class CreateDisbursementList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BindDeptDdl();
            }

        }

        protected void GridViewGR_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        private void BindDeptDdl()
        {
            DdlDept.DataSource = DisbursementLogic.GetListofDepartments();
            DdlDept.DataBind();
            DdlDept.DataTextField = "DepartmentName";
            DdlDept.DataValueField = "DeptID";
            DdlDept.DataBind();
        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            string deptId = DdlDept.SelectedValue;
            GridViewDisbList.DataSource = InventoryLogic.GetListOfInventoryRetrival(deptId);
            GridViewDisbList.DataBind();
        }

        protected void DdlDept_SelectedIndexChanged(object sender, EventArgs e)
        {

            LblCollectPoint.Text;
            LblDeptRep.Text;
        }
    }
}