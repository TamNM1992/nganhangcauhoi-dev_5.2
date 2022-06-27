

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
//using Shared.All.Startup;
using System;
using System.Threading.Tasks;
using NganHangCauHoi.Service.Configs;
using NganHangCauHoi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NganHangCauHoi.API
{
    public class Startup : BaseStartup<NganHangCauHoiDataContext>
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) //: base(configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MT.WebAPI", Version = "v1" });
            //});

            services.Configure<MAJOR_CORE_VERSION>(Configuration.GetSection("MAJOR_CORE_VERSION"));


            string connectionString = Configuration.GetConnectionString("NganHangCauHoiDataContext");
            services.AddDbContext<NganHangCauHoiDataContext>(options =>
           options.UseSqlServer(connectionString));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
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





