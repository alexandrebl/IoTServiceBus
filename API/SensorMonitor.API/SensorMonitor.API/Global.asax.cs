using Microsoft.Practices.Unity;
using SensorMonitor.API.Library.Utility;
using SensorMonitor.Core.Manager;
using SensorMonitor.Core.Manager.Interface;
using SensorMonitor.Core.Process;
using SensorMonitor.Core.Process.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SensorMonitor.API {
    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            this.RegisterInterfaces();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterInterfaces() {
            IUnityContainer unityContainer = IoCUtility.GetInstance();

            unityContainer.RegisterType(typeof(IProcessMsg), typeof(ProcessMsg));
            unityContainer.RegisterType(typeof(IManagerMsg), typeof(ManagerMsg));
        }
    }
}
