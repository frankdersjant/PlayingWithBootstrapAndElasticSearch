using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayingWithBootstrap.Startup))]
namespace PlayingWithBootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
