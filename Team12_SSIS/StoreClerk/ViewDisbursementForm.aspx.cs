//Author: Lim Chang Siang
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
    public partial class ViewDisbursementList : System.Web.UI.Page
    {
        Label statusMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DisbId"] == null)
            {
                Response.Redirect("~/StoreClerk/ViewDisbursementList.aspx");
            }
            else
            {
                int disbId = (int)Session["DisbId"];
                SetStatusLabel();
                BindGrid(disbId);
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ((DisbursementListDetail)e.Row.DataItem).ItemID != null)
            {
                DisbursementListDetail dLD = (DisbursementListDetail)e.Row.DataItem;
                string itemId = dLD.ItemID;
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
        protected void BtnCancelDis_Click(object sender, EventArgs e)
        {
            int disbursementId = (int)Session["DisbId"];
            DisbursementLogic.UpdateDisbursementStatus(disbursementId, "Cancelled");
            statusMessage.ForeColor = Color.Green;
            statusMessage.Text = "Disbursement List DL" + disbursementId.ToString("0000") + " Cancelled.";

            BindLabels(disbursementId);
        }
        private void BindGrid(int disbursementId)
        {
            List<DisbursementListDetail> dList = DisbursementLogic.GetDisbursementListDetails(disbursementId);
            GridViewDisbList.DataSource = dList;
            GridViewDisbList.DataBind();

            BindLabels(disbursementId);

            GridViewDisbList.Visible = true;
        }
        private void BindLabels(int disbursementId)
        {
            DisbursementList dL = DisbursementLogic.GetDisbursementList(disbursementId);

            string status = dL.Status;
            LblDisbId.Text = "DL" + disbursementId.ToString("0000");
            LblColDate.Text = ((DateTime)dL.CollectionDate).ToString("d");
            LblCollectPoint.Text = DisbursementLogic.GetCurrentCPWithTimeByID(dL.CollectionPointID);
            LblDeptRep.Text = dL.RepresentativeName;
            LblDeptName.Text = DisbursementLogic.GetListofDepartments().Where(x => x.DeptID == dL.DepartmentID).Select(x => x.DepartmentName).FirstOrDefault();
            LblStatus.Text = dL.Status;

            switch (status)
            {
                case ("Collected"):
                    {
                        BtnCancelDis.Visible = false;
                        LblCollectedBy.Visible = true;
                        ImgSignature.ImageUrl = "http://localhost/Team12_SSIS/Images/" + "DL" + dL.DisbursementID + ".jpg";
                        ImgSignature.Visible = true;
                        break;
                    }
                case ("Pending Collection"):
                    BtnCancelDis.Visible = true;
                    break;
                default:
                    BtnCancelDis.Visible = false;
                    break;
            }
        }
        private void SetStatusLabel()
        {
            statusMessage = this.Master.FindControl("LblStatus") as Label;
            if (Session["statusMsg"] != null)
            {
                statusMessage.Text = (string)Session["statusMsg"];
                statusMessage.ForeColor = Color.Green;
                statusMessage.Visible = true;
                Session["statusMsg"] = null;
            }
            else
                statusMessage.Visible = false;

        }
    }


}