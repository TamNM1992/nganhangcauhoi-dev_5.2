

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///Note: Không sửa lại nội dung này của file này
///</summary>
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NganHangCauHoi.Repo.DataContext.Configs;

namespace NganHangCauHoi.Repo.DataContext 
{
    public static class DependencyInjectionDataContextExtension
    {
        public static void DependencyInjectionDataContext(
            this IServiceCollection services, 
            IConfiguration configuration, 
            string connectionString)
        {
            services.AddDbContext<NganHangCauHoiDataContext>(options => 
            {
                options.UseSqlServer(connectionString);
            });
                DIAdditionalDataContext.AddDI(services, configuration, connectionString);
        }
    }
}
