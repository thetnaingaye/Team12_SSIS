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
        [WebInvoke(UriTemplate = "/GetDisbursementLists", Method ="POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<WCF_DisbursementList> GetDisbursementList(string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetUsersFromDept", Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<string> GetUsersFromDept(string dept, string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetInventoryList", Method ="POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<WCF_InventoryCatalogue> GetInventoryList(string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/SearchInventoryList", Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<WCF_InventoryCatalogue> SearchInventoryList(string query, string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetStockCard", Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<WCF_StockCard> GetStockCard(string itemId, string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetAllRequestsList", Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<WCF_RequisitionRecord> GetStationeryRequests(string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetRequestsList", Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<WCF_RequisitionRecord> GetStationeryRequestsById(string deptId, string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateRequestStatus", Method = "POST",
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        void UpdateStationeryRequestStatus(WCF_RequisitionRecord record, string status, string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetRequestListDetails/{requestId}", Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<WCF_RequisitionRecordDetail> GetStationeryRequestDetails(string requestId, string token);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateDisburse", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        void UpdateDisbursementStatus(WCF_DisbursementList disbursementList, WCF_JsonObject jsonWrapper);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "/CreateRetrievalList", Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json)]
        //void CreateInventoryRetrievalList(WCF_InventoryRetrievalList retrievalList);
        [OperationContract]
        [WebInvoke(UriTemplate = "/CreateAVRequest", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        void CreateAdjustmentRequest(WCF_AVRequest request, string token);



        // ------------------   From Khair with Love ~   ---------------------//

        // Retrieving total quantity needed on a per item basis necessary for inventory retrieval
        [OperationContract]
        [WebGet(UriTemplate = "/GetTotalQtyNeeded/{itemID}", ResponseFormat = WebMessageFormat.Json)]
        int RetrieveTotalQtyNeeded(string itemID);

        // Retrieving the relevant item list for inventory retrieval
        [OperationContract]
        [WebGet(UriTemplate = "/GetRelevantItemList", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_InventoryCatalogue> GetRelevantItemList();

        // Retrieving the relevant aggregated by dept list for inventory retrieval
        [OperationContract]
        [WebGet(UriTemplate = "/GetRelevantListByDept/{itemID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_TempInventoryRetrieval> GetRelevantListByDept(string itemID);















































































































        //Naing
        [OperationContract]
        [WebGet(UriTemplate = "/GetDeptName/{deptid}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Department GetDeptName(string deptid);





























    }
}

