using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

//----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------//

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_TempInventoryRetrieval
    {
        public static WCF_TempInventoryRetrieval Create
            (int requestID, int requestDetailID, string itemID, string departmentID, int requestedQty, int actualQty, bool isOverride)
        {
            WCF_TempInventoryRetrieval t = new WCF_TempInventoryRetrieval();
            t.RequestID = requestID;
            t.RequestDetailID = requestDetailID;
            t.ItemID = itemID;
            t.DepartmentID = departmentID;
            t.RequestedQty = requestedQty;
            t.ActualQty = actualQty;
            t.IsOverride = isOverride;
            return t;
        }

        // Properties
        [DataMember]
        public int RequestID { get; set; }

        [DataMember]
        public int RequestDetailID { get; set; }

        [DataMember]
        public string ItemID { get; set; }

        [DataMember]
        public string DepartmentID { get; set; }

        [DataMember]
        public int RequestedQty { get; set; }

        [DataMember]
        public int ActualQty { get; set; }

        [DataMember]
        public bool IsOverride { get; set; }
    }
}