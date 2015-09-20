using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using Telerik.OpenAccess;
using TestApp.Mailers;
using TestApp.Models;

[assembly: OwinStartupAttribute(typeof(TestApp.Startup))]
namespace TestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(i => i.Namespace == "TestApp.Service")
                .InstancePerRequest();
            builder.RegisterType<EntitiesModel>().As<OpenAccessContext>().InstancePerRequest();
            builder.RegisterType<FileMailer>().As<IFileMailer>();
            var container = builder.Build();
            var dependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(dependencyResolver);
            ConfigureAuth(app);
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
