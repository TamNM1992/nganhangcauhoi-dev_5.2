


using NganHangCauHoi.Data.Models;
using System;
using System.Threading.Tasks;
///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>
namespace NganHangCauHoi.Service.Interfaces
{
    public partial interface INHCH_BoCauHoiService
    {
        public override async Task<IMethodResult<int>> InsertAsync(NHCH_BoCauHoi item);
        public override async Task<IMethodResult> UpdateAsync(NHCH_BoCauHoi item);
        public override async Task<IMethodResult> DeleteAsync(int id);
        public override async Task<IMethodResult> DeleteManyByIdsAsync(int[] ids);
        public override async Task<IMethodResult<NHCH_BoCauHoi>> GetByIdAsync(int id);
        public async Task<IMethodResult<object>> ExportFileCauHoi(int idBoCauHoi);
    }
}