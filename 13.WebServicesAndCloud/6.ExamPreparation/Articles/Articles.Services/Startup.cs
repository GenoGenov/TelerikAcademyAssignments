using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Articles.Services.Startup))]

namespace Articles.Services
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;

    using Articles.Data;

    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);

        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IArticlesData>().To<ArticlesData>();
            kernel.Bind<DbContext>().To<ArticlesDbContext>();
            return kernel;
        }
    }
}
