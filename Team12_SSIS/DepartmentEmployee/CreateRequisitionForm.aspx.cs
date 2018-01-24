using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentEmployee
{
    public partial class CreateRequisitionForm : System.Web.UI.Page
    {
        List<String> sList;
        SA45Team12AD entities = new SA45Team12AD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

            sList = (List<String>)Session["CartList"];
        }

        protected void BindGrid()
        {
            sList = (List<String>)Session["CartList"];
            GridViewRequisitionForm.DataSource = sList;
            GridViewRequisitionForm.DataBind();
        }

        protected void BtnSubmitForm_Click(object sender, EventArgs e)
        {
            //sList= (List<String>)Session["CartList"];
            //string ItemID = (string)
        }
    }
}