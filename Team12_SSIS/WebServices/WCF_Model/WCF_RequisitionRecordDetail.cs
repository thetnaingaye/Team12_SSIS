using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_RequisitionRecordDetail
    {
        public static WCF_RequisitionRecordDetail Create(int requestDetailid, int requestId, string itemId, 
            int requestQty, string status)
        {
            WCF_RequisitionRecordDetail r = new WCF_RequisitionRecordDetail();
            r.RequestDetailID = requestDetailid;
            r.RequestID = r.RequestID;
            r.ItemID = itemId;
            r.RequestedQuantity = requestQty;
            r.Status = status;

            return r;
        }

        [DataMember]
        public int RequestDetailID { get; set; }
        [DataMember]
        public int RequestID { get; set; }
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public int RequestedQuantity { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public virtual WCF_InventoryCatalogue WCF_InventoryCatalogue { get; set; }
        [DataMember]
        public virtual WCF_RequisitionRecord WCF_RequisitionRecord { get; set; }

    }
}