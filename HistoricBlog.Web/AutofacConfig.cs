using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace HistoricBlog.Web
{
    public class AutofacConfig
    {
        public static void SetUpAutofac()
        {

            var asembly = AppDomain.CurrentDomain.GetAssemblies();

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(asembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterAssemblyTypes(asembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest().PropertiesAutowired();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}