using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bootsrap.Startup))]
namespace Bootsrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
