using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices
{
    [DataContract]
    public class WCF_DisbursementListDetail
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int DisbursementID { get; set; }

        [DataMember]
        public string ItemID { get; set; }

        [DataMember]
        public int ActualQuantity { get; set; }

        [DataMember]
        public int QuantityRequested { get; set; }

        [DataMember]
        public int QuantityCollected { get; set; }

        [DataMember]
        public string UOM { get; set; }

        [DataMember]
        public string Remarks { get; set; }

    }

}