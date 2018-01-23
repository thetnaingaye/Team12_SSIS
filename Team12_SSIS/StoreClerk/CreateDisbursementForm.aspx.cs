using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
                string uom = InventoryLogic.GetInventoryItem(itemId).UOM;

                Label LblDesc = (e.Row.FindControl("LblDesc") as Label);
                if (LblDesc != null)
                    LblDesc.Text = itemName;
                Label LblUom = (e.Row.FindControl("LblUom") as Label);
                if (LblUom != null)
                    LblUom.Text = uom;

            }
        }

        protected void BtnCreateDis_Click(object sender, EventArgs e)
        {
            DisbursementLogic dl = new DisbursementLogic();

            DateTime date = DateTime.ParseExact(Request.Form["datepicker"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int collectionId = DisbursementLogic.GetListofDepartments().Where(x => x.DeptID == DdlDept.SelectedValue).Select(x => x.CollectionPointID).FirstOrDefault();
            string clerkName = HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
            int disbLNumber = dl.CreateDisbursementList(DdlDept.SelectedValue, collectionId, date, LblDeptRep.Text);
            
            foreach (GridViewRow r in GridViewDisbList.Rows)
            {
                string itemID = (r.FindControl("LblItemCode") as Label).Text;
                int ReqQty = int.Parse((r.FindControl("LblReqQty") as Label).Text);
                int ActualQty = int.Parse((r.FindControl("LblActulQty") as Label).Text);
                string uom = (r.FindControl("LblUom") as Label).Text;
                string remarks = (r.FindControl("TxtRemarks") as TextBox).Text;
                dl.CreateDisbursementListDetails(disbLNumber, itemID,ActualQty, ReqQty, 0, uom, remarks);
            }
            statusMessage.Text = "Disbursement List DL" + disbLNumber.ToString("0000") + " Created Successfully.";
            statusMessage.ForeColor = Color.Green;
            statusMessage.Visible = true;
            BtnCreateDis.Visible = false;

            Session["DisbId"] = disbLNumber;
            Session["LblStatus"] = statusMessage;
            Server.Transfer("~/StoreClerk/ViewDisbursementForm.aspx");
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