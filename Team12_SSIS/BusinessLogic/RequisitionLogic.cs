using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Team12_SSIS.Model;
using Team12_SSIS.Utility;

namespace Team12_SSIS.BusinessLogic
{

    public class RequisitionLogic
    {

        //----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//


        // Retrieve requisition order by RequestID
        public static RequisitionRecord FindRequisitionRecord(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecords.Where(x => x.RequestID == reqID).First();
            }
        }

        // Retrieve requisition order details by RequestDetailID
        public static RequisitionRecordDetail FindRequisitionRecordDetails(int reqDetailID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecordDetails.Where(x => x.RequestDetailID == reqDetailID).First();
            }
        }

        // Retrieve requisition order details by RequestID
        public static List<RequisitionRecordDetail> FindRequisitionRecordDetailsByReqID(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecordDetails.Where(x => x.RequestID == reqID).ToList();
            }
        }

        // Retrieve requisition order by 
        public static List<RequisitionRecord> FindRequisitionRecordByReqName(string reqName)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecords.Where(x => x.RequestorName.Equals(reqName)).ToList();
            }
        }

        // Retrieve ALL requisition orders
        public static List<RequisitionRecord> ListAllRequisitionRecords()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecords.ToList<RequisitionRecord>();
            }
        }

        // Retrieve all requisition orders by dept
        public static List<RequisitionRecord> ListAllRRBySpecificDept(string deptID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecords.Where(x => x.DepartmentID.Equals(deptID)).ToList<RequisitionRecord>();
            }
        }

        // Retrieve all requisition orders by dept and status [Used by dept head]
        public static List<RequisitionRecord> ListAllRRBySpecificDeptAndStatus(string deptID, string status)
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

        // Processing requisition requests by DEPARTMENT HEAD
        public static string ProcessRequsitionRequest(int reqID, string status, string approverName, string remarks)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                // Updating the status of all items in the request
                List<RequisitionRecordDetail> rd = context.RequisitionRecordDetails.Where(x => x.RequestID == reqID).ToList();
                RequisitionRecord r = context.RequisitionRecords.Where(x => x.RequestID == reqID).First();

                try
                {
                    // Updating the status in the ReqDetails table
                    foreach (var item in rd)
                    {
                        item.Status = status;
                    }

                    // Updating the reques in ReqRecords table
                    r.ApprovedDate = DateTime.Now;
                    r.ApproverName = approverName;
                    if (!String.IsNullOrWhiteSpace(remarks))
                    {
                        r.Remarks = remarks;
                    }

                    // Confirming changes to the DB
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return ("Procedure was unsuccessful.").ToString();
                }

                if (status.Equals("Approved")) return ("Request R" + reqID + ", was successfully approved.").ToString();
                else return ("Request R" + reqID + ", was successfully rejected.").ToString();
            }
        }

        // Retrieve all CURRENT requisition records
        public static List<RequisitionRecord> ListCurrentRequisitionRecord()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.Database.SqlQuery<RequisitionRecord>("EXEC [SA45Team12AD].[dbo].[RetrieveRRByStatus] @Status = {0}", "Approved").ToList();
            }
        }

        // Retrieve all PAST requisition orders
        public static List<RequisitionRecord> ListPastRequisitionRecord()
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.Database.SqlQuery<RequisitionRecord>("EXEC [SA45Team12AD].[dbo].[RetrieveRRByStatus] @Status = {0}", "Processed").ToList();
            }
        }

        // Retrieve details from RequisitionRecordDetails
        public static List<RequisitionRecordDetail> RetrieveRequisitionRecordDetails(int reqID, string status)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                return context.RequisitionRecordDetails.Where(x => x.RequestID == reqID).Where(y => y.Status.Equals(status)).ToList<RequisitionRecordDetail>();
            }
        }

        // Retrieve specific dept name
        public static string GetDepartmentName(string deptID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                Department temp = context.Departments.Where(x => x.DeptID.Equals(deptID)).First();
                return temp.DepartmentName.ToString();
            }
        }

        // Retrieve all PAST requisition orders according to the specified department name
        public static List<RequisitionRecord> ListPastRequisitionRecordsByDept(string input)
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
        public static List<string> GetDeptNameList()
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
        public static string GetDeptID(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                RequisitionRecord rd = context.RequisitionRecords.Where(x => x.RequestID.Equals(reqID)).First();
                return (string)rd.DepartmentID;
            }
        }

        // Retrieving deptID from the requisition record table
        public static string GetReqRemarks(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                RequisitionRecord rd = context.RequisitionRecords.Where(x => x.RequestID.Equals(reqID)).First();
                return (string)rd.Remarks;
            }
        }

        // Retrieving priority for each reqrecorddetails item
        public static string GetPriority(int reqDetailID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                RequisitionRecordDetail rd = context.RequisitionRecordDetails.Where(x => x.RequestDetailID == reqDetailID).First();
                return (string)rd.Priority;
            }
        }

        // Retrieving status for each reqrecorddetails item
        public static string GetStatus(int reqID)
        {
            using (SA45Team12AD context = new SA45Team12AD())
            {
                RequisitionRecordDetail rd = context.RequisitionRecordDetails.Where(x => x.RequestID.Equals(reqID)).First();
                return (string)rd.Status;
            }
        }

        // Checking status for each reqrecorddetails item
        public static bool CheckStatus(int reqID, string status)
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
        public static List<TempInventoryRetrieval> CreateTempList(List<RequisitionRecordDetail> tempList, string itemID)
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
                        if (item.Priority.Equals("Yes")) priorityList.Add(item);
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
                                    if (item.Priority.Equals("Yes"))    // Partially satisfy priority's requested qty
                                    {
                                        TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, dividedQty);
                                        result.Add(t);
                                    }
                                    else
                                    {
                                        TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, 0);  // zero for non-priority
                                        result.Add(t);
                                    }
                                }
                            }
                            else
                            {
                                int rmd = (existingQty - priorityTotalReq) / (tempList.Count - priorityList.Count);

                                // If priority's total req is not more than the existing inventory level
                                foreach (var item in tempList)
                                {
                                    if (item.Priority.Equals("Yes"))    // Satisfy priority's requested qty
                                    {
                                        TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, (int)item.RequestedQuantity);
                                        result.Add(t);
                                    }
                                    else
                                    {
                                        TempInventoryRetrieval t = new TempInventoryRetrieval(item.RequestID, item.RequestDetailID, itemID, GetDeptID(item.RequestID), (int)item.RequestedQuantity, rmd);
                                        result.Add(t);
                                    }
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

        // Retrieves the name of the current user that is logged in
        public static string GetCurrentDeptUserName()
        {
            return HttpContext.Current.Profile.GetPropertyValue("fullname").ToString();
        }



        //----------------------------- Pradeep Elango's Code Starts Here--------------------//
        public static void AddDelegate(String fullname, DateTime startdate, DateTime enddate, string depid)
        {
            if (startdate >= DateTime.Today && enddate >= startdate)
            {
                using (SA45Team12AD entities = new SA45Team12AD())
                {
                    DDelegateDetail delegateDetail = new DDelegateDetail
                    {
                        DepartmentID = depid,
                        DepartmentHeadDelegate = fullname,
                        StartDate = startdate,
                        EndDate = enddate
                    };
                    entities.DDelegateDetails.Add(delegateDetail);

                    Department department = entities.Departments.Where(x => x.DeptID == depid).First();
                    department.HasDelegate = 1;
                    entities.SaveChanges();
                }
                if (startdate == DateTime.Today)
                {
                    AddDeptHeadRoleToUser(fullname, depid);
                }
            }

        }

        public static List<DDelegateDetail> ListDelegateDetails(string depid)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.DDelegateDetails.Where(x => x.DepartmentID == depid).ToList<DDelegateDetail>();
            }
        }

        public static List<DDelegateDetail> FindDelegateDetailsByEmployeeName(string input, string dept)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.DDelegateDetails.Where(x => x.DepartmentHeadDelegate.Contains(input)).Where(x => x.DepartmentID == dept).ToList<DDelegateDetail>();
            }
        }


        public static bool HasDelegate(string depid)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                int hasdelegate = entities.Departments.Where(x => x.DeptID == depid).Select(x => x.HasDelegate).Single();
                if (hasdelegate == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public static DDelegateDetail GetLatestDelegate(string depid)
        {
            List<DDelegateDetail> currentdeplist = new List<DDelegateDetail>();
            List<DDelegateDetail> alllist = new List<DDelegateDetail>();
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                alllist = entities.DDelegateDetails.ToList();
                foreach (DDelegateDetail u in alllist)
                {
                    if (u.DepartmentID == depid)
                    {
                        currentdeplist.Add(u);
                    }
                }
            }
            return currentdeplist.OrderByDescending(x => x.EndDate).First(); ;
        }

        public static DateTime GetDelegateStartDate(DDelegateDetail dDelegateDetail)
        {
            return (DateTime)dDelegateDetail.StartDate;
        }

        public static DateTime GetDelegateEndDate(DDelegateDetail dDelegateDetail)
        {
            return (DateTime)dDelegateDetail.EndDate;


        }

        public static string GetDelegateName(DDelegateDetail dDelegateDetail)
        {
            return dDelegateDetail.DepartmentHeadDelegate.ToString();
        }

        public static void UpdateDelegate(DDelegateDetail dDelegateinput, DateTime newstartdate, DateTime newenddate)
        {
            //if (Roles.IsUserInRole(DisbursementLogic.GetUserName(dDelegateinput.DepartmentHeadDelegate, dDelegateinput.DepartmentID), "HOD"))
            {
                using (SA45Team12AD entities = new SA45Team12AD())
                {
                    DDelegateDetail dDelegate = entities.DDelegateDetails.Where(p => p.DepartmentHeadDelegate == dDelegateinput.DepartmentHeadDelegate).Where(x => x.DepartmentID == dDelegateinput.DepartmentID).Where(x => x.StartDate == dDelegateinput.StartDate).Where(x => x.EndDate == dDelegateinput.EndDate).First();
                    dDelegate.StartDate = newstartdate;
                    dDelegate.EndDate = newenddate;
                    entities.SaveChanges();
                }
                using (EmailControl em = new EmailControl())
                {
                    List<string> depuseremails = new List<string>();
                    depuseremails = Utility.Utility.GetAllUserEmailAddressListForDept(dDelegateinput.DepartmentID);
                }

            }

        }

        public static void CancelDelegate(DDelegateDetail dDelegateinput)
        {

            using (SA45Team12AD entities = new SA45Team12AD())
            {
                DDelegateDetail dDelegate = entities.DDelegateDetails.Where(p => p.DepartmentHeadDelegate == dDelegateinput.DepartmentHeadDelegate).Where(x => x.DepartmentID == dDelegateinput.DepartmentID).Where(x => x.StartDate == dDelegateinput.StartDate).Where(x => x.EndDate == dDelegateinput.EndDate).First();
                if (dDelegateinput.StartDate >= DateTime.Today)
                {
                    dDelegate.StartDate = DateTime.Today.AddDays(-1);
                }
                dDelegate.EndDate = DateTime.Today.AddDays(-1);

                Department department = entities.Departments.Where(x => x.DeptID == dDelegateinput.DepartmentID).First();

                department.HasDelegate = 0;
                entities.SaveChanges();
                if (Roles.IsUserInRole(DisbursementLogic.GetUserName(dDelegateinput.DepartmentHeadDelegate, dDelegateinput.DepartmentID), "HOD"))
                {
                    RemoveDeptHeadRoleFromUser(dDelegate.DepartmentHeadDelegate, dDelegate.DepartmentID);
                }
            }


        }

        public static void AddDeptHeadRoleToUser(string fullname, string depid)
        {
            string username = DisbursementLogic.GetUserName(fullname, depid);
            Roles.RemoveUserFromRole(username, "Employee");
            Roles.AddUserToRole(username, "HOD");
        }
        public static void RemoveDeptHeadRoleFromUser(string fullname, string depid)
        {
            string username = DisbursementLogic.GetUserName(fullname, depid);
            Roles.RemoveUserFromRole(username, "HOD");
            Roles.AddUserToRole(username, "Employee");
        }
        //----------------------------- Pradeep Elango's Code Ends Here--------------------//



        //-------------Yuan Yishu's Code Starts Here-------------------------//
        public List<InventoryCatalogue> SearchBy(string value)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues.Where(i => i.ItemID.Contains(value) || i.Description.Contains(value)).ToList();
            }
        }

        public static List<InventoryCatalogue> DeleteOrder(List<InventoryCatalogue> _itemList, string ItemID)
        {
            List<InventoryCatalogue> itemList = _itemList;
            InventoryCatalogue removeItem = itemList.Where(i => i.ItemID == ItemID).First();
            itemList.Remove(removeItem);
            return itemList;
        }
        //-------------Yuan Yishu's Code Ends Here-------------------------//



        //----------------- Li Jianing's Code Starts Here------------------//


        public static List<RequisitionRecord> ListRequisitionRecords()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.RequisitionRecords.ToList();

            }
        }

        public static List<RequisitionRecord> GetAllRequisitionRecords()
        {

            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.RequisitionRecords.ToList<RequisitionRecord>();

            }

        }

        public static string GetRecordStatus(int RequestID)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.RequisitionRecordDetails.Where(x => x.RequestID == RequestID).Select(x => x.Status).FirstOrDefault();
            }
        }

        public static List<RequisitionRecordDetail> GetListOfStatus(string status)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.RequisitionRecordDetails.Where(x => x.Status == status).ToList();


            }
        }
        public static string GetRequestStatus(int RequestID)
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.RequisitionRecordDetails.Where(x => x.RequestID.Equals(RequestID)).Select(x => x.Status).First();
            }
        }
        //----------------- Li Jianing's Code Ends Here------------------//





        //-------------------- Lim Chang Siang and Yuan Yishu's Code Starts Here-----------------------//

        public static int CreateRequisitionRecord(string requestorName, string departmentId, DateTime requestDate)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                RequisitionRecord r = new RequisitionRecord();
                r.RequestorName = requestorName;
                r.DepartmentID = departmentId;
                r.RequestDate = requestDate;
                ctx.RequisitionRecords.Add(r);
                ctx.SaveChanges();

                return r.RequestID;
            }
        }

        public static RequisitionRecordDetail CreateRequisitionRecordDetail(int requestId, string itemCode, int quantity, string status, string priority)
        {
            using (SA45Team12AD ctx = new SA45Team12AD())
            {
                RequisitionRecordDetail r = new RequisitionRecordDetail();
                r.RequestID = requestId;
                r.ItemID = itemCode;
                r.RequestedQuantity = quantity;
                r.Status = status;
                r.Priority = priority;
                ctx.RequisitionRecordDetails.Add(r);
                ctx.SaveChanges();
                return r;
            }
        }

        public IQueryable<InventoryCatalogue> GetInventoryCatalogues()
        {
            using (SA45Team12AD entities = new SA45Team12AD())
            {
                return entities.InventoryCatalogues;
            }
        }
        //-------------------- Lim Chang Siang and Yuan Yishu's Code Ends Here-----------------------//

    }
}