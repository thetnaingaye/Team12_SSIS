using System;
using System.Collections.Generic;
using System.Drawing;
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
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (!IsPostBack)
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
            DdlDept.SelectedIndex = 0;
        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            RetrieveDisbursementData();
        }

        protected void DdlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrieveDisbursementData();
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

        private void RetrieveDisbursementData()
        {
            List<CollectionPoint> pointList = DisbursementLogic.ListCollectionPoints();
            int collectionId = DisbursementLogic.GetListofDepartments().Where(x => x.DeptID == DdlDept.SelectedValue).Select(x => x.CollectionPointID).FirstOrDefault();
            LblCollectPoint.Text = pointList.Where(x => x.CollectionPointID == collectionId).Select(x => x.CollectionPoint1).FirstOrDefault();
            LblDeptRep.Text = DisbursementLogic.GetDeptRepFullName(DdlDept.SelectedValue);

            string deptId = DdlDept.SelectedValue;
            List<InventoryRetrievalList> rList = InventoryLogic.GetListOfInventoryRetrival(deptId);
            if (rList.Count > 0)
            {                
                GridViewDisbList.DataSource = rList;
                GridViewDisbList.DataBind();

                GridViewDisbList.Visible = true;
                BtnCreateDis.Visible = true;

                statusMessage.Text = string.Empty;

            }
            else
            {
                GridViewDisbList.Visible = false;
                BtnCreateDis.Visible = false;
                statusMessage.ForeColor = Color.Red;
                statusMessage.Text = "No Disbursement Found for " + DdlDept.SelectedItem;

            }

            
        }
    }
}