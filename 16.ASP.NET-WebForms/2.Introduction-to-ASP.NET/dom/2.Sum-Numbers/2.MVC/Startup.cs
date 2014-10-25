using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2.MVC.Startup))]
namespace _2.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
