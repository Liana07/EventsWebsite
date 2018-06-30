using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsWebsite.Startup))]
namespace EventsWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
