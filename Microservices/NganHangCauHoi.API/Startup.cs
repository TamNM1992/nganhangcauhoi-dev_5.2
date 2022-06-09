

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///</summary>
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared.All.Startup;
using System;
using System.Threading.Tasks;
using NganHangCauHoi.Service.DataContext;
using NganHangCauHoi.Service.Configs;

namespace NganHangCauHoi.API
{
    public class Startup : BaseStartup<NganHangCauHoiDataContext>
    {
        public Startup(IConfiguration configuration) : base(configuration) { }

        protected override void AddCustomService(
            IServiceCollection services)
        {
            services.DependencyInjectionServices(Configuration);
            base.AddCustomService(services);
        }

        protected override void UseCustomService(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IHostApplicationLifetime applicationLifetime, 
            ILoggerFactory loggerFactory)
        {

            base.UseCustomService(app, env, applicationLifetime, loggerFactory);
        }

        protected override Task OnApplicationStarted(
            IServiceProvider serviceProvider)
        {
            return base.OnApplicationStarted(serviceProvider);
        }

        protected override Task OnApplicationStopping(
            IServiceProvider serviceProvider)
        {
            return base.OnApplicationStopping(serviceProvider);
        }
    }
}





