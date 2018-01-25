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
            List<RequisitionRecord> reRecordList = RequisitionLogic.GetListOfRequisitionRecords();
            reRecordList = reRecordList.ToList();
            GridViewVPR.DataSource = reRecordList;
            GridViewVPR.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            LinkButton LBtnRID = (e.Row.FindControl("LBtnRID") as LinkButton);
            if (e.Row.RowType == DataControlRowType.DataRow && (RequisitionRecord)e.Row.DataItem != null)
            {
                RequisitionRecord r = (RequisitionRecord)e.Row.DataItem;
                Label lblStatus = e.Row.FindControl("LblStatus") as Label;
                if (lblStatus != null)
                    lblStatus.Text = RequisitionLogic.GetRequestStatus(r.RequestID);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewVPR.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        
    }
   
  
}

    

    