

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///</summary>
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
//using Shared.All.Startup;
namespace NganHangCauHoi.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await StartupExtensions.CreateMain<Startup>(args);
        }
    //    public static void Main(string[] args)
    //    {
    //        CreateHostBuilder(args).Build().Run();
    //    }

    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
    //        Host.CreateDefaultBuilder(args)
    //            .ConfigureWebHostDefaults(webBuilder =>
    //            {
    //                webBuilder.UseStartup<Startup>();
    //            });
    }
}
