using System;
using System.Collections.Generic;
using System.Linq;
using HistoricBlog.WebApi.AutofacModule;
using Microsoft.Owin;
using Owin;
using HistoricBlog.AutoMapper.App_Start;

[assembly: OwinStartup(typeof(HistoricBlog.WebApi.Startup))]

namespace HistoricBlog.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.SetUpAutoFacWebApi();
            ConfigureAuth(app);
            
            AutoMapperConfig.SetUpAutoMapper();

        }
    }
}
