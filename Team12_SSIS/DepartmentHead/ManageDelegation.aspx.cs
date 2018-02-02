//Author - Pradeep Elango

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

namespace Team12_SSIS.DepartmentHead
{
	public partial class ManageDelegation : System.Web.UI.Page
	{
		Label statusMessage;
		protected void Page_Load(object sender, EventArgs e)
		{
			statusMessage = this.Master.FindControl("LblStatus") as Label;
			if (!IsPostBack)
			{
				statusMessage.Visible = false;
				if (RequisitionLogic.HasDelegate(DisbursementLogic.GetCurrentDep()))
				{

					ShowCurrentDelegate();

				}
				else
				{
					MultiView1.ActiveViewIndex = 2;
					BindDdl();

				}
			}
		}

		protected void BindDdl()
		{
			EmployeesDdl.DataSource = DisbursementLogic.GetAllEmployeeFullNamesFromDept(DisbursementLogic.GetCurrentDep());
			EmployeesDdl.DataBind();
			CalStartAddDelegate.SelectedDate = DateTime.Today;
			CalEndAddDelegate.SelectedDate = DateTime.Today;
		}

		protected void ShowCurrentDelegate()
		{
			MultiView1.ActiveViewIndex = 0;
			string currentdep = DisbursementLogic.GetCurrentDep();
			DDelegateDetail currentdelegate = RequisitionLogic.GetLatestDelegate(currentdep);
			string currentdelegatename = RequisitionLogic.GetDelegateName(currentdelegate);
			DateTime currentdelegatestartdate = RequisitionLogic.GetDelegateStartDate(currentdelegate);
			DateTime currentdelegateenddate = RequisitionLogic.GetDelegateEndDate(currentdelegate);
			LblCurrentDelegate.Text = currentdelegatename;
			LblCurrentDelStartDate.Text = currentdelegatestartdate.ToShortDateString();
			LblCurrentDelEndDate.Text = currentdelegateenddate.ToShortDateString();
		}
		

		//for updating current delegate
		protected void ApplyBtn_Click(object sender, EventArgs e)
		{
			DateTime newstartdate = CalStartEditDelegate.SelectedDate;
			DateTime newenddate = CalEndEditDelegate.SelectedDate;
			string currentdep = DisbursementLogic.GetCurrentDep();
			DDelegateDetail currentdelegate = RequisitionLogic.GetLatestDelegate(currentdep);
			string fullname = RequisitionLogic.GetDelegateName(currentdelegate);
			if (newstartdate >= DateTime.Today && newstartdate <= newenddate && newstartdate != null && newenddate != null)
			{
				RequisitionLogic.UpdateDelegate(currentdelegate, newstartdate, newenddate);
				statusMessage.Text = (fullname + " has been delegated as the department head from " + newstartdate.ToShortDateString() + " to " + newenddate.ToShortDateString());
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Green;
				ShowCurrentDelegate();
			}
			else
			{
				statusMessage.Text = "Please enter a valid period";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Red;
			}
		}

		protected void CancelDelegationBtn_Click(object sender, EventArgs e)
		{
			
			string currentdep = DisbursementLogic.GetCurrentDep();
			DDelegateDetail currentdelegate = RequisitionLogic.GetLatestDelegate(currentdep);
			string fullname = RequisitionLogic.GetDelegateName(currentdelegate);
			RequisitionLogic.CancelDelegate(currentdelegate);
			MultiView1.ActiveViewIndex = 2;
			BindDdl();
			statusMessage.Text = fullname + "'s delegation has been cancelled.";
			statusMessage.Visible = true;
			statusMessage.ForeColor = Color.Green;

		}

		protected void BtnEdit_Click(object sender, EventArgs e)
		{
			statusMessage.Visible = false;
			MultiView1.ActiveViewIndex = 1;
			string currentdep = DisbursementLogic.GetCurrentDep();
			DDelegateDetail currentdelegate = RequisitionLogic.GetLatestDelegate(currentdep);
			string currentdelegatename = RequisitionLogic.GetDelegateName(currentdelegate);
			DateTime currentdelegatestartdate = RequisitionLogic.GetDelegateStartDate(currentdelegate);
			DateTime currentdelegateenddate = RequisitionLogic.GetDelegateEndDate(currentdelegate);
			CalStartEditDelegate.TodaysDate = currentdelegatestartdate;
			CalEndEditDelegate.TodaysDate = currentdelegateenddate;
			CalStartEditDelegate.SelectedDate = CalStartEditDelegate.TodaysDate;
			CalEndEditDelegate.SelectedDate = CalEndEditDelegate.TodaysDate;
			LblCurrentDelegateView2.Text = currentdelegatename;
			if(CalStartEditDelegate.SelectedDate<DateTime.Today)
			{
				CalStartEditDelegate.Enabled = false;
			}
		}

		protected void BtnAddDelegate_Click(object sender, EventArgs e)
		{
			string fullname = EmployeesDdl.Text;
			DateTime startdate = CalStartAddDelegate.SelectedDate;
			DateTime enddate = CalEndAddDelegate.SelectedDate;
			string currentdep = DisbursementLogic.GetCurrentDep();
			if (startdate >= DateTime.Today && startdate <= enddate && startdate != null && enddate != null)
			{
				RequisitionLogic.AddDelegate(fullname, startdate, enddate, currentdep);
				statusMessage.Text = (fullname + " has been delegated as the department head from " + startdate.ToShortDateString() + " to " + enddate.ToShortDateString());
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Green;
				ShowCurrentDelegate();
			}
			else
			{
				statusMessage.Text = "Please enter a valid period";
				statusMessage.Visible = true;
				statusMessage.ForeColor = Color.Red;
			}
		}

	
	}

}