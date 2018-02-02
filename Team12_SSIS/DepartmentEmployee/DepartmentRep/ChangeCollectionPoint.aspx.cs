//Author - Pradeep Elango

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;


namespace Team12_SSIS.DepartmentEmployee.DepartmentRep
{
    public partial class ChangeCollectionPoint : System.Web.UI.Page
    {
		Label statusMessage;
		protected void Page_Load(object sender, EventArgs e)
        {
			
			statusMessage = Master.FindControl("Lblstatus") as Label;

			if (!IsPostBack)
			{
				statusMessage.Visible = false;
				CollectionPointRbtnl.DataSource = DisbursementLogic.ListCollectionPoints();
				CollectionPointRbtnl.DataTextField = "CollectionPoint1";
				CollectionPointRbtnl.DataValueField = "CollectionPointID";
				CollectionPointRbtnl.DataBind();
				CurrentCollectionPointLbl.Text = DisbursementLogic.GetCurrentCPWithTimeByID(Int32.Parse(DisbursementLogic.GetCurrentCPIDByDep(DisbursementLogic.GetCurrentDep())));
			}
			//else
			//	ChangedLbl.Visible = true;
			
        }

		protected void ChangeCollectionPointBtn_Click(object sender, EventArgs e)
		{
			try
			{
				int newcpid = Int32.Parse(CollectionPointRbtnl.SelectedValue);
				if (CurrentCollectionPointLbl.Text == DisbursementLogic.GetCurrentCPWithTimeByID(newcpid))
				{
					statusMessage.Text = "The Collection Point is already " + CurrentCollectionPointLbl.Text;
					statusMessage.Visible = true;
					statusMessage.ForeColor = Color.Red;
				}
				else
				{
					DisbursementLogic.UpdateCollectionPoint(DisbursementLogic.GetCurrentDep(), newcpid);
					CurrentCollectionPointLbl.Text = DisbursementLogic.GetCurrentCPWithTimeByID(Int32.Parse(DisbursementLogic.GetCurrentCPIDByDep(DisbursementLogic.GetCurrentDep())));
					statusMessage.Text = "The Collection Point has been updated to " + CurrentCollectionPointLbl.Text;
					statusMessage.Visible = true;
					statusMessage.ForeColor = Color.Green;
					ChangeCollectionPointBtn.Enabled = true;
				}
			}
			catch
			{
				statusMessage.Text = "Please choose a collection point.";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Red;
			}

		}
	}
}