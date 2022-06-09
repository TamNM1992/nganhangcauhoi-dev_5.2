

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///</summary>
using System;
using System.Threading.Tasks;
using Shared.All.Startup;
namespace NganHangCauHoi.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await StartupExtensions.CreateMain<Startup>(args);
        }
    }
}
