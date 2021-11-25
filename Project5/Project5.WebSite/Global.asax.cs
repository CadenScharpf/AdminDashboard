using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Project5.WebSite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_End()
        {

        }
        void Session_Start(object sender, EventArgs e)
        {

        }
        void Session_End(object sender, EventArgs e)
        {

        }
        void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        void Application_AuthorizeRequest(object sender, EventArgs e)
        {

        }
        void Application_AcquireRequestState(object sender, EventArgs e)
        {

        }
    }
}