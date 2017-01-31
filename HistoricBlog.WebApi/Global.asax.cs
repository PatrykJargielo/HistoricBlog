using HistoricBlog.WebApi.AutofacModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http.Cors;
using System.Web.Services.Description;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.DependencyInjection;

namespace HistoricBlog.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.SetUpAutofacMvc();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        //    {
        //        builder.AllowAnyOrigin()
        //               .AllowAnyMethod()
        //               .AllowAnyHeader();
        //    }));
        //}
    }
}
