

using System;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys.Interfaces
{
    public partial interface INHCH_DeThiRepos
    {
        Task<IMethodResult> UpdateFileDethi(int deThiId, Guid fileId, bool daDuyet);
    }
}

    