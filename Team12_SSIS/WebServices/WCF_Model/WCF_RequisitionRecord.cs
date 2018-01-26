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

        public static WCF_RequisitionRecord Create(int requestId, string requestDate, 
            string departmentId, string requestorName, string approvedDate, string approverName,
            string remarks)
        {
            WCF_RequisitionRecord r = new WCF_RequisitionRecord();
            r.RequestID = requestId;
            r.RequestDate = requestDate;
            r.DepartmentID = departmentId;
            r.RequestorName = requestorName;
            r.ApprovedDate = approvedDate;
            r.ApproverName = approverName;
            r.Remarks = remarks;
            return r;
        }

        public static WCF_RequisitionRecord Create(int requestId, string requestDate,
    string departmentId, string requestorName, string approvedDate, string approverName,
    string remarks, List<WCF_RequisitionRecordDetail> requestDetails)
        {
            WCF_RequisitionRecord r = new WCF_RequisitionRecord();
            r.RequestID = requestId;
            r.RequestDate = requestDate;
            r.DepartmentID = departmentId;
            r.RequestorName = requestorName;
            r.ApprovedDate = approvedDate;
            r.ApproverName = approverName;
            r.Remarks = remarks;
            r.WCF_RequisitionRecordDetails = requestDetails;
            return r;
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
        public virtual ICollection<WCF_RequisitionRecordDetail> WCF_RequisitionRecordDetails { get; set; }

    }
}