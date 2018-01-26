using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class ViewRequisitionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            List<RequisitionRecord> reRecordList = RequisitionLogic.GetAllRequisitionRecords();
            
            GridViewVPR.DataSource = reRecordList;
            GridViewVPR.DataBind();
           
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton LBtnLBtnRID = (e.Row.FindControl("LBtnRID") as LinkButton);

        }

        protected void GridViewVPR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RequisitionRecord record = (RequisitionRecord)e.Row.DataItem;
                
                int ReuestID = record.RequestID;
                
                Label LblDateProcessed = e.Row.FindControl("LblDateProcessed") as Label;
                if (record.ApprovedDate != null)
                {
                    LblDateProcessed.Text = ((DateTime)record.ApprovedDate).ToString("d");
                }
                else
                {
                    LblDateProcessed.Text = "null";
                }

                RequisitionRecord re = (RequisitionRecord)e.Row.DataItem;
                int RequestID1 = re.RequestID;
                Label LblStatus = e.Row.FindControl("LblStatus") as Label;
                string status= RequisitionLogic.GetRecordStatus(re.RequestID);
                if (status != null)
                    LblStatus.Text = status;

            }
        }
       

    }

    //protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridViewVPR.PageIndex = e.NewPageIndex;
    //    BindGrid();
    //}


    //protected void DdlShow_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    List<RequisitionRecord> requisitionList = DdlShow.SelectedValue == "All" ? RequisitionLogic.GetListOfRequisitionRecords() : RequisitionLogic.GetListOfRequisitionRecordDetails((DdlShow.SelectedValue);
    //    GridViewVPR.DataSource = requisitionList;
    //    GridViewVPR.DataBind();
    //    LblSupplier.Text = PurchasingLogic.ListSuppliers().Where(x => x.SupplierID == poRecord.SupplierID).Select(x => x.SupplierName).FirstOrDefault();
    //}
}
    
   
  


    

    