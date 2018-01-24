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

        private void BindGrid()
        {
            List<RequisitionRecord> requisitionRecord = RequisitionLogic.GetListOfRequisitionRecords();
            GridViewVPR.DataSource = requisitionRecord;
            GridViewVPR.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton LBtnRID = (e.Row.FindControl("LBtnRID") as LinkButton);

        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewVPR.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
   
  
}

    

    