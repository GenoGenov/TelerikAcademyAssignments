using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2.DisplayAssemblyLocation.Startup))]
namespace _2.DisplayAssemblyLocation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
