using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.BusinessLogic
{
    //Khair Line 15 to 315
    //Jane Line 316 to 616
    //Naing Line 617 to 917
    //Pradeep 1218 to 1518
    //Yishu Line 1519 to 1820
    public class RequisitionLogic
    {
        // Retrieve requisition order by RequestID
        public RequisitionRecord FindRequisitionRecord(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecords.Where(x => x.RequestID == reqID).First();
            }
        }

        // Retrieve requisition order details by RequestID
        public RequisitionRecordDetail FindRequisitionRecordDetails(int reqDetailID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecordDetails.Where(x => x.RequestDetailID == reqDetailID).First();
            }
        }

        // Retrieve ALL requisition orders
        public List<RequisitionRecord> ListAllRequisitionRecords()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecords.ToList<RequisitionRecord>();
            }
        }

        // Retrieve all requisition orders by dept
        public List<RequisitionRecord> ListAllRRBySpecificDept(string deptID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecords.Where(x => x.DepartmentID.Equals(deptID)).ToList<RequisitionRecord>();
            }
        }

        // Retrieve all requisition orders by dept and status
        //public List<RequisitionRecord> ListAllRRBySpecificDeptAndStatus(string deptID, string status)
        //{
        //    using (SA45Team12AD context = new SA45Team12AD())
        //    {
        //        return context.RequisitionRecords.Where(x => x.DepartmentID.Equals(deptID)).Where(x => x.Status.Equals(status)).ToList<RequisitionRecord>();
        //    }
        //}

        // Retrieve all requisition orders by dept and status [Used by dept head]
        public List<RequisitionRecord> ListAllRRBySpecificDeptAndStatus(string deptID, string status)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                List<RequisitionRecord> opt = new List<RequisitionRecord>();
                List<RequisitionRecord> temp = context.Database.SqlQuery<RequisitionRecord>("EXEC [SA45Team12AD].[dbo].[RetrieveRRByStatus] @Status = {0}", status).ToList();

                // Filtering by dept
                foreach (var item in temp)
                {
                    if (item.DepartmentID.Equals(deptID))
                    {
                        opt.Add(item);
                    }
                }
                return opt;
            }
        }
        // Retrieve all CURRENT requisition records
        public List<RequisitionRecord> ListCurrentRequisitionRecord()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.Database.SqlQuery<RequisitionRecord>("EXEC [SA45Team12AD].[dbo].[RetrieveRRByStatus] @Status = {0}", "Approved").ToList();
            }
        }

        // Retrieve all PAST requisition orders
        public List<RequisitionRecord> ListPastRequisitionRecord()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.Database.SqlQuery<RequisitionRecord>("EXEC [SA45Team12AD].[dbo].[RetrieveRRByStatus] @Status = {0}", "Processed").ToList();
            }
        }

        // Retrieve details from RequisitionRecordDetails
        public List<RequisitionRecordDetail> RetrieveRequisitionRecordDetails(int reqID, string status)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecordDetails.Where(x => x.RequestID == reqID).Where(y => y.Status.Equals(status)).ToList<RequisitionRecordDetail>();
            }
        }

        // Retrieve specific dept name
        public string GetDepartmentName(string deptID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                Department temp = context.Departments.Where(x => x.DeptID.Equals(deptID)).First();
                return temp.DepartmentName.ToString();
            }
        }

        // Retrieve all PAST requisition orders according to the specified department name
        public List<RequisitionRecord> ListPastRequisitionRecordsByDept(string input)
        {
            List<RequisitionRecord> temp;
            using (SA45Team12AD context = new SA45Team12AD())
            {
                try
                {
                    temp = context.Database.SqlQuery<RequisitionRecord>("[SA45Team12AD].[dbo].[PastReqRecordsByDept] @DeptName = {0}", input).ToList();
                }
                catch (Exception)
                {
                    temp = null;
                }
                return temp;
            }
        }

        // Retrieve list of all department names
        public List<string> GetDeptNameList()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                List<Department> temp = context.Departments.ToList();
                List<string> nameList = new List<string>();
                foreach (var item in temp)
                {
                    nameList.Add(item.DepartmentName);
                }

                return nameList;
            }
        }

        // Retrieving deptID from the requisition record table
        public string GetDeptID(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                RequisitionRecord rd = context.RequisitionRecords.Where(x => x.RequestID.Equals(reqID)).First();
                return (string)rd.DepartmentID;
            }
        }

        // Retrieving status for each reqrecorddetails item
        public string GetStatus(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                RequisitionRecordDetail rd = context.RequisitionRecordDetails.Where(x => x.RequestID.Equals(reqID)).First();
                return (string)rd.Status;
            }
        }

        // Checking status for each reqrecorddetails item
        public bool CheckStatus(int reqID, string status)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                try
                {
                    RequisitionRecordDetail rd = context.RequisitionRecordDetails.Where(x => x.RequestID == reqID).Where(y => y.Status.Equals(status)).First();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        // Creating our list to be populated into the stationery retrieval list --- Priority is assessed and done here.
        public List<TempInventoryRetrieval> CreateTempList(List<RequisitionRecordDetail> tempList, string itemID)
        {
            List<TempInventoryRetrieval> result = new List<TempInventoryRetrieval>();
            using (SA45Team12AD context = new SA45Team12AD())
            {
                // Declare attrs
                int totalReqQty = 0;
                int existingQty = 0;

                // Det total REQUESTED quantity
                foreach (var item in tempList)
                {
                    totalReqQty += (int)item.RequestedQuantity;
                }

                // Det EXISTING qty
                InventoryCatalogue temp = context.InventoryCatalogues.Where(x => x.ItemID.Equals(itemID)).First();
                existingQty = temp.UnitsInStock;

                // Will immediately return with the completed list if existing qty in the inventory is currently zero.
                if (existingQty == 0)
                {
                    foreach (var item in tempList)
                    {
                        TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, 0);
                        result.Add(t);
                    }
                    return result;
                }

                // Check if total req items for the row exceeds existing inventory level
                if (totalReqQty > existingQty)
                {
                    List<RequisitionRecordDetail> priorityList = new List<RequisitionRecordDetail>();

                    //Populating the priority list if any
                    foreach (var item in tempList)
                    {
                        //to wait for next database modificaiton 
                        //if (item.Priority.Equals("Yes")) priorityList.Add(item);
                    }

                    // If none are remarked to be priority by the system, remaining qty will be divided equally between all the products.
                    if (priorityList.Count == 0)
                    {
                        int dividedQty = existingQty / tempList.Count;

                        foreach (var item in tempList)
                        {
                            TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, dividedQty);
                            result.Add(t);
                        }
                    }
                    else //Means some requests are considered priority requests...
                    {
                        // Check if all is priority
                        if (priorityList.Count == tempList.Count)
                        {
                            int dividedQty = existingQty / tempList.Count;

                            foreach (var item in tempList)
                            {
                                TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, dividedQty);
                                result.Add(t);
                            }
                        }
                        else  // If not all in the list are priority requests...
                        {
                            // Det total qty of all priority requests
                            int priorityTotalReq = 0;
                            foreach (var item in priorityList)
                            {
                                priorityTotalReq += (int)item.RequestedQuantity;
                            }

                            // Check if priority's total req is more than the existing stock level
                            if (priorityTotalReq > existingQty)
                            {
                                int dividedQty = existingQty / priorityList.Count;

                                foreach (var item in tempList)
                                {
                                    //if (item.Priority.Equals("Yes"))    // Partially satisfy priority's requested qty
                                    //{
                                    //    TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, dividedQty);
                                    //    result.Add(t);
                                    //}
                                    //else
                                    //{
                                    //    TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, 0);  // zero for non-priority
                                    //    result.Add(t);
                                    //}
                                }
                            }
                            else
                            {
                                int rmd = (existingQty - priorityTotalReq) / (tempList.Count - priorityList.Count);

                                // If priority's total req is not more than the existing inventory level
                                foreach (var item in tempList)
                                {
                                    //if (item.Priority.Equals("Yes"))    // Satisfy priority's requested qty
                                    //{
                                    //    TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, (int)item.RequestedQuantity);
                                    //    result.Add(t);
                                    //}
                                    //else
                                    //{
                                    //    TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, rmd);
                                    //    result.Add(t);
                                    //}
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in tempList)
                    {
                        TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, (int)item.RequestedQuantity);
                        result.Add(t);
                    }
                }
                return result;
            }
        }





























































































































































































































































































































































































































































































































































































































        //Naing

    




































































































































































































































































































































































































































































































































































































































































































































































































































































































































        public List<InventoryCatalogue> SearchBy(string value)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues.Where(i => i.ItemID.Contains(value) || i.Description.Contains(value)).ToList();
            }
        }

        //public static List<InventoryCatalogue> DeleteOrder(List<InventoryCatalogue> _bookList, int bookID)
        //{
        //    //List<Book> bookList = _bookList;
        //    //Book removeBook = bookList.Where(b => b.BookID == bookID).First<Book>();
        //    //bookList.Remove(removeBook);
        //    //return bookList;
        //}

    }
    }