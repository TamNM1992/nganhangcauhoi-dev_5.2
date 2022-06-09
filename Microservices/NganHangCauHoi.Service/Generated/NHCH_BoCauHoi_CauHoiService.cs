

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
    public partial class NHCH_BoCauHoi_CauHoiService : BaseServiceEF<NganHangCauHoiDataContext, NHCH_BoCauHoi_CauHoi>, INHCH_BoCauHoi_CauHoiService
	{
	}
}