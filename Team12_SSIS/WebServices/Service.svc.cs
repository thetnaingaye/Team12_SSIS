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

        public List<string> GetUsersFromDept(string dept)
        {
            return DisbursementLogic.GetFullNamesFromDept(dept);
        }

        public List<WCF_DisbursementList> GetDisbursementList()
        {
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
                wcfD.WCF_DisbursementListDetail = GetDisbursementListDetails(d.DisbursementID);
                wcf_Dlist.Add(wcfD);
            }
            return wcf_Dlist;
        }

        public List<WCF_DisbursementListDetail> GetDisbursementListDetails(int disbursementId)
        {
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
                wcfDd.QuantityCollected = (int)dd.QuantityCollected;
                wcfDd.UOM = dd.UOM;
                wcfDd.Remarks = dd.Remarks == null ? " " : dd.Remarks;
                wcf_ddlist.Add(wcfDd);
            }
            return wcf_ddlist;

        }

        public List<WCF_InventoryCatalogue> GetInventoryList()
        {
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

        public List<WCF_InventoryCatalogue> SearchInventoryList(string query)
        {
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

        public List<WCF_StockCard> GetStockCard(string itemId)
        {
            InventoryLogic inventoryLogic = new InventoryLogic();
            List<StockCard> stockCard = inventoryLogic.GetStockcardByItemId(itemId);
            List<WCF_StockCard> wcfList = new List<WCF_StockCard>();
            foreach(StockCard i in stockCard)
            {
                WCF_InventoryCatalogue c = SearchInventoryList(i.ItemID).First();
                WCF_StockCard w = WCF_StockCard.Create(i.ID, i.ItemID, 
                    ((DateTime)i.Date).ToString("d"), i.Description, i.Type, 
                    (int)i.Quantity, i.UOM, (int)i.Balance, c);
                wcfList.Add(w);
            }
            return wcfList;
        }

        public List<WCF_RequisitionRecord> GetDeptRequests()
        {
            throw new NotImplementedException(); //Wait for Khair's method
        }

        public List<WCF_RequisitionRecord> GetDeptRequestsById(string deptId)
        {
            throw new NotImplementedException(); //Wait for Khair's method
        }

        public void UpdateDeptRequestStatus(WCF_RequisitionRecord record)
        {
            throw new NotImplementedException(); //wait for Khair's method
        }

        public void UpdateDisbursementStatus(WCF_DisbursementList disbursementList)
        {
            DisbursementLogic.UpdateDisbursementStatus
                (disbursementList.DisbursementID, disbursementList.Status);
        }

        public void CreateInventoryRetrievalList(WCF_InventoryRetrievalList retrievalList)
        {
            throw new NotImplementedException(); //Wait for Khair method
        }

        public void CreateAdjustmentRequest(WCF_AVRequest request)
        {
            InventoryLogic.CreateAdjustmentVoucherRequest(request.RequestedBy, DateTime.Parse(request.DateRequested));
            foreach(WCF_AVRequestDetail i in request.WCF_AVRequestDetails)
            {
                InventoryLogic.CreateAdjustmentVoucherRequestDetails
                    (i.AVRID, i.ItemID, i.Type, i.Quantity, i.UOM, i.Reason, i.UnitPrice);
            }
        }

    }
}
