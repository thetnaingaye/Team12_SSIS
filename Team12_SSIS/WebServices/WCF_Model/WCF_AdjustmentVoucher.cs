using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_AdjustmentVoucher
    {
        [DataMember]
        public int AVID { get; set; }
        [DataMember]
        public int AVRID { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public virtual WCF_AVRequest AVRequest { get; set; }
    }
}