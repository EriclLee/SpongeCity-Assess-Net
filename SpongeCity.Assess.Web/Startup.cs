using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpongeCity.Assess.Web.Startup))]
namespace SpongeCity.Assess.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
