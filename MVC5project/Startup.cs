using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5project.Startup))]
namespace MVC5project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
