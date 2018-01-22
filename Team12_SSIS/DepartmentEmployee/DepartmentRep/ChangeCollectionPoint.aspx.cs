using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;


namespace Team12_SSIS.DepartmentEmployee.DepartmentRep
{
    public partial class ChangeCollectionPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				CollectionPointRbtnl.DataSource = DisbursementLogic.ListCollectionPoints();
				CollectionPointRbtnl.DataTextField = "CollectionPoint1";
				CollectionPointRbtnl.DataValueField = "CollectionPointID";
				CollectionPointRbtnl.DataBind();
				TextBox1.Text = DisbursementLogic.GetCurrentDep();
				CurrentCollectionPointLbl.Text = DisbursementLogic.GetCurrentCPWithTimeByID(Int32.Parse(DisbursementLogic.GetCurrentCPIDByDep(DisbursementLogic.GetCurrentDep())));
			}
			else
				ChangedLbl.Visible = true;

        }

		protected void ChangeCollectionPointBtn_Click(object sender, EventArgs e)
		{
			int newcpid = Int32.Parse(CollectionPointRbtnl.SelectedValue);
			DisbursementLogic.UpdateCollectionPoint(DisbursementLogic.GetCurrentDep(), newcpid);
			CurrentCollectionPointLbl.Text = DisbursementLogic.GetCurrentCPWithTimeByID(Int32.Parse(DisbursementLogic.GetCurrentCPIDByDep(DisbursementLogic.GetCurrentDep())));
			ChangedLbl.Text = "The Collection Point has been updated to " + CurrentCollectionPointLbl.Text;

		}
	}
}