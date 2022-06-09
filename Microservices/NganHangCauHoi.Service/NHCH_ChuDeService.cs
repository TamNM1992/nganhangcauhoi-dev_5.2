

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
    public partial class NHCH_ChuDeService 
    {
        public NHCH_ChuDeService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_ChuDeService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_ChuDe item)
        {
            item.MarkDirty<NHCH_ChuDe>(x => new 
            {
                item.Code,
				item.Created,
				item.CreatedBy,
				item.Entity,
				item.EntityKey,
				item.IdHocPhan,
				item.IdMucDo,
				item.IsBuildIn,
				item.IsBuildInAll,
				item.IsDeleted,
				item.MaHocPhan,
				item.Modified,
				item.ModifiedBy,
				item.MoTa,
				item.MucDo,
				item.ServiceCode,
				item.Ten,
				item.ThuTu,
				item.TinChi,
				item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}