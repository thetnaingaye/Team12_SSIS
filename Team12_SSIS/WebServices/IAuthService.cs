//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Team12_SSIS.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthService" in both code and config file together.
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/Login", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Login(UserIdentity user);
    }
}
