using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_AVRequestDetail
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int AVRID { get; set; }


        [DataMember]
        public string ItemID { get; set; }

        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string UOM { get; set; }

        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public double UnitPrice { get; set; }
        [DataMember]
        public virtual WCF_AVRequest AVRequest { get; set; }
        [DataMember]
        public virtual WCF_InventoryCatalogue InventoryCatalogue { get; set; }
    }
}