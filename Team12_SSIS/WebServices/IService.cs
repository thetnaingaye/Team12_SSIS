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
    [ServiceKnownType(typeof(DisbursementListDetail))]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/DLists", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_DisbursementList> GetDisbursementList();

        [OperationContract]
        [WebGet(UriTemplate = "/GetUsersFromDept/{dept}", ResponseFormat = WebMessageFormat.Json)]
        List<string> GetUsersFromDept(string dept);

        [OperationContract]
        [WebGet(UriTemplate = "/GetInventoryList", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_InventoryCatalogue> GetInventoryList();

        [OperationContract]
        [WebGet(UriTemplate = "/GetInventoryList/{string}", ResponseFormat = WebMessageFormat.Json)]
        
        
    }
}

