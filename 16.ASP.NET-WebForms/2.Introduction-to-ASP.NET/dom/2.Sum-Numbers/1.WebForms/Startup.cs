using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1.WebForms.Startup))]
namespace _1.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
