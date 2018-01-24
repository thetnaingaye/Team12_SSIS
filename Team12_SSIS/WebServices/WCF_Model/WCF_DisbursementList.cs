using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Team12_SSIS.Model;

namespace Team12_SSIS.WebServices
{
    [DataContract]
    public class WCF_DisbursementList
    {
        [DataMember]
        public int DisbursementID { get; set; }

        [DataMember]
        public string DepartmentID { get; set; }

        [DataMember]
        public int CollectionPointID { get; set; }

        [DataMember]
        public string CollectionDate { get; set; }

        [DataMember]
        public string RepresentativeName { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public List<WCF_DisbursementListDetail> WCF_DisbursementListDetail { get; set; }
    }

}