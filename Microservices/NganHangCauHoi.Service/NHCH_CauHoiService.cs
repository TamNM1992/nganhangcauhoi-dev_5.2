

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using NganHangCauHoi.Service.DataContext;
using NganHangCauHoi.Service.DataContext.Constants;
using System.Threading.Tasks;
using Shared.All.Common.Models;
using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_CauHoiService 
    {
        public NHCH_CauHoiService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_CauHoiService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_CauHoi item)
        {
            item.MarkDirty<NHCH_CauHoi>(x => new 
            {
                item.Code,
				item.Created,
				item.CreatedBy,
				item.Diem,
				item.Entity,
				item.EntityKey,
				item.IdChuDe,
				item.IdHocPhan,
				item.IdMucDo,
				item.IsBuildIn,
				item.IsBuildInAll,
				item.IsDeleted,
				item.KhaDung,
				item.MaHocPhan,
				item.MaMucDo,
				item.Modified,
				item.ModifiedBy,
				item.NoiDung,
				item.NoiDungRutGon,
				item.ServiceCode,
				item.STTCauHoi,
				item.TinChi,
				item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}