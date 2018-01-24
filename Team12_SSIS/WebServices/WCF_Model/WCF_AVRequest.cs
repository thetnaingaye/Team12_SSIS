﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_AVRequest
    {

        public WCF_AVRequest()
        {
            AdjustmentVouchers = new HashSet<WCF_AdjustmentVoucher>();
            AVRequestDetails = new HashSet<WCF_AVRequestDetail>();
        }

        [DataMember]
        public int AVRID { get; set; }

        [DataMember]
        public string RequestedBy { get; set; }
        [DataMember]
        public string DateRequested { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string HandledBy { get; set; }
        [DataMember]
        public string DateProcessed { get; set; }
        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public virtual ICollection<WCF_AdjustmentVoucher> AdjustmentVouchers { get; set; }

        [DataMember]
        public virtual ICollection<WCF_AVRequestDetail> AVRequestDetails { get; set; }
    }
}