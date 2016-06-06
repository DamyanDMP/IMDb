using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMDb3._0.Startup))]
namespace IMDb3._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
