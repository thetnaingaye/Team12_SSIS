using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_RequisitionRecord
    {
        
        public WCF_RequisitionRecord()
        {
            WCF_RequisitionRecordDetails = new HashSet<WCF_RequisitionRecordDetail>();
        }

        [DataMember]
        public int RequestID { get; set; }
        [DataMember]
        public string RequestDate { get; set; }
        [DataMember]
        public string DepartmentID { get; set; }
        [DataMember]
        public string RequestorName { get; set; }
        [DataMember]
        public string ApprovedDate { get; set; }
        [DataMember]
        public string ApproverName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
        [DataMember]
        public virtual ICollection<WCF_RequisitionRecordDetail> WCF_RequisitionRecordDetails { get; set; }

    }
}