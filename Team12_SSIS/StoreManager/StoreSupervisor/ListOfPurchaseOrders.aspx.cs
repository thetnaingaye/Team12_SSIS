//Author: Li Jianing and Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreManager.StoreSupervisor
{
    public partial class ListOfPurchaseOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            List<PORecord> poRecordList = PurchasingLogic.GetListOfPurchaseOrder("Pending");
            GridViewLPO.DataSource = poRecordList;
            GridViewLPO.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton LBtnPONumber = (e.Row.FindControl("LBtnPONumber") as LinkButton);

        }
        protected void GridViewAPO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewApproveDetails")
            {
                Session["PONumber"] = e.CommandArgument.ToString();
                Server.Transfer("ApprovePurchaseOrder.aspx", true);
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLPO.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void DdlShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PORecord> poRecordList = DdlShow.SelectedValue == "All" ? PurchasingLogic.GetListOfPurchaseOrder() : PurchasingLogic.GetListOfPurchaseOrder(DdlShow.SelectedValue);
            GridViewLPO.DataSource = poRecordList;
            GridViewLPO.DataBind();
        }

        protected string GetTotal(object poNum)
        {
            double temp = PurchasingLogic.FindTotalByPONum(Convert.ToInt32(poNum.ToString()));
            return temp.ToString("C0");
        }

    }
}