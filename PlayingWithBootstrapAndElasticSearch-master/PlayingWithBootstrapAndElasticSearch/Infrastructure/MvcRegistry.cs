using DataLayer;
using ElasticsearchService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap;
using System.Data.Entity;
using System.Security.Principal;
using System.Web;

namespace PlayingWithBootstrap.Infrastructure
{
    public class MvcRegistry : Registry
    {
        public MvcRegistry()
        {
            For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
            For<DbContext>().Use<NotificationContext>(new NotificationContext());
            For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
            For<IIdentity>().Use(() => HttpContext.Current.User.Identity);
            For<ICurrentUser>().Use<CurrentUser>();
            For<IElasticSearchService>().Use<ElasticSearchService>();
        }
    }
}