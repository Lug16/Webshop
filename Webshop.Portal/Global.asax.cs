using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Webshop.Kernel;
using Webshop.Portal.Storage;

namespace Webshop.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly Injector injector = new Injector(new Repository.EntityFramework.Model(), new TempDataDictionary());

        public static IUnitOfWork CurrentUnitOfWork { get; internal set; }

        public static string CurrentStorageType { get; internal set; }

        public MvcApplication()
        {
            ChangeUnitOfWork("Database");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void ChangeUnitOfWork(string key)
        {
            CurrentUnitOfWork = injector.ContextDictionary[key];
            CurrentStorageType = key;
        }
    }
}
