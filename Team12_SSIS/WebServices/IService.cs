using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Team12_SSIS.Model;

namespace Team12_SSIS.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/DLists", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_DisbursementList> GetDisbursementList();

        [OperationContract]
        [WebGet(UriTemplate = "/GetUsersFromDept/{dept}", ResponseFormat = WebMessageFormat.Json)]
        List<string> GetUsersFromDept(string dept);


    }

    [DataContract]
    public class WCF_DisbursementList
    {

        //public WCF_DisbursementList(string disbursementId, string departmentId, string collectionpointId, string collectionDate, string repName, string status, List<WCF_DisbursementListDetail> dlistdetails)
        //{
        //    this.DisbursementID = disbursementId;
        //    this.DepartmentID = departmentId;
        //    this.CollectionPointID = collectionpointId;
        //    this.CollectionDate = collectionDate;
        //    this.RepresentativeName = repName;
        //    this.Status = status;
        //    //this.WCF_DisbursementListDetails = dlistdetails;

        //}

        public WCF_DisbursementList(string disbursementId, string departmentId, string collectionpointId, string collectionDate, string repName,string status)
        {
            this.DisbursementID = disbursementId;
            this.DepartmentID = departmentId;
            this.CollectionPointID = collectionpointId;
            this.CollectionDate = collectionDate;
            this.RepresentativeName = repName;
            this.Status = status;
    

        }


        [DataMember]
        public string DisbursementID { get; set; }

        [DataMember]
        public string DepartmentID { get; set; }

        [DataMember]
        public string CollectionPointID { get; set; }

        [DataMember]
        public string CollectionDate { get; set; }

        [DataMember]
        public string RepresentativeName { get; set; }

        [DataMember]
        public string Status { get; set; }

        //[DataMember]
        //public virtual WCF_CollectionPoint CollectionPoint { get; set; }

        //[DataMember]
        //public virtual WCF_Department Department { get; set; }

        //[DataMember]
        //public List<WCF_DisbursementListDetail> WCF_DisbursementListDetails { get; set; }

        //[DataMember]
        //public virtual ICollection<WCF_OutstandingDisbursement> WCF_OutstandingDisbursements { get; set; }
    }


    //[DataContract]
    //public class WCF_CollectionPoint
    //{


    //}


    //[DataContract]
    //public class WCF_Department
    //{

    //}


    [DataContract]
    public class WCF_DisbursementListDetail
    {
        public WCF_DisbursementListDetail(string id,string disbursementId,string itemId,string actualQuantity,string quantityRequested,string quantityCollected,string uom,string remarks)
        {
            this.ID = id;
            this.DisbursementID = disbursementId;
            this.ItemID = itemId;
            this.ActualQuantity = actualQuantity;
            this.QuantityRequested = quantityRequested;
            this.QuantityCollected = quantityCollected;
            this.UOM = uom;
            this.Remarks = remarks;

        }


        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string DisbursementID { get; set; }
        
        [DataMember]
        public string ItemID { get; set; }

        [DataMember]
        public string ActualQuantity { get; set; }

        [DataMember]
        public string QuantityRequested { get; set; }

        [DataMember]
        public string QuantityCollected { get; set; }

        [DataMember]
        public string UOM { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        //[DataMember]
        //public  WCF_DisbursementList DisbursementList { get; set; }

        //[DataMember]
        //public InventoryCatalogue InventoryCatalogue { get; set; }

    }



    //[DataContract]
    //public class WCF_OutstandingDisbursement
    //{

    //}

}
