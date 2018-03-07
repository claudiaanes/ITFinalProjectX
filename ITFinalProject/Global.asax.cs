using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static ITFinalProject.Models.ApplicationDbContext;

namespace ITFinalProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Data.Entity.Database.SetInitializer(new MyDataContextDbInitializer());
        }
    }
}
