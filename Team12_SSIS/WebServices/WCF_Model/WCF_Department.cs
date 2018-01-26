using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_Department
    {
        [DataMember]
        public string DeptID { get; set; }

        [DataMember]
        public string DepartmentName { get; set; }
    }
}