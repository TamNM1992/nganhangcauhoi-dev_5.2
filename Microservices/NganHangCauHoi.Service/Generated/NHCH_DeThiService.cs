

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///Note: Không sửa lại nội dung này của file này
///</summary>

using Shared.All.Common.Abstractions.v5;
using NganHangCauHoi.Service.Interfaces;
using NganHangCauHoi.Service.DataContext;
using NganHangCauHoi.Service.WrapServices.Interfaces;
using System;		

namespace NganHangCauHoi.Service
{
    public partial class NHCH_DeThiService : BaseServiceEF<NganHangCauHoiDataContext, NHCH_DeThi>, INHCH_DeThiService
	{
	}
}