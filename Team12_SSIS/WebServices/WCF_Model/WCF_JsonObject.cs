using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team12_SSIS.WebServices.WCF_Model
{
    [DataContract]
    public class WCF_JsonObject
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public string itemId { get; set; }
        [DataMember]
        public string query { get; set; }
        [DataMember]
        public string dept { get; set; }
    }
}