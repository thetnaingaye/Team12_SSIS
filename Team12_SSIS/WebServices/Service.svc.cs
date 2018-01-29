using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Team12_SSIS.BusinessLogic;
using Team12_SSIS.Model;
using System.Data.Entity;
using Team12_SSIS.WebServices.WCF_Model;
using System.Security.Permissions;
using System.ServiceModel.Channels;
using System.Web.Security;
using System.Security.Principal;

namespace Team12_SSIS.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        const string internalSecertKey = "4aOA4ayA4aWA4bKA4auA4LGA4K+A4ZCA4aGA4bOA4bOA4beA4a+A4bKA4aSA4YCA4KOA4LGA";
        //Chang Siang Codes 1-299
        //Khiar Codes 300-999
        public List<string> GetUsersFromDept(string dept, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<string> wcf_UnAuthObj = new List<string>();
                string wcfUnAuth = "-1";
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            return DisbursementLogic.GetFullNamesFromDept(dept);
        }

        public List<WCF_DisbursementList> GetDisbursementList(string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if(!IsAuthanticateUser(token))
            {
                List<WCF_DisbursementList> wcf_UnAuthObj = new List<WCF_DisbursementList>();
                WCF_DisbursementList wcfUnAuth = new WCF_DisbursementList();
                wcfUnAuth.DisbursementID = -1;
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }

            List<DisbursementList> dlist = DisbursementLogic.GetDisbursementList();
            List<WCF_DisbursementList> wcf_Dlist = new List<WCF_DisbursementList>();
            foreach(DisbursementList d in dlist)
            {
                WCF_DisbursementList wcfD = new WCF_DisbursementList();
                wcfD.DisbursementID = d.DisbursementID;
                wcfD.DepartmentID = d.DepartmentID;
                wcfD.CollectionPointID = d.CollectionPointID;
                wcfD.CollectionDate = ((DateTime)d.CollectionDate).ToString("d");
                wcfD.RepresentativeName = d.RepresentativeName;
                wcfD.Status = d.Status;
                wcfD.WCF_DisbursementListDetail = GetDisbursementListDetails(d.DisbursementID, internalSecertKey);
                wcf_Dlist.Add(wcfD);
            }
            return wcf_Dlist;
        }

        public List<WCF_DisbursementListDetail> GetDisbursementListDetails(int disbursementId, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<WCF_DisbursementListDetail> wcf_UnAuthObj = new List<WCF_DisbursementListDetail>();
                WCF_DisbursementListDetail wcfUnAuth = new WCF_DisbursementListDetail();
                wcfUnAuth.DisbursementID = -1;
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            List<DisbursementListDetail> ddList = DisbursementLogic.GetDisbursementListDetails(disbursementId);
            List<WCF_DisbursementListDetail> wcf_ddlist = new List<WCF_DisbursementListDetail>();
            foreach(DisbursementListDetail dd in ddList)
            {
                WCF_DisbursementListDetail wcfDd = new WCF_DisbursementListDetail();
                wcfDd.ID = dd.ID;
                wcfDd.DisbursementID = dd.DisbursementID;
                wcfDd.ItemID = dd.ItemID;
                wcfDd.ActualQuantity = (int)dd.ActualQuantity;
                wcfDd.QuantityRequested = (int)dd.QuantityRequested;
                wcfDd.QuantityCollected = dd.QuantityCollected.ToString();
                wcfDd.UOM = dd.UOM;
                wcfDd.Remarks = dd.Remarks == null ? " " : dd.Remarks;
                wcf_ddlist.Add(wcfDd);
            }
            return wcf_ddlist;

        }

        public List<WCF_InventoryCatalogue> GetInventoryList(string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<WCF_InventoryCatalogue> wcf_UnAuthObj = new List<WCF_InventoryCatalogue>();
                WCF_InventoryCatalogue wcfUnAuth = new WCF_InventoryCatalogue();
                wcfUnAuth.ItemID = "-1";
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            List<InventoryCatalogue> catalogueList = InventoryLogic.ListCatalogues();
            List<WCF_InventoryCatalogue> wcfList = new List<WCF_InventoryCatalogue>();
            foreach(InventoryCatalogue i in catalogueList)
            {
                WCF_InventoryCatalogue w = WCF_InventoryCatalogue.Create(i.ItemID, i.BIN, i.Shelf, (int)i.Level, i.CategoryID,
                    i.Description, (int)i.ReorderLevel, i.UnitsInStock, (int)i.ReorderQty, i.UOM, i.Discontinued, (int)i.UnitsOnOrder, (int)i.BufferStockLevel);
                wcfList.Add(w);
            }
            return wcfList;
        }

        public List<WCF_InventoryCatalogue> SearchInventoryList(string query, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<WCF_InventoryCatalogue> wcf_UnAuthObj = new List<WCF_InventoryCatalogue>();
                WCF_InventoryCatalogue wcfUnAuth = new WCF_InventoryCatalogue();
                wcfUnAuth.ItemID = "-1";
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            InventoryLogic inventoryLogic = new InventoryLogic();
            List<InventoryCatalogue> catalogueList = inventoryLogic.SearchBy(query);
            List<WCF_InventoryCatalogue> wcfList = new List<WCF_InventoryCatalogue>();
            foreach (InventoryCatalogue i in catalogueList)
            {
                WCF_InventoryCatalogue w = WCF_InventoryCatalogue.Create(i.ItemID, i.BIN, i.Shelf, (int)i.Level, 
                    i.CategoryID,i.Description, (int)i.ReorderLevel, i.UnitsInStock, 
                    (int)i.ReorderQty, i.UOM, i.Discontinued, (int)i.UnitsOnOrder, 
                    (int)i.BufferStockLevel);
                wcfList.Add(w);
            }
            return wcfList;
        }

        public List<WCF_StockCard> GetStockCard(string itemId, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<WCF_StockCard> wcf_UnAuthObj = new List<WCF_StockCard>();
                WCF_StockCard wcfUnAuth = new WCF_StockCard();
                wcfUnAuth.ID = -1;
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            InventoryLogic inventoryLogic = new InventoryLogic();
            List<StockCard> stockCard = inventoryLogic.GetStockcardByItemId(itemId);
            List<WCF_StockCard> wcfList = new List<WCF_StockCard>();
            foreach(StockCard i in stockCard)
            {
                WCF_InventoryCatalogue c = SearchInventoryList(i.ItemID, internalSecertKey).First();
                WCF_StockCard w = WCF_StockCard.Create(i.ID, i.ItemID, 
                    ((DateTime)i.Date).ToString("d"), i.Description, i.Type, 
                    (int)i.Quantity, i.UOM, (int)i.Balance, c);
                wcfList.Add(w);
            }
            return wcfList;
        }

        public List<WCF_RequisitionRecord> GetStationeryRequests(string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<WCF_RequisitionRecord> wcf_UnAuthObj = new List<WCF_RequisitionRecord>();
                WCF_RequisitionRecord wcfUnAuth = new WCF_RequisitionRecord();
                wcfUnAuth.RequestID = -1;
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            List<RequisitionRecord> rList = RequisitionLogic.ListAllRequisitionRecords();
            List<WCF_RequisitionRecord> wcfList = new List<WCF_RequisitionRecord>();
            foreach(RequisitionRecord r in rList)
            {
                string approvedDate = r.ApprovedDate == null ? "null" : ((DateTime)r.ApprovedDate).ToString("d");
                WCF_RequisitionRecord wcf = WCF_RequisitionRecord.Create(r.RequestID, ((DateTime)r.RequestDate).ToString("d"), r.DepartmentID,
                    r.RequestorName, approvedDate, r.ApproverName, r.Remarks, GetStationeryRequestDetails(r.RequestID.ToString(), internalSecertKey));
                wcfList.Add(wcf);
            }
            return wcfList;
        }

        public List<WCF_RequisitionRecord> GetStationeryRequestsById(string deptId, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<WCF_RequisitionRecord> wcf_UnAuthObj = new List<WCF_RequisitionRecord>();
                WCF_RequisitionRecord wcfUnAuth = new WCF_RequisitionRecord();
                wcfUnAuth.RequestID = -1;
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            List<RequisitionRecord> rList = RequisitionLogic.ListAllRRBySpecificDept(deptId);
            List<WCF_RequisitionRecord> wcfList = new List<WCF_RequisitionRecord>();
            foreach (RequisitionRecord r in rList)
            {
                string approvedDate = r.ApprovedDate == null ? "null" : ((DateTime)r.ApprovedDate).ToString("d");
                WCF_RequisitionRecord wcf = WCF_RequisitionRecord.Create(r.RequestID, ((DateTime)r.RequestDate).ToString("d"), r.DepartmentID,
                    r.RequestorName, approvedDate, r.ApproverName, r.Remarks, GetStationeryRequestDetails(r.RequestID.ToString(), internalSecertKey));
                wcfList.Add(wcf);
            }
            return wcfList;
        }

        public List<WCF_RequisitionRecordDetail> GetStationeryRequestDetails(string requestId, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                List<WCF_RequisitionRecordDetail> wcf_UnAuthObj = new List<WCF_RequisitionRecordDetail>();
                WCF_RequisitionRecordDetail wcfUnAuth = new WCF_RequisitionRecordDetail();
                wcfUnAuth.RequestDetailID = -1;
                wcf_UnAuthObj.Add(wcfUnAuth);
                return wcf_UnAuthObj;
            }
            List<WCF_RequisitionRecordDetail> wcfList = new List<WCF_RequisitionRecordDetail>();
            List<RequisitionRecordDetail> rList = RequisitionLogic.FindRequisitionRecordDetailsByReqID(int.Parse(requestId));
            foreach(RequisitionRecordDetail r in rList)
            {
                WCF_RequisitionRecordDetail wcf = WCF_RequisitionRecordDetail.Create(r.RequestDetailID, r.RequestID, r.ItemID, (int)r.RequestedQuantity, r.Status);
                wcfList.Add(wcf);
            }
            return wcfList;
        }

        //Niang to check with Khair on the logic of this method.... (ask about the status attribute)
        public void UpdateStationeryRequestStatus(WCF_RequisitionRecord record, string status, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                return;
            }
            RequisitionLogic.ProcessRequsitionRequest(record.RequestID, status, record.ApproverName, record.Remarks);
        }

        public void UpdateDisbursementStatus(WCF_DisbursementList disbursementList, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                return;
            }
            DisbursementLogic.UpdateDisbursementStatus(disbursementList.DisbursementID, disbursementList.Status);
            DisbursementLogic dl = new DisbursementLogic();
            foreach(WCF_DisbursementListDetail d in disbursementList.WCF_DisbursementListDetail)
            {
                dl.UpdateDisbursementListDetails(d.ID, Convert.ToInt32(d.QuantityCollected), d.Remarks);
            }
        }

        //public void CreateInventoryRetrievalList(WCF_InventoryRetrievalList rList)
        //{
        //    InventoryLogic iL = new InventoryLogic();
        //    iL.CreateNewInventoryRetrievalEntry(rList.RequestID, rList.RequestDetailID, rList.ItemID, rList.DepartmentID, rList.RequestedQuantity, rList.ActualQuantity);

        //}

        public void CreateAdjustmentRequest(WCF_AVRequest request, string token)
        {
            //Check if user is authorizated to use this method. If is not authorized, it will return a json with -1 in the primary key
            if (!IsAuthanticateUser(token))
            {
                return;
            }
            InventoryLogic.CreateAdjustmentVoucherRequest(request.RequestedBy, DateTime.Parse(request.DateRequested));
            foreach(WCF_AVRequestDetail i in request.WCF_AVRequestDetails)
            {
                InventoryLogic.CreateAdjustmentVoucherRequestDetails
                    (i.AVRID, i.ItemID, i.Type, i.Quantity, i.UOM, i.Reason, i.UnitPrice);
            }
        }


        // ------------------   From Khair with Love ~   ---------------------//

        // Retrieving total quantity needed on a per item basis necessary for inventory retrieval
        public int RetrieveTotalQtyNeeded(string itemID)
        {
            return InventoryLogic.GetTotalQtyNeeded(itemID);
        }

        // Retrieving the relevant item list for inventory retrieval
        public List<WCF_InventoryCatalogue> GetRelevantItemList()
        {
            var temp1 = InventoryLogic.GetRelevantDetailList();
            var temp2 = InventoryLogic.GetRelevantItemList(temp1);
            List<WCF_InventoryCatalogue> wcfList = new List<WCF_InventoryCatalogue>();
            foreach (InventoryCatalogue i in temp2)
            {
                WCF_InventoryCatalogue w = WCF_InventoryCatalogue.Create(i.ItemID, i.BIN, i.Shelf, (int)i.Level, i.CategoryID,
                    i.Description, (int)i.ReorderLevel, i.UnitsInStock, (int)i.ReorderQty, i.UOM, i.Discontinued, (int)i.UnitsOnOrder, (int)i.BufferStockLevel);
                wcfList.Add(w);
            }
            return wcfList;
        }

        // Retrieving the relevant aggregated by dept list for inventory retrieval
        public List<WCF_TempInventoryRetrieval> GetRelevantListByDept(string itemID)
        {
            var temp = InventoryLogic.RetrieveTempInventoryList(itemID);
            List<WCF_TempInventoryRetrieval> wcfList = new List<WCF_TempInventoryRetrieval>();
            foreach (var i in temp)
            {
                WCF_TempInventoryRetrieval w = WCF_TempInventoryRetrieval.Create(i.RequestID, i.RequestDetailID, i.ItemID, i.DepartmentID, i.RequestedQty, i.ActualQty, i.IsOverride);
                wcfList.Add(w);
            }
            return wcfList;
        }































































        //Chang Siang will write here. Organisation is a mess!
        bool IsAuthanticateUser(string tokenString)
        {
            bool isValidUser = true;
            char seperator = '/';
            try
            {
                //Took this scrambler and descrambler from StackOverflow by lokusking https://stackoverflow.com/questions/38816004/simple-string-encryption-without-dependencies/38816208#38816208?newreg=466b51f08cc74759835ead8063afb961
                int shft = 5;
                string decrypted = Encoding.UTF8.GetString(Convert.FromBase64String(tokenString)).Select(ch => ((int)ch) >> shft).Aggregate("", (current, val) => current + (char)(val / 2));
                string[] splitString = decrypted.Split(seperator);
                UserIdentity user = new UserIdentity();
                string userName = splitString[0];
                string password = splitString[1];
                if (Membership.ValidateUser(userName, password))
                    return isValidUser;
            }
            //If user attempt to temper the encoded string, it will cause an exception thrown during the decoding process at System.Convert.FromBase64_Decode.
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            isValidUser = false;
            return isValidUser;

        }














































        //Khiar Codes






































































































































































        //Naing
        public WCF_Department GetDeptName(string deptid)
        {
            string deptname = RequisitionLogic.GetDepartmentName(deptid);
            WCF_Department wcf_dept= new WCF_Department();
            wcf_dept.DeptID = deptid;
            wcf_dept.DepartmentName = deptname;
            return wcf_dept;
        }










    }
}
