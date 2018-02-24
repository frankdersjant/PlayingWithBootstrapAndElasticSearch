using DataLayer;
using PlayingWithBootstrap.App_Start;
using PlayingWithBootstrap.Infrastructure;
using StructureMap;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PlayingWithBootstrap
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container
        {
            get { return (IContainer)HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<NotificationContext>(new PWBConfiguration());

            DependencyResolver.SetResolver(new StructureMapDependancyResolver(() => Container ?? IoC.Container));

            MappingConfig.RegisterMaps();

            IoC.Container.Configure(cfg =>
                {
                    cfg.AddRegistry(new StandardRegistry());
                    cfg.AddRegistry(new ControllerRegistry());
                    cfg.AddRegistry(new ActionFilterRegistry(
                    () => Container ?? IoC.Container));
                    cfg.AddRegistry(new MvcRegistry());
                });

            using (var context = new NotificationContext())
            {
                context.Database.Initialize(force: true);
            }

        }

        public void Application_BeginRequest()
        {
            Container = IoC.Container.GetNestedContainer();
        }

        public void Application_EndRequest()
        {
            Container.Dispose();
            Container = null;
        }
    }
}
