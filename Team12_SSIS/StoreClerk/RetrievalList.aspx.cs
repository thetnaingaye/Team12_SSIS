using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

//----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

namespace Team12_SSIS.StoreClerk
{
    public partial class RetrievalList : System.Web.UI.Page
    {
        List<RequisitionRecordDetail> tempListDetails = new List<RequisitionRecordDetail>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tempListDetails = InventoryLogic.GetRelevantDetailList();
                List<InventoryCatalogue> tempListItems = InventoryLogic.GetRelevantItemList(tempListDetails);


                // Bind data to the list
                GridViewMainList.DataSource = tempListItems;
                GridViewMainList.DataBind();

                // If there are zero retrieved items from the DB
                if (tempListItems == null || tempListItems.Count == 0)
                {
                    TbxResult.Visible = false;
                    BtnCumulativeSubmit.Visible = false;
                }
            }


            // Populating our message
            if (Session["RetrievalListMessage"] != null)
            {
                TbxResult.Visible = true;
                TbxResult.Text = (string)Session["RetrievalListMessage"];
                Session["RetrievalListMessage"] = null;   // This resets the session.
            }
        }



        // Retrieving the summation of all items needed by the diff depts for this specific item
        protected string GetTotalQtyNeeded(string itemID)
        {
            return InventoryLogic.GetTotalQtyNeeded(itemID).ToString();
        }

        protected string GetExistingQuantity(string itemID)
        {
            return InventoryLogic.GetQuantity(itemID).ToString();
        }

        // Identifying dept name
        protected string GetDepartmentName(string deptID)
        {
            string temp = RequisitionLogic.GetDepartmentName(deptID);
            return temp.ToString();
        }

        // Determining qty ordered from the details table
        protected string GetQtyNeeded(string reqID)
        {
            var temp = RequisitionLogic.GetDepartmentName(reqID);
            return temp.ToString();
        }

        // Show error message
        protected void GetErrorMessage()
        {
            LblMessage.Text = "Invalid quantity selected";
        }

        // Identifying the priority for each req per item
        protected string GetPriority(int reqDetailID)
        {
            var temp = RequisitionLogic.GetPriority(reqDetailID);
            if (temp.Equals("Yes")) return "Priority Given";
            else return "None";
        }

        // Populating the nested gridview
        protected void GridViewMainList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Retreiving the row's item ID
                string itemID = GridViewMainList.DataKeys[e.Row.RowIndex].Value.ToString();

                // Binding data to the nested gridview
                GridView gridViewSubList = (GridView)e.Row.FindControl("GridViewSubList");
                gridViewSubList.DataSource = InventoryLogic.RetrieveTempInventoryList(itemID);
                gridViewSubList.DataBind();
            }
        }


        // Submitting retrieved amount
        protected void BtnCumulativeSubmit_Click(object sender, EventArgs e)
        {
            // Specify all our attrs that we need
            string tempStr = "";

            // Retrieving values from each cell in the gridviews
            foreach (GridViewRow row1 in GridViewMainList.Rows)
            {
                // Retrieving the itemID of this specific row
                Label LblItemID1 = (Label)row1.FindControl("LblItemID1");

                // Finding the nested GridView
                GridView GridViewSubList = (GridView)row1.FindControl("GridViewSubList");

                // Retrieving the main values from the nested GridView
                foreach (GridViewRow row2 in GridViewSubList.Rows)
                {
                    Label LblReqID = (Label)row2.FindControl("LblReqID");
                    Label LblReqDetailID = (Label)row2.FindControl("LblReqDetailID");
                    Label LblDeptID = (Label)row2.FindControl("LblDeptID");
                    Label LblQtyNeeded = (Label)row2.FindControl("LblQtyNeeded");
                    Label LblIsOverride = (Label)row2.FindControl("LblIsOverride");
                    TextBox TbxActualQty = (TextBox)row2.FindControl("TbxActualQty");

                    if (TbxActualQty.Text == "" || string.IsNullOrWhiteSpace(TbxActualQty.Text))          // SERVER-SIDE VALIDATION
                    {
                        tempStr += "Item " + LblItemID1.Text + " from department " + LblDeptID.Text + " is not processed.\n\n";
                        break;             // If any error, the entire row and subsequent rows will be gone.
                    }
                    else
                    {
                        int actQty = 0;

                        // Checking if input entered is int or not
                        if (Int32.TryParse(TbxActualQty.Text.ToString(), out actQty))
                        {
                            if (actQty == 0)
                            {
                                tempStr += "Item " + LblItemID1.Text + " from department " + LblDeptID.Text + " will not be processed.\n\n";
                            }
                            else
                            {
                                // Processing our inventory withdrawal process
                                string result = InventoryLogic.CreateNewInventoryRetrievalEntry(Convert.ToInt32(LblReqID.Text.ToString()), Convert.ToInt32(LblReqDetailID.Text.ToString()), LblItemID1.Text.ToString(),
                                    LblDeptID.Text.ToString(), Convert.ToInt32(LblQtyNeeded.Text), Convert.ToInt32(TbxActualQty.Text), Boolean.Parse(LblIsOverride.Text));

                                // Displaying its result
                                tempStr += result + "\n\n";
                            }
                        }
                        else
                        {
                            tempStr += "Invalid input for item code, " + LblItemID1.Text + ". Please try again.\n\n";
                        }
                    }
                }
            }

            // Storing message as a session state and refreshing the page
            Session["RetrievalListMessage"] = tempStr;
            Response.Redirect("~/StoreClerk/RetrievalList.aspx");
        }
    }
}