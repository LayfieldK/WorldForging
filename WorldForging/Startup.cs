using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldForging.Startup))]
namespace WorldForging
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
