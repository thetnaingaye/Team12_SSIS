using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Team12_SSIS.Model;
using Team12_SSIS.WebServices.WCF_Model;

namespace Team12_SSIS.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetDisbursementLists", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_DisbursementList> GetDisbursementList();

        [OperationContract]
        [WebGet(UriTemplate = "/GetUsersFromDept/{dept}", ResponseFormat = WebMessageFormat.Json)]
        List<string> GetUsersFromDept(string dept);

        [OperationContract]
        [WebGet(UriTemplate = "/GetInventoryList", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_InventoryCatalogue> GetInventoryList();

        [OperationContract]
        [WebGet(UriTemplate = "/SearchInventoryList/{query}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_InventoryCatalogue> SearchInventoryList(string query);

        [OperationContract]
        [WebGet(UriTemplate = "/GetStockCard/{itemID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_StockCard> GetStockCard(string itemId);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDeptRequests/", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_RequisitionRecord> GetDeptRequests();

        [OperationContract]
        [WebGet(UriTemplate = "/GetDeptRequestsById/{deptId}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_RequisitionRecord> GetDeptRequestsById(string deptId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateDeptRequest", Method = "POST",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void UpdateDeptRequestStatus(WCF_RequisitionRecord record);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateDisburse", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateDisbursementStatus(WCF_DisbursementList disbursementList);

        [OperationContract]
        [WebInvoke(UriTemplate = "/CreateRetrievalList", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void CreateInventoryRetrievalList(WCF_InventoryRetrievalList retrievalList);
        [OperationContract]
        [WebInvoke(UriTemplate = "/CreateAVRequest", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void CreateAdjustmentRequest(WCF_AVRequest request);
    }
}

