

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///Note: Không sửa lại nội dung này của file này
///</summary>

using Shared.All.Common.Abstractions.v5;
using NganHangCauHoi.Service.Interfaces;
using NganHangCauHoi.Service.DataContext;
using NganHangCauHoi.Service.WrapServices.Interfaces;
using System;

namespace NganHangCauHoi.Service
{
    public partial class WorkflowPermissionService : BaseServiceEF<NganHangCauHoiDataContext, WorkflowPermission>, IWorkflowPermissionService
	{
	}
}