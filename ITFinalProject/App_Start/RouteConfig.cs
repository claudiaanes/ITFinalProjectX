using System.Web.Mvc;
using System.Web.Routing;

namespace ITFinalProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Clientes",
                url: "Clientes/{id}",
                defaults: new { controller = "Clientes", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DetalhesCliente",
                url: "DetalhesCliente/{id}",
                defaults: new { controller = "Clientes", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
