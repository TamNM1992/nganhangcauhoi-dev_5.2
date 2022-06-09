

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///Note: Không sửa lại nội dung này của file này
///</summary>

using Shared.All.Common.Extensions;
using Shared.All.Clients; 
using NganHangCauHoi.Service.DataContext;
using NganHangCauHoi.Service.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NganHangCauHoi.Service.Configs
{
    public static class DependencyInjectionServiceExtension
    {
        public static void DependencyInjectionServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connStr = configuration.GetServiceSQLConnectionString();
            services.DependencyInjectionDataContext(configuration, connStr);
            services.AddClientAll(configuration);
            services.Scan(scan =>
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithLifetime(ServiceLifetime.Scoped));
            DIAdditionalServices.AddDI(services, configuration);
        }
    }
}