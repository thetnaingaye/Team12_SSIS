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
            List<Department> deptList = DisbursementLogic.GetListofDepartments();
            DdlDept.DataSource = deptList;
            DdlDept.DataBind();
            DdlDept.DataTextField = "DepartmentName";
            DdlDept.DataValueField = "DeptID";
        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            string deptId = DdlDept.SelectedValue;
            GridViewDisbList.DataSource = InventoryLogic.GetListOfInventoryRetrival(deptId);
            GridViewDisbList.DataBind();
        }

        protected void DdlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CollectionPoint> pointList = DisbursementLogic.ListCollectionPoints();
            int collectionId = DisbursementLogic.GetListofDepartments().Where(x => x.DeptID == DdlDept.SelectedValue).Select(x => x.CollectionPointID).FirstOrDefault();
            LblCollectPoint.Text = pointList.Where(x => x.CollectionPointID == collectionId).Select(x => x.CollectionPoint1).FirstOrDefault();
            LblDeptRep.Text = DisbursementLogic.GetDeptRepFullName(DdlDept.SelectedValue);
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((InventoryRetrievalList)e.Row.DataItem).ItemID != null)
            {
                InventoryRetrievalList iRL = (InventoryRetrievalList)e.Row.DataItem;
                string itemId = iRL.ItemID;
                string itemName = InventoryLogic.GetItemName(itemId);

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = itemName;

            }
        }

        protected void BtnCreateDis_Click(object sender, EventArgs e)
        {

        }
    }
}