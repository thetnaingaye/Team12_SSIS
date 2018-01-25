using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.DepartmentHead
{
    public partial class ViewRequisitionFormDetails : System.Web.UI.Page
    {
        RequisitionLogic r = new RequisitionLogic();
        InventoryLogic i = new InventoryLogic();
        string reqID;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieving from the link our req ID
            reqID = Request.QueryString["RequestID"];

            // Retrieving our req record using the reqID retrieved
            RequisitionRecord tempR = r.FindRequisitionRecord(Convert.ToInt32(reqID));

            if (!IsPostBack)
            {
                // Populating the labels...
                LblReqFormID.Text = Convert.ToString("RQ" + tempR.RequestID);
                LblEmployeeName.Text = tempR.RequestorName;
                LblDateCreated.Text = tempR.RequestDate.Value.ToString("MM/dd/yyyy");
                LblStatus.Text = r.GetStatus(Convert.ToInt32(reqID));
                if (String.IsNullOrWhiteSpace(tempR.Remarks))
                {
                    TxtRemarks.Text = "No remarks.";
                }
                else
                {
                    TxtRemarks.Text = tempR.Remarks;
                }

                // Toggling the visibilty of the "Approve" and "Reject" controls   ---    If "Pending", will still remain invisible
                if (r.GetStatus(Convert.ToInt32(reqID)).Equals("Pending"))
                {
                    TxtRemarks.Text = "";
                    BtnApprove.Visible = true;
                    BtnReject.Visible = true;
                    LblDateApproved.Text = "Pending";
                    LblMessage.Text = "To approve or reject this request, kindly select one of the following options below.";
                }
                else
                {
                    // Other attrs
                    LblMessage.Text = "";    // For previously approved request
                    LblDateApproved.Text = tempR.ApprovedDate.Value.ToString("MM/dd/yyyy");
                    TxtRemarks.Attributes.Add("readonly", "readonly");
                }
            }

            // Populating the gridview
            GridViewDetails.DataSource = r.FindRequisitionRecordDetailsByReqID(Convert.ToInt32(reqID));
            GridViewDetails.DataBind();
        }


        // Methods for retrieving aesthetically pleasant values for the user - rather then just showing item id for eg
        public string GetItemDescription(string itemID)
        {
            string temp = i.GetItemDescription(itemID);
            return temp.ToString();
        }

        public string GetUnitsOfMeasure(string itemID)
        {
            string temp = i.GetUnitsOfMeasure(itemID);
            return temp.ToString();
        }

        // Approving the requisition record
        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            string temp = r.ProcessRequsitionRequest(Convert.ToInt32(reqID), "Approved", RequisitionLogic.GetCurrentDeptUserName(), TxtRemarks.Text);
            LblMessage.Text = temp;

            // Modifying the textbox if successful
            if (temp.Contains("successfully"))
            {
                TxtRemarks.Text = r.GetReqRemarks(Convert.ToInt32(reqID));
                TxtRemarks.Attributes.Add("readonly", "readonly");
                BtnApprove.Visible = false;
                BtnReject.Visible = false;
            }

            // Sending a pop up message
            ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + temp + "');", true);
        }

        // Rejecting the requisition record
        protected void BtnReject_Click(object sender, EventArgs e)
        {
            string temp = r.ProcessRequsitionRequest(Convert.ToInt32(reqID), "Rejected", RequisitionLogic.GetCurrentDeptUserName(), TxtRemarks.Text);
            LblMessage.Text = temp;

            // Modifying the textbox if successful
            if (temp.Contains("successfully"))
            {
                RequisitionLogic rr = new RequisitionLogic();
                TxtRemarks.Attributes.Add("readonly", "readonly");
                BtnApprove.Visible = false;
                BtnReject.Visible = false;
                RequisitionRecord tR = rr.FindRequisitionRecord(Convert.ToInt32(reqID));
                LblDateApproved.Text = tR.ApprovedDate.Value.ToString("MM/dd/yyyy");
                LblStatus.Text = r.GetStatus(Convert.ToInt32(reqID));
            }

            // Sending a pop up message
            ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + temp + "');", true);
        }

        // Goes back to the main list
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DepartmentHead/ViewRequisitionFormList.aspx");
        }
    }
}