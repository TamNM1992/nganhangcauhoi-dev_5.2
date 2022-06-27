

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NganHangCauHoi.Repositorys.Configs;
using NganHangCauHoi.Repositorys.Generated.Interfaces;
using NganHangCauHoi.Repositorys.Interfaces;

namespace NganHangCauHoi.Repositorys.Generated.Configs
{

    public static class DependencyInjectionRepositoryExtension
    {

        public static void DependencyInjectionRepository(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.DepedencyInjectionDatacontext(configuration, connectionString);
            DIAdditionalRepos.AddDI(services, configuration, connectionString);

            services.AddScoped<INHCH_BoCauHoiRepos, NHCH_BoCauHoiRepos>();
            services.AddScoped<INHCH_BoCauHoi_CauHoiRepos, NHCH_BoCauHoi_CauHoiRepos>();
            services.AddScoped<INHCH_CauHoiRepos, NHCH_CauHoiRepos>();
            services.AddScoped<INHCH_CauHoi_CloRepos, NHCH_CauHoi_CloRepos>();
            services.AddScoped<INHCH_ChuDeRepos, NHCH_ChuDeRepos>();
            services.AddScoped<INHCH_ChuDe_MucTieuRepos, NHCH_ChuDe_MucTieuRepos>();
            services.AddScoped<INHCH_CloRepos, NHCH_CloRepos>();
            services.AddScoped<INHCH_DeThiRepos, NHCH_DeThiRepos>();
            services.AddScoped<INHCH_DeThi_ChiTietRepos, NHCH_DeThi_ChiTietRepos>();
            services.AddScoped<INHCH_MaTranDeThiRepos, NHCH_MaTranDeThiRepos>();
            services.AddScoped<INHCH_MaTranDeThi_ChiTietRepos, NHCH_MaTranDeThi_ChiTietRepos>();
            services.AddScoped<INHCH_MucDoRepos, NHCH_MucDoRepos>();
            services.AddScoped<INHCH_MucTieuRepos, NHCH_MucTieuRepos>();
            services.AddScoped<INHCH_MucTieu_CloRepos, NHCH_MucTieu_CloRepos>();
        }
    }
}

