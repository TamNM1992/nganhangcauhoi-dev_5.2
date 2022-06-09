

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///</summary>
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NganHangCauHoi.Repo.DataContext.Configs
{
    public static class DIAdditionalDataContext
    {
        public static void AddDI(
            IServiceCollection services, 
            IConfiguration configuration, 
            string connectionString)
        {
        }
    }
}
