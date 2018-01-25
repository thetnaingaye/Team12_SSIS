using System;
using System.Web.Routing;
using System.Collections.Generic;
using Microsoft.ApplicationServer.Http.Activation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Team12_SSIS.App_Start.WebApi), "Start")]

namespace Team12_SSIS.App_Start {
    public static class WebApi {
        public static void Start() {
            // TODO: change "MyModel" to desired route segment
            RouteTable.Routes.MapServiceRoute<Team12_SSIS.Resources.MyModelResource>("MyModel");
        }
    }
}