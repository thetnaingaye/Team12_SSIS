using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Web;

namespace Team12_SSIS.WebServices
{
    [DataContract]
    public class UserIdentity : IIdentity
    {
        [DataMember]
        public string Name
        { get; set; }
        
        [DataMember]
        public string AuthenticationType
        { get; set; }

        [DataMember]
        public bool IsAuthenticated
        { get; set; }

        [DataMember]
        public string userName
        { get; set; }
        [DataMember]
        public string userRole
        {
            get; set;
        }
        [DataMember]
        public string password
        { get; set; }
    }
}