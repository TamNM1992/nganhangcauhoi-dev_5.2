
using NganHangCauHoi.Data.Models;
using System;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_DeThiRepos 
	{
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;
        public NHCH_DeThiRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider) 
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;
        }

        public async Task<IMethodResult> UpdateFileDethi(int deThiId, Guid fileId, bool daDuyet)
        {
            var item = (await GetByIdAsync(deThiId)).Data;
            if (daDuyet)
            {
                item.FileApprovedId = fileId;
                item.MarkDirty(nameof(item.FileApprovedId));
            } else
            {
                item.FileId = fileId;
                item.MarkDirty(nameof(item.FileId));
            }
            
            
            return await UpdateAsync(item);
        }

	}
}

     