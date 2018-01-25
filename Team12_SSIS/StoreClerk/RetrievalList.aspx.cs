using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;

namespace Team12_SSIS.StoreClerk
{
    public partial class RetrievalList : System.Web.UI.Page
    {
        //string ReqID = "10";
        RequisitionLogic r = new RequisitionLogic();
        InventoryLogic i = new InventoryLogic();
        List<int> currentReqIDs = new List<int>();
        List<RequisitionRecord> tempReqList = new List<RequisitionRecord>();
        List<RequisitionRecordDetail> tempListDetails = new List<RequisitionRecordDetail>();
        List<InventoryCatalogue> tempListItems = new List<InventoryCatalogue>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve all the req IDs of all current requisition orders
                tempReqList = r.ListCurrentRequisitionRecord();

                foreach (var item in tempReqList)
                {
                    currentReqIDs.Add(item.RequestID);
                }


                // Retrieve list of all the chosen req details
                foreach (var item in currentReqIDs)
                {
                    tempListDetails.AddRange(r.RetrieveRequisitionRecordDetails(item, "Approved"));
                }


                // From the prev list, extract its itemID and retrieve the list of items
                foreach (var item1 in tempListDetails)
                {
                    bool check = false;

                    // Check if there is a similar item in tempListItems
                    foreach (var item2 in tempListItems)
                    {
                        if (item2.ItemID == item1.ItemID)
                        {
                            check = true;
                            break;
                        }
                    }

                    // only add if there are no similar item in the list
                    if (check == false)
                    {
                        tempListItems.Add(i.FindItemByItemID(item1.ItemID));
                    }
                }

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
        public string GetTotalQtyNeeded(string itemID)
        {
            int tqNeeded = 0;

            // Taking the requested quantity only for those selected items
            foreach (var item in tempListDetails)
            {
                if (item.ItemID == itemID)
                {
                    tqNeeded += Convert.ToInt32(item.RequestedQuantity);
                }
            }
            return tqNeeded.ToString();
        }

        // Identifying dept name
        public string GetDepartmentName(string deptID)
        {
            string temp = r.GetDepartmentName(deptID);
            return temp.ToString();
        }

        // Determining qty ordered from the details table
        public string GetQtyNeeded(string reqID)
        {
            var temp = r.GetDepartmentName(reqID);
            return temp.ToString();
        }

        // Show error message
        public void GetErrorMessage()
        {
            LblMessage.Text = "Invalid quantity selected";
        }

        // Identifying the priority for each req per item
        public string GetPriority(int reqDetailID)
        {
            var temp = r.GetPriority(reqDetailID);
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

                // Intialize our list
                List<RequisitionRecordDetail> tempList = new List<RequisitionRecordDetail>();
                List<TempInventoryRetrieval> ti = new List<TempInventoryRetrieval>();

                // Creating our ReqRecord list that is relevant to this "main" row.
                foreach (var item in tempListDetails)
                {
                    if (item.ItemID == itemID)
                    {
                        tempList.Add(r.FindRequisitionRecordDetails(item.RequestDetailID));
                    }
                }

                // Creating our TempInvRetrieval list with the needed quantities
                ti = r.CreateTempList(tempList, itemID);

                // Binding data to the nested gridview
                GridView gridViewSubList = (GridView)e.Row.FindControl("GridViewSubList");
                gridViewSubList.DataSource = ti;
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
                //Retrieving the itemID of this specific row
                Label LblItemID1 = (Label)row1.FindControl("LblItemID1");


                //Finding the nested GridView
                GridView GridViewSubList = (GridView)row1.FindControl("GridViewSubList");

                //Retrieving the values from the nested GridView
                foreach (GridViewRow row2 in GridViewSubList.Rows)
                {
                    Label LblReqID = (Label)row2.FindControl("LblReqID");
                    Label LblReqDetailID = (Label)row2.FindControl("LblReqDetailID");
                    Label LblDeptID = (Label)row2.FindControl("LblDeptID");
                    Label LblQtyNeeded = (Label)row2.FindControl("LblQtyNeeded");
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
                                //Processing our inventory withdrawal process
                                string result = i.CreateNewInventoryRetrievalEntry(Convert.ToInt32(LblReqID.Text.ToString()), Convert.ToInt32(LblReqDetailID.Text.ToString()), LblItemID1.Text.ToString(),
                                    LblDeptID.Text.ToString(), Convert.ToInt32(LblQtyNeeded.Text), Convert.ToInt32(TbxActualQty.Text));

                                //Displaying its result
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