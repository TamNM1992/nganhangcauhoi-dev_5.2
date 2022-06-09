

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
    public partial class NHCH_MaTranDeThi_ChiTietService : BaseServiceEF<NganHangCauHoiDataContext, NHCH_MaTranDeThi_ChiTiet>, INHCH_MaTranDeThi_ChiTietService
	{
	}
}