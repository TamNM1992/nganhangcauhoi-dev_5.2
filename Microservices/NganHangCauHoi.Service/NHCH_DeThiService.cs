

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using CamlBuilder;
using Microsoft.AspNetCore.Http.Internal;
//using Shared.All.Common.Models;
//using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SharePoint.Client.Search.Query;
using Newtonsoft.Json.Linq;
using NganHangCauHoi.Data.CustomModels;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_DeThiService 
    {
        public NHCH_DeThiService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) //: base(dataContext, serviceProvider)
        {

        }

        protected NHCH_DeThiService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}

        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly IUserPrincipalService _userPrincipalService;
        private readonly INHCH_DeThi_ChiTietRepos _tbl_NHCH_DeThi_ChiTietRepos;
        private readonly ITemplateClientService _templateClientService;
        private readonly INHCH_CauHoiRepos _tbl_NHCH_CauHoiRepos;
        private readonly INHCH_CauHoi_CloRepos _tbl_NHCH_CauHoi_CloRepos;
        private readonly INHCH_MaTranDeThiRepos _tbl_NHCH_MaTranDeThiRepos;
        private readonly Itbl_HocPhanServiceSdk _tbl_HocPhanServiceSdk;
        private readonly Itbl_DM_Chung_DonViServiceSdk _tbl_DM_Chung_DonViServiceSdk;
        private readonly Itbl_CANBO_HoSoServiceSdk _tbl_CANBO_HoSoServiceSdk;
        private readonly INHCH_DeThiRepos _tbl_NHCH_DeThiRepos;
        private readonly Itbl_DM_NguoiHoc_HeDaoTaoServiceSdk _tbl_DM_NguoiHoc_HeDaoTaoServiceSdk;
        private readonly Itbl_Thi_DotThiServiceSdk _tbl_Thi_DotThiServiceSdk;
        private readonly Itbl_Thi_CaThiServiceSdk _tbl_Thi_CaThiServiceSdk;
        private readonly Itbl_Thi_XepLichMonServiceSdk _tbl_Thi_XepLichMonServiceSdk;
        private readonly Itbl_Thi_XepLichLopHocPhanServiceSdk _tbl_Thi_XepLichLopHocPhanServiceSdk;
        private readonly IOrganizationManagementClientService _organizationManagementClientService;
        private readonly IConfiguration _configuration;
        private readonly INotificationClientService _notificationClientService;
        private readonly INHCH_BoCauHoi_CauHoiRepos _tbl_NHCH_BoCauHoi_CauHoiRepos;
        private readonly Itbl_HeThong_NamHocServiceSdk _tbl_HeThong_NamHocServiceSdk;
        private readonly IFileClientService _fileClientService;

        private readonly INHCH_DeThiRepos _repos;

        public NHCH_DeThiService(
            INHCH_DeThiRepos repos,
            IServiceProvider serviceProvider,
            IEntityChangedEventService entityChangedEventService,
            IUserPrincipalService userPrincipalService,
            INHCH_DeThi_ChiTietRepos tbl_NHCH_DeThi_ChiTietRepos,
            ITemplateClientService templateClientService,
            INHCH_CauHoiRepos tbl_NHCH_CauHoiRepos,
            INHCH_CauHoi_CloRepos tbl_NHCH_CauHoi_CloRepos,
            INHCH_MaTranDeThiRepos tbl_NHCH_MaTranDeThiRepos,
            Itbl_HocPhanServiceSdk tbl_HocPhanServiceSdk,
            Itbl_DM_Chung_DonViServiceSdk tbl_DM_Chung_DonViServiceSdk,
            Itbl_CANBO_HoSoServiceSdk tbl_CANBO_HoSoServiceSdk,
            Itbl_DM_NguoiHoc_HeDaoTaoServiceSdk tbl_DM_NguoiHoc_HeDaoTaoServiceSdk,
            Itbl_Thi_DotThiServiceSdk tbl_Thi_DotThiServiceSdk,
            Itbl_Thi_CaThiServiceSdk tbl_Thi_CaThiServiceSdk,
            Itbl_Thi_XepLichMonServiceSdk tbl_Thi_XepLichMonServiceSdk,
            Itbl_Thi_XepLichLopHocPhanServiceSdk tbl_Thi_XepLichLopHocPhanServiceSdk,
            IOrganizationManagementClientService organizationManagementClientService,
            IConfiguration configuration,
            INotificationClientService notificationClientService,
            Itbl_HeThong_NamHocServiceSdk tbl_HeThong_NamHocServiceSdk,
            INHCH_BoCauHoi_CauHoiRepos tbl_NHCH_BoCauHoi_CauHoiRepos,
            IFileClientService fileClientService
            )
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
            _userPrincipalService = userPrincipalService;
            _tbl_NHCH_DeThi_ChiTietRepos = tbl_NHCH_DeThi_ChiTietRepos;
            _templateClientService = templateClientService;
            _tbl_NHCH_CauHoiRepos = tbl_NHCH_CauHoiRepos;
            _tbl_NHCH_CauHoi_CloRepos = tbl_NHCH_CauHoi_CloRepos;
            _tbl_NHCH_MaTranDeThiRepos = tbl_NHCH_MaTranDeThiRepos;
            _tbl_HocPhanServiceSdk = tbl_HocPhanServiceSdk;
            _tbl_DM_Chung_DonViServiceSdk = tbl_DM_Chung_DonViServiceSdk;
            _tbl_CANBO_HoSoServiceSdk = tbl_CANBO_HoSoServiceSdk;
            _tbl_NHCH_DeThiRepos = repos;
            _tbl_DM_NguoiHoc_HeDaoTaoServiceSdk = tbl_DM_NguoiHoc_HeDaoTaoServiceSdk;
            _tbl_Thi_DotThiServiceSdk = tbl_Thi_DotThiServiceSdk;
            _tbl_Thi_CaThiServiceSdk = tbl_Thi_CaThiServiceSdk;
            _tbl_Thi_XepLichMonServiceSdk = tbl_Thi_XepLichMonServiceSdk;
            _tbl_Thi_XepLichLopHocPhanServiceSdk = tbl_Thi_XepLichLopHocPhanServiceSdk;
            _organizationManagementClientService = organizationManagementClientService;
            _configuration = configuration;
            _notificationClientService = notificationClientService;
            _tbl_HeThong_NamHocServiceSdk = tbl_HeThong_NamHocServiceSdk;
            _tbl_NHCH_BoCauHoi_CauHoiRepos = tbl_NHCH_BoCauHoi_CauHoiRepos;
            _fileClientService = fileClientService;
        }

        public override async Task<IMethodResult<NHCH_DeThi>> GetByIdAsync(int id)
        {
            var item = await _repos.GetAllLazy().Where(p => p.Id == id)
                .Include(p => p.NHCH_DeThi_ChiTiets)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                if (item.tbl_NHCH_DeThi_ChiTiet.Any())
                {
                    item.tbl_NHCH_DeThi_ChiTiet = item.NHCH_DeThi_ChiTiets.OrderBy(x => x.ThuTu).ToList();
                    foreach (var chiTiet in item.tbl_NHCH_DeThi_ChiTiet)
                    {
                        var cauHoiQuery = _tbl_NHCH_CauHoiRepos.GetAllLazy().Where(x => x.Id == chiTiet.IdCauHoi).Select(item => new NHCH_CauHoi
                        {
                            Id = item.Id,
                            InstanceId = item.InstanceId,
                            Code = item.Code,
                            NoiDungRutGon = item.NoiDungRutGon,
                            NoiDung = item.NoiDung,
                            Diem = item.Diem,
                            NHCH_CauHoi_Clos = item.NHCH_CauHoi_Clos,
                            IdMaTranDeThiChiTiet = chiTiet.IdMaTranDeThiChiTiet.Value
                        });
                        var cauHoi = await cauHoiQuery.FirstOrDefaultAsync();

                        if (cauHoi != null)
                        {
                            chiTiet.IdCauHoi = cauHoi.Id;
                            chiTiet.InstanceIdCauHoi = cauHoi.InstanceId;
                            chiTiet.MaCauHoi = cauHoi.Code;
                            chiTiet.NoiDungRutGon = cauHoi.NoiDungRutGon;
                            chiTiet.NoiDung = cauHoi.NoiDung;
                            if (cauHoi.NHCH_CauHoi_Clos.Any())
                            {
                                chiTiet.DanhSachClo = String.Join(", ", cauHoi.NHCH_CauHoi_Clos.Select(x => x.MaClo).ToList());
                            }
                            chiTiet.IdMaTranDeThiChiTiet = cauHoi.IdMaTranDeThiChiTiet;
                            chiTiet.IdDeThi = item.Id;
                        }
                    }
                }
            }

            return MethodResult<NHCH_DeThi>.ResultWithData(item);
        }

        public async Task<IMethodResult<NHCH_DeThi>> GetByIdFullAsync(int id)
        {
            var item = await _repos.GetAllLazy().Where(p => p.Id == id)
                .Include(p => p.NHCH_DeThi_ChiTiets)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                if (item.NHCH_DeThi_ChiTiets.Any())
                {
                    item.tbl_NHCH_DeThi_ChiTiet = item.NHCH_DeThi_ChiTiets.OrderBy(x => x.ThuTu).ToList();
                    foreach (var chiTiet in item.tbl_NHCH_DeThi_ChiTiet)
                    {
                        var cauHoiQuery = _tbl_NHCH_CauHoiRepos.GetAllLazy().Where(x => x.Id == chiTiet.IdCauHoi).Select(item => new NHCH_CauHoi
                        {
                            Id = item.Id,
                            InstanceId = item.InstanceId,
                            Code = item.Code,
                            NoiDungRutGon = item.NoiDungRutGon,
                            NoiDung = item.NoiDung,
                            Diem = item.Diem,
                            NHCH_CauHoi_Clos = item.tbl_NHCH_CauHoi_Clos,
                            IdMaTranDeThiChiTiet = chiTiet.IdMaTranDeThiChiTiet.Value
                        });
                        var cauHoi = await cauHoiQuery.FirstOrDefaultAsync();

                        if (cauHoi != null)
                        {
                            chiTiet.IdCauHoi = cauHoi.Id;
                            chiTiet.MaCauHoi = cauHoi.Code;
                            chiTiet.NoiDungRutGon = cauHoi.NoiDungRutGon;
                            chiTiet.NoiDung = cauHoi.NoiDung;
                            chiTiet.IdMaTranDeThiChiTiet = cauHoi.IdMaTranDeThiChiTiet;
                        }
                    }
                }
            }

            return MethodResult<NHCH_DeThi>.ResultWithData(item);
        }

        public override async Task<IMethodResult<int>> InsertAsync(NHCH_DeThi item)
        {
            var hocPhanRs = await _tbl_HocPhanServiceSdk.GetByInstanceIdAsync(item.IdHocPhan.Value);
            if (!hocPhanRs.Success || hocPhanRs.Data == null)
            {
                return MethodResult<int>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy thông tin học phần");
            }

            // List mã đề thi đã có trên hệ thống trong cùng ngày tạo
            var lstExistsMaDeThis = await _repos.GetAllLazy()
                                                .Where(x => x.Created.Date == DateTime.UtcNow.Date)
                                                .Select(x => x.Code)
                                                .ToListAsync();

            item.InstanceId = Guid.NewGuid();
            item.Code = await GetMaDeThi(hocPhanRs.Data.Code, DateTime.UtcNow, lstExistsMaDeThis);
            item.Ten = $"Đề thi {hocPhanRs.Data.Ten}";

            var sinhDeThi = await SinhFileDeThi(item, $"{item.Code}.docx");
            if (sinhDeThi.Success && sinhDeThi.Data != Guid.Empty)
            {
                item.FileId = sinhDeThi.Data;
            }

            var result = await base.InsertAsync(item);
            if (result.Success)
            {
                // Upload => tạo đề thi mới
                await UpdateDeThiChiTiet(item);
            }
            return result;
        }

        private async Task UpdateDeThiChiTiet(NHCH_DeThi deThi)
        {
            var lstExistsItems = await _tbl_NHCH_DeThi_ChiTietRepos.GetAllLazy()
                                                                   .Where(x => x.IdDeThi == deThi.Id)
                                                                   .ToListAsync();

            var lstInsert = new List<NHCH_DeThi_ChiTiet>();
            var lstUpdate = new List<NHCH_DeThi_ChiTiet>();
            if (deThi.DeThi_ChiTiets.Count > 0)
            {
                for (int i = 0; i < deThi.DeThi_ChiTiets.Count; i++)
                {
                    var item = deThi.DeThi_ChiTiets[i];
                    var itemExist = lstExistsItems.FirstOrDefault(x => x.IdCauHoi == item.IdCauHoi);
                    if (itemExist == null)
                    {
                        item.IdDeThi = deThi.Id;
                        item.ThuTu = i + 1;
                        lstInsert.Add(item);
                    }
                    else
                    {
                        itemExist.ThuTu = i + 1;
                        lstUpdate.Add(itemExist);
                    }
                }
            }

            if (lstInsert.Count > 0)
            {
                await _tbl_NHCH_DeThi_ChiTietRepos.InsertBulkAsync(lstInsert);
            }

            if (lstUpdate.Count > 0)
            {
                await _tbl_NHCH_DeThi_ChiTietRepos.UpdateBulkAsync(lstUpdate);
            }

            var lstDelete = lstExistsItems.Where(x => !lstUpdate.Select(y => y.Id).Contains(x.Id)).Select(x => x.Id).ToArray();
            if (lstDelete.Length > 0)
            {
                await _tbl_NHCH_DeThi_ChiTietRepos.DeleteManyAsync(lstDelete);
            }
        }

        private async Task<string> GetMaDeThi(string maHocPhan, DateTime created, List<string> lstExistCode)
        {
            var maCanBo = _userPrincipalService.UserName;
            var idCanBo = _userPrincipalService.IdCanBo;
            if (!string.IsNullOrEmpty(idCanBo) && int.TryParse(idCanBo, out int tmpIdCanBo))
            {
                var canBoRs = await _tbl_CANBO_HoSoServiceSdk.GetByIdAsync(tmpIdCanBo);
                if (canBoRs.Success && canBoRs.Data != null)
                {
                    maCanBo = canBoRs.Data.Code;
                }
            }

            var dateStr = TimeExtension.GetStringDateTime(created.AddHours(7), "ddMMyyyy");
            Random generator = new Random();
            var soNgauNhien = generator.Next(0, 999).ToString("D3");
            string tmpCode = $"{maHocPhan}_{dateStr}_{maCanBo}_{soNgauNhien}";

            while (lstExistCode.Contains(tmpCode))
            {
                soNgauNhien = generator.Next(0, 999).ToString("D3");
                tmpCode = $"{maHocPhan}_{dateStr}_{maCanBo}_{soNgauNhien}";
            }

            return tmpCode;
        }

        public override async Task<IMethodResult> UpdateAsync(NHCH_DeThi item)
        {
            item.MarkDirty(nameof(item.IdMaTranDeThi));
            item.MarkDirty(nameof(item.Ten));
            item.MarkDirty(nameof(item.IdHocPhan));
            item.MarkDirty(nameof(item.MaHocPhan));
            item.MarkDirty(nameof(item.IdNamHoc));
            item.MarkDirty(nameof(item.IdHocKy));
            item.MarkDirty(nameof(item.IdDotThi));
            item.MarkDirty(nameof(item.MaDotThi));
            item.MarkDirty(nameof(item.IdCaThi));
            item.MarkDirty(nameof(item.IdToChucThi));
            item.MarkDirty(nameof(item.IdLichThi));
            item.MarkDirty(nameof(item.NgayThi));
            item.MarkDirty(nameof(item.IdBoCauHoi));
            item.MarkDirty(nameof(item.FileId));
            item.MarkDirty(nameof(item.FileApprovedId));
            item.MarkDirty(nameof(item.Modified));
            item.MarkDirty(nameof(item.ModifiedBy));
            item.MarkDirty(nameof(item.Code));
            //item.MarkDirty(nameof(item.IsBuildIn));
            //item.MarkDirty(nameof(item.IsBuildInAll));
            //item.MarkDirty(nameof(item.ServiceCode));
            //item.MarkDirty(nameof(item.Entity));
            //item.MarkDirty(nameof(item.EntityKey));
            //item.MarkDirty(nameof(item.Version));

            var sinhDeThi = await SinhFileDeThi(item, $"{item.Code}.docx");
            if (sinhDeThi.Success && sinhDeThi.Data != Guid.Empty)
            {
                item.FileId = sinhDeThi.Data;
            }

            var result = await base.UpdateAsync(item);
            if (result.Success)
            {
                if (item.DeThi_ChiTiets.Count > 0)
                {
                    await UpdateDeThiChiTiet(item);
                }
                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_DETHI);
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteAsync(int id)
        {
            var result = await base.DeleteAsync(id);
            if (result.Success)
            {
                var listDeThiChiTiet = await _tbl_NHCH_DeThi_ChiTietRepos.GetAllLazy()
                                                .Where(c => c.IdDeThi == id)
                                                .ToListAsync();
                if (listDeThiChiTiet.Any())
                {
                    await _tbl_NHCH_DeThi_ChiTietRepos.DeleteManyAsync(listDeThiChiTiet.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteManyByIdsAsync(int[] ids)
        {
            var result = await base.DeleteManyByIdsAsync(ids);
            if (result.Success)
            {
                var listDelete = await _tbl_NHCH_DeThi_ChiTietRepos.GetAllLazy()
                    .Where(x => x.IdDeThi != null && ids.Contains(x.IdDeThi.Value)).ToListAsync();
                if (listDelete != null && listDelete.Count > 0)
                {
                    await _tbl_NHCH_DeThi_ChiTietRepos.DeleteManyAsync(listDelete.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public async Task<IMethodResult<List<NHCH_DeThi>>> GetPagedDeep(GridInfo gridInfo)
        {
            var query = _repos.GetAllLazy().Select(item => new NHCH_DeThi
            {
                Id = item.Id,
                IdMaTranDeThi = item.IdMaTranDeThi,
                Ten = item.Ten,
                IdHocPhan = item.IdHocPhan,
                MaHocPhan = item.MaHocPhan,
                IdNamHoc = item.IdNamHoc,
                IdHocKy = item.IdHocKy,
                IdDotThi = item.IdDotThi,
                MaDotThi = item.MaDotThi,
                IdCaThi = item.IdCaThi,
                IdToChucThi = item.IdToChucThi,
                IdLichThi = item.IdLichThi,
                NgayThi = item.NgayThi,
                IdBoCauHoi = item.IdBoCauHoi,
                FileId = item.FileId,
                FileApprovedId = item.FileApprovedId,
                Created = item.Created,
                CreatedBy = item.CreatedBy,
                Modified = item.Modified,
                ModifiedBy = item.ModifiedBy,
                IsDeleted = item.IsDeleted,
                Code = item.Code,
                InstanceId = item.InstanceId,
                //IsBuildIn = item.IsBuildIn,
                //IsBuildInAll = item.IsBuildInAll,
                //ServiceCode = item.ServiceCode,
                //Entity = item.Entity,
                //EntityKey = item.EntityKey,
                //Version = item.Version,
                NHCH_DeThi_ChiTiets = item.tbl_NHCH_DeThi_ChiTiets,
                CurrentWorkflowStep = item.CurrentWorkflowStep,
                CurrentWorkflowType = item.CurrentWorkflowType,
                CountOfApprove = item.CountOfApprove,
                TotalCountOfApprove = item.TotalCountOfApprove,
                RejectReason = item.RejectReason,
                MetadataStatus = item.MetadataStatus
            });

            var result = await query.GetPaged<NHCH_DeThi, NHCH_DeThi_ChiTiet>(gridInfo);
            return MethodResult<List<NHCH_DeThi>>.ResultWithData(result.Data, "", result.Total);
        }

        public async Task<IMethodResult<NHCH_DeThi_GetExamByInstanceIdModel>> GetExamByInstanceIdAsync(Guid instanceId)
        {
            var deThiChiTiet = new NHCH_DeThi_GetExamByInstanceIdModel();

            var deThiQuery = _repos.GetAllLazy().Where(x => x.InstanceId == instanceId).Select(item => new NHCH_DeThi
            {
                Ten = item.Ten,
                Code = item.Code,
                InstanceId = item.InstanceId,
                NHCH_DeThi_ChiTiets = item.NHCH_DeThi_ChiTiets
            });
            var deThi = await deThiQuery.FirstOrDefaultAsync();

            if (deThi != null)
            {
                deThiChiTiet.IdDeThi = deThi.InstanceId;
                deThiChiTiet.TenDeThi = deThi.Ten;
                deThiChiTiet.MaDeThi = deThi.Code;
            }

            if (deThi.tbl_NHCH_DeThi_ChiTiet.Any())
            {
                foreach (var chiTiet in deThi.tbl_NHCH_DeThi_ChiTiet)
                {
                    var cauHoiQuery = _tbl_NHCH_CauHoiRepos.GetAllLazy().Where(x => x.Id == chiTiet.IdCauHoi).Select(item => new NHCH_CauHoi
                    {
                        Id = item.Id,
                        InstanceId = item.InstanceId,
                        Code = item.Code,
                        Diem = item.Diem,
                        ThuTu = chiTiet.ThuTu,
                        NoiDungRutGon = item.NoiDungRutGon,
                        NHCH_CauHoi_Clos = item.NHCH_CauHoi_Clos
                    });
                    var cauHoi = await cauHoiQuery.FirstOrDefaultAsync();

                    if (cauHoi != null)
                    {
                        var cauHoiChiTiet = new CauHoiChiTiet()
                        {
                            IdCauHoi = cauHoi.Id,
                            InstanceIdCauHoi = cauHoi.InstanceId,
                            MaCauHoi = cauHoi.Code,
                            NoiDungRutGon = cauHoi.NoiDungRutGon,
                            Diem = cauHoi.Diem,
                            ThuTu = cauHoi.ThuTu,
                        };

                        deThiChiTiet.DanhSachCauHoiChiTiet.Add(cauHoiChiTiet);
                    }
                }
            }

            return MethodResult<NHCH_DeThi_GetExamByInstanceIdModel>.ResultWithData(deThiChiTiet, "");
        }

        public async Task<IMethodResult> GenerateMany(NHCH_DeThi data)
        {
            if (data.IdHocPhan == null)
            {
                return new MethodResult()
                {
                    Success = false,
                    Message = "Chưa chọn học phần",
                    Error = "Chưa chọn học phần"
                };
            }
            if (data.IdDotThi == null)
            {
                return new MethodResult()
                {
                    Success = false,
                    Message = "Chưa chọn đợt thi",
                    Error = "Chưa chọn đợt thi"
                };
            }
            if (data.IdHocKy == null)
            {
                return new MethodResult()
                {
                    Success = false,
                    Message = "Chưa chọn học kỳ",
                    Error = "Chưa chọn học kỳ"
                };
            }
            if (data.IdMaTranDeThi == null)
            {
                return new MethodResult()
                {
                    Success = false,
                    Message = "Chưa chọn ma trận đề thi",
                    Error = "Chưa chọn ma trận đề thi"
                };
            }
            if (data.IdNamHoc == null)
            {
                return new MethodResult()
                {
                    Success = false,
                    Message = "Chưa chọn năm học",
                    Error = "Chưa chọn năm học"
                };
            }

            if (data.LichThiList.Count == 0)
            {
                return new MethodResult()
                {
                    Success = false,
                    Message = "Chưa chọn lịch thi",
                    Error = "Chưa chọn lịch thi"
                };
            }

            int totalInserted = 0;

            int index = 0;
            for (int i = 0; i < data.LichThiList.Count; i++)
            {
                index++;
                var dethi = new NHCH_DeThi();
                dethi.Ten = data.Ten + "-" + index;

                dethi.IdHocPhan = data.IdHocPhan;
                dethi.MaDotThi = data.MaDotThi;
                dethi.IdMaTranDeThi = data.IdMaTranDeThi;
                dethi.IdNamHoc = data.IdNamHoc;
                dethi.IdHocKy = data.IdHocKy;
                dethi.IdDotThi = data.IdDotThi;
                dethi.MaDotThi = data.MaDotThi;
                dethi.IdToChucThi = data.LichThiList[i].IdToChucThi;
                dethi.IdCaThi = data.LichThiList[i].IdCaThi;
                dethi.IdLichThi = data.LichThiList[i].IdLichThi;
                dethi.NgayThi = data.LichThiList[i].NgayThi;
                dethi.LichThiList.Add(data.LichThiList[i]);

                var getDeThiChiTietResult = await GetDeThi_ChiTiet(new NHCH_DeThi_ChiTiet_GenerateExamModel()
                {
                    IdDotThi = dethi.IdDotThi.Value,
                    IdHocKy = dethi.IdHocKy.Value,
                    IdHocPhan = dethi.IdHocPhan.Value,
                    IdMaTranDeThi = dethi.IdMaTranDeThi.Value,
                    IdNamHoc = dethi.IdNamHoc.Value,
                    IdDeThi = data.Id
                });

                if (getDeThiChiTietResult.Success)
                {
                    dethi.NHCH_DeThi_ChiTiets = getDeThiChiTietResult.Data;
                    var insertResult = await InsertAsync(dethi);
                    if (insertResult.Success)
                    {
                        totalInserted++;
                    }
                }
                else
                {
                    return new MethodResult()
                    {
                        Success = false,
                        Message = getDeThiChiTietResult.Message,
                        Error = getDeThiChiTietResult.Error
                    };
                }
            }

            return new MethodResult()
            {
                Success = totalInserted > 0,
                Message = $"Đã tạo thành công {totalInserted}/{data.LichThiList.Count} đề thi."
            };
        }

        protected override async Task OnAfterChangeMetadataStatus(NHCH_DeThi item)
        {
            if (item.MetadataStatus == MetadataStatusType.Approve)
            {
                item.FileApprovedId = item.FileId;
                await _repos.UpdateBulkAsync(new List<NHCH_DeThi> { item });
                //await LuuDeThiPheDuyet(item);
            }

            await base.OnAfterChangeMetadataStatus(item);
        }

        public async Task<IMethodResult<string>> InDeThi(NHCH_DeThi item)
        {
            return await LogicSinhFileDeThi(item, $"{item.Code}.docx");
        }

        public async Task<IMethodResult<string>> XemTruocDeThi(NHCH_DeThi item)
        {
            return await LogicSinhFileDeThi(item, $"{item.Code}.docx", preview: true);
        }

        public async Task<IMethodResult<string>> LuuDeThiPheDuyet(NHCH_DeThi item)
        {
            return await LogicSinhFileDeThi(item, $"{item.Code} (đã duyệt).pdf", true, "pdf");
        }

        private async Task<IMethodResult<string>> LogicSinhFileDeThi(NHCH_DeThi item, string fileName,
            bool daDuyet = false, string outputType = "", bool preview = false)
        {
            try
            {
                var hocPhanResult = await _tbl_HocPhanServiceSdk.GetByInstanceIdAsync(item.IdHocPhan.Value);
                if (hocPhanResult.Success && hocPhanResult.Data != null)
                {
                    var tenHocPhan = hocPhanResult.Data.Ten;
                    var maHocPhan = hocPhanResult.Data.Code;
                    var tenHeDaoTao = "";
                    var ngayThi = "";
                    var thoiGianLamBai = "";
                    var soNgauNhien = "";
                    var tenRutGonHocKy = "";
                    var thuTuDotThi = "";
                    var thuTuCaThi = "";
                    var maDeThi = "";

                    if (hocPhanResult.Data.IdHe.HasValue)
                    {
                        var heDaoTaoResult = await _tbl_DM_NguoiHoc_HeDaoTaoServiceSdk.GetByIdAsync(hocPhanResult.Data.IdHe.Value);
                        if (heDaoTaoResult.Success && heDaoTaoResult.Data != null)
                        {
                            tenHeDaoTao = heDaoTaoResult.Data.HE_Ten;
                        }
                    }

                    if (string.IsNullOrEmpty(item.Code))
                    {
                        var lichThi = item.LichThiList.FirstOrDefault();
                        if (lichThi != null)
                        {
                            var previewDataResult = await _tbl_Thi_DotThiServiceSdk.GetInfoPreviewDeThi(lichThi.IdToChucThi.Value,
                                lichThi.IdCaThi.Value, lichThi.IdLichThi.Value);
                            if (previewDataResult.Success && previewDataResult.Data != null)
                            {
                                ngayThi = previewDataResult.Data.NgayThi.Value.ToString("ddMMyy");
                                thoiGianLamBai = previewDataResult.Data.ThoiGianSoPhut.ToString();
                                tenRutGonHocKy = previewDataResult.Data.TenRutGonHocKy;
                                thuTuDotThi = previewDataResult.Data.ThuTuDotThi.ToString("D2");
                                thuTuCaThi = previewDataResult.Data.ThuTuCaThi.ToString();
                            }
                        }

                        Random generator = new Random();
                        soNgauNhien = generator.Next(0, 99999).ToString("D5");

                        var maDeThiResult = await _templateClientService.CompileTemplateByCodeAsync("NHCH_MA_DE_THI", new
                        {
                            ngayThi = ngayThi,
                            soNgauNhien = soNgauNhien,
                            maHocPhan = maHocPhan,
                            tenRutGonHocKy = tenRutGonHocKy,
                            thuTuDotThi = thuTuDotThi,
                            thuTuCaThi = thuTuCaThi
                        });
                        if (maDeThiResult.Success && maDeThiResult.Data != null)
                        {
                            maDeThi = maDeThiResult.Data;
                        }
                    }
                    else
                    {
                        maDeThi = item.Code;
                    }

                    if (item.NHCH_DeThi_ChiTiets.Count > 0)
                    {
                        var danhSachIdCauHoi = item.NHCH_DeThi_ChiTiets.Select(x => x.IdCauHoi.Value).ToArray();
                        if (danhSachIdCauHoi.Length > 0)
                        {
                            var danhSachNoiDungCauHoiResult = await _tbl_NHCH_CauHoiRepos.GetByIdsAsync(danhSachIdCauHoi);
                            if (danhSachNoiDungCauHoiResult.Success && danhSachNoiDungCauHoiResult.Data != null)
                            {
                                var danhSachCauHoi = new List<NHCH_CauHoi_ExportModel>();
                                foreach (var chiTiet in item.NHCH_DeThi_ChiTiets)
                                {
                                    var exportItem = new NHCH_CauHoi_ExportModel()
                                    {
                                        soCauHoi = chiTiet.ThuTu,
                                        soDiem = chiTiet.Diem
                                    };

                                    var sendFileObject = new ServiceFileObjectModel()
                                    {
                                        Service = ServiceConstant.SERVICE_NAME,
                                        Entity = ServiceConstant.ENTITY_TBL_NHCH_CAUHOI,
                                        EntityInstanceId = danhSachNoiDungCauHoiResult.Data.FirstOrDefault(x => x.Id == chiTiet.IdCauHoi).InstanceId
                                    };

                                    var fileBinaryResult = await _fileClientService.GetSingleServiceFileBinary(sendFileObject);
                                    if (fileBinaryResult.Success && fileBinaryResult.Data != null)
                                    {
                                        exportItem.noiDung = ConvertHelper.ByteArrayToBase64(fileBinaryResult.Data.Content);
                                        if (string.IsNullOrWhiteSpace(exportItem.noiDung))
                                        {
                                            return MethodResult<string>.ResultWithError("ERROR_CAUHOI_NULL", 400, $"Nội dung câu hỏi {chiTiet.MaCauHoi} không được để trống");
                                        }
                                    }

                                    danhSachCauHoi.Add(exportItem);
                                }

                                dynamic data = new JObject();
                                data.tenHocPhan = tenHocPhan;
                                data.tenHeDaoTao = tenHeDaoTao;
                                data.thoiGianLamBai = thoiGianLamBai;
                                data.maDeThi = maDeThi;
                                data.danhSachCauHoi = JToken.FromObject(danhSachCauHoi);
                                data.fileName = fileName;

                                if (preview)
                                {
                                    IMethodResult<string> deThiResult = await _templateClientService.FillWordByTemplateCodeAndPrint("DETHIMAU2020", data);
                                    return deThiResult;
                                }
                                else
                                {
                                    IMethodResult<FileBinaryResult> deThiResult = await _templateClientService.FillWordByTemplateCode("DETHIMAU2020", data);
                                    var objModel = new FileObjectModel()
                                    {
                                        OwnedId = OwnedType.Temp.ToString()
                                    };
                                    IMethodResult<string> rs = await _fileClientService.UploadWithByteArray(deThiResult.Data.Content, objModel, "DeThi.docx");

                                    if (rs.Data != null)
                                    {
                                        // Nếu không phải là xem trước thì lưu lại
                                        await _tbl_NHCH_DeThiRepos.UpdateFileDethi(item.Id, Guid.Parse(rs.Data), daDuyet);

                                        return MethodResult<string>.ResultWithData(rs.Data.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return MethodResult<string>.ResultWithError("ERROR_EXCEPTION", 0, ex.Message);
            }

            return MethodResult<string>.ResultWithError("ERROR_BAD_REQUEST", 0, "Lỗi dữ liệu");
        }

        [IgnoreGrpcGenerate]
        public async Task<IMethodResult<List<NHCH_DeThi_ChiTiet>>> GetDeThi_ChiTiet(NHCH_DeThi_ChiTiet_GenerateExamModel data)
        {
            var listDeThiChiTiet = new List<NHCH_DeThi_ChiTiet>();

            if (data != null)
            {
                var listCauHoiPicked = new List<NHCH_CauHoi>();

                //Lấy câu hỏi theo bộ câu hỏi
                var listCauHoiTheoBoCauHoi = new List<int>();
                if (data.IdBoCauHoi != Guid.Empty)
                {
                    listCauHoiTheoBoCauHoi = _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().Where(x => x.IdBoCauHoi == data.IdBoCauHoi).Select(x => x.IdCauHoi).ToList();
                }

                // Lấy ma trận đề thi kèm chi tiết
                var maTranDeThiDeepResult = await _tbl_NHCH_MaTranDeThiRepos.GetByIdAsyncDeep(data.IdMaTranDeThi);
                if (maTranDeThiDeepResult.Success)
                {
                    //Danh sách câu hỏi đã bốc trong năm hiện tại và 1 năm trước;
                    var listCauHoiLoaiTru = await GetCauHoiDaBocTheoNamHoc(data.IdHocPhan, data.IdNamHoc);
                    var g_soThuTu = 1;
                    foreach (var maTranDeThiChiTiet in maTranDeThiDeepResult.Data.tbl_NHCH_MaTranDeThi_ChiTiet)
                    {
                        // Lấy danh sách câu hỏi khả theo ma trận đề thi chi tiết
                        var listCauHoiKhaThiResult = await _tbl_NHCH_CauHoiRepos.GetByMaTranDeThiChiTiet(maTranDeThiChiTiet, listCauHoiLoaiTru);
                        if (listCauHoiKhaThiResult != null)
                        {
                            //lọc câu hỏi theo bộ câu hỏi
                            if (data.IdBoCauHoi != Guid.Empty)
                            {
                                listCauHoiKhaThiResult = listCauHoiKhaThiResult.Where(x => listCauHoiTheoBoCauHoi.Contains(x.Id)).ToList();
                            }

                            if (listCauHoiKhaThiResult.Count < maTranDeThiChiTiet.SoCauHoi)
                            {
                                // Cần confirm trường hợp ngân hàng câu hỏi không đủ
                                return MethodResult<List<NHCH_DeThi_ChiTiet>>.ResultWithError("Số câu hỏi khả dụng không đủ để chọn");
                            }
                            else
                            {
                                Random random = new Random();
                                var soCauHoi = 0;
                                var maxValue = listCauHoiKhaThiResult.Count;

                                while (soCauHoi < maTranDeThiChiTiet.SoCauHoi)
                                {
                                    var cauHoiPick = new NHCH_CauHoi();
                                    do
                                    {
                                        // Lấy ngẫu nhiên 1 câu hỏi
                                        cauHoiPick = listCauHoiKhaThiResult[random.Next(maxValue)];

                                        // Đoạn này có thể chạy vĩnh viễn do hết câu hỏi để chọn
                                        // Còn chọn tiếp khi câu hỏi đã được chọn hoặc toàn bộ câu hỏi khả thi chưa được chọn
                                    }
                                    while (listCauHoiPicked.Exists(x => x == cauHoiPick));
                                    //listCauHoiKhaThiResult.Intersect(listCauHoiPicked).Count() != listCauHoiKhaThiResult.Count()

                                    if (cauHoiPick.Id != Guid.Empty)
                                    {
                                        var deThiChiTiet = new NHCH_DeThi_ChiTiet()
                                        {
                                            IdCauHoi = cauHoiPick.Id,
                                            InstanceIdCauHoi = cauHoiPick.InstanceId,
                                            //NoiDungRutGon = cauHoiPick.NoiDungRutGon,
                                            ThuTu = g_soThuTu,
                                            IdMaTranDeThiChiTiet = maTranDeThiChiTiet.Id,
                                            MaCauHoi = cauHoiPick.Code,
                                            IdDeThi = data.IdDeThi
                                        };

                                        if (cauHoiPick.NHCH_CauHoi_Clos.Any())
                                        {
                                            deThiChiTiet.DanhSachClo = String.Join(", ", cauHoiPick.NHCH_CauHoi_Clos.Select(x => x.MaClo).ToList());
                                        }

                                        listDeThiChiTiet.Add(deThiChiTiet);

                                        g_soThuTu++;

                                        listCauHoiPicked.Add(cauHoiPick);

                                        soCauHoi++;
                                    }
                                    else
                                    {
                                        // Cần confirm trường hợp hết câu hỏi để bốc
                                        return MethodResult<List<NHCH_DeThi_ChiTiet>>.ResultWithError("Số câu hỏi khả dụng không đủ để chọn");
                                    }
                                }
                            }
                        }
                    }
                }

                // Update câu khỏi thành không khả dụng
                // Chuyển sang case save đề thi
                //if(listCauHoiPicked.Count > 0)
                //{
                //    foreach(var cauHoi in listCauHoiPicked)
                //    {
                //        cauHoi.KhaDung = false;
                //        cauHoi.Modified = DateTime.UtcNow;
                //        cauHoi.ModifiedBy = _userPrincipalService.UserId.ToString();
                //        await _tbl_NHCH_CauHoiRepos.UpdateEntireModel(cauHoi);
                //    }
                //}
            }

            return MethodResult<List<NHCH_DeThi_ChiTiet>>.ResultWithData(listDeThiChiTiet, "", listDeThiChiTiet.Count);
        }

        public override async Task<IMethodResult> UpdateAndChangeMetadataStatus(int id, MetadataStatusType metadataStatusType, NHCH_DeThi model)
        {
            var result = await base.UpdateAndChangeMetadataStatus(id, metadataStatusType, model);

            if (result.Success)
            {
                if (metadataStatusType == MetadataStatusType.Approve || metadataStatusType == MetadataStatusType.Reject)
                {
                    var notifySend = new List<string>();
                    notifySend.Add(model.CreatedBy);

                    var nguoiPheDuyetResult = await _organizationManagementClientService.GetById(_userPrincipalService.UserId);
                    if (nguoiPheDuyetResult.Success && nguoiPheDuyetResult.Data != null)
                    {
                        var requestDomain = _configuration.GetValue("ClientDomain:NHCH", "");
                        var actionText = "";

                        switch (metadataStatusType)
                        {
                            case MetadataStatusType.Approve:
                                actionText = "đã phê duyệt";
                                break;
                            case MetadataStatusType.Reject:
                                actionText = "đã từ chối";
                                break;
                        }

                        var objNotify = new
                        {
                            nguoiPheDuyet = nguoiPheDuyetResult.Data.FullName,
                            actionDisplayText = actionText,
                            tenDeThi = model.Ten,
                            clientDomain = requestDomain,
                            routerLink = "de-thi#_a=1&_i=" + model.Id.ToString()
                        };
                        var infoNotify = JObject.FromObject(objNotify);

                        var internalNotifyTemplate = (await _templateClientService.CompileTemplateByCodeAsync("NHCH_PHEDUYET_NOTIFY", infoNotify)).Data;
                        var internalNotifyLinkTemplate = (await _templateClientService.CompileTemplateByCodeAsync("NHCH_PHEDUYET_NOTIFY_LINK", infoNotify)).Data;

                        // gửi thông báo nội bộ cho người nhận
                        await _notificationClientService.CreateNotification(new Notification.Client.Models.NotificationInfoModel()
                        {
                            CreatedDate = DateTime.UtcNow,
                            CreatedUserId = _userPrincipalService.UserId.ToString(),
                            SendTo = notifySend,
                            Message = new Notification.Client.Models.Message()
                            {
                                Content = internalNotifyTemplate,
                                Link = internalNotifyLinkTemplate,
                                Time = DateTime.UtcNow
                            }
                        });
                    }
                }
            }

            return result;
        }

        private async Task<List<int>> GetCauHoiDaBocTheoNamHoc(Guid idHocPhan, Guid idNamHoc)
        {
            var listNamHoc = new List<Guid>() { idNamHoc };

            var namhoc = (await _tbl_HeThong_NamHocServiceSdk.GetByInstanceIdAsync(idNamHoc)).Data;
            GridInfo gridInfoNamHoc = new GridInfo(10000);
            gridInfoNamHoc.Sorts = new List<Sort>();
            gridInfoNamHoc.Filters.Add(new Filter()
            {
                Field = nameof(tbl_HeThong_NamHoc.Nam),
                Operator = Operator.Equal,
                Value = (namhoc.Nam - 1).ToString()
            });
            gridInfoNamHoc.Fields = nameof(tbl_HeThong_NamHoc.InstanceId);


            var namHocTruoc = (await _tbl_HeThong_NamHocServiceSdk.GetPaged(gridInfoNamHoc)).Data.FirstOrDefault();
            if (namHocTruoc != null)
            {
                listNamHoc.Add(namHocTruoc.InstanceId);
            }

            var query = await (from x in _repos.GetAllLazy()
                               join a in _tbl_NHCH_DeThi_ChiTietRepos.GetAllLazy() on x.Id equals a.IdDeThi
                               where listNamHoc.Contains(x.IdNamHoc.Value) && x.IdHocPhan == idHocPhan
                               select a.IdCauHoi.Value).Distinct().ToListAsync();
            return query;
        }

        #region Hàm maitain 

        /// <summary>
        /// Preview DeThi By IdCauHoi
        /// </summary>
        /// <param name="idCauHois"></param>
        /// <returns></returns>
        public async Task<IMethodResult<string>> GetDataForPreviewDeThi(PreviewDeThiRequestModel model)
        {
            var hocPhanRs = await _tbl_HocPhanServiceSdk.GetByInstanceIdAsync(model.InstanceIdHocPhan);
            if (!hocPhanRs.Success || hocPhanRs.Data == null)
            {
                return MethodResult<string>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy thông tin học phần");
            }

            if (model.DeThi_ChiTiets.Count == 0)
            {
                return MethodResult<string>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy câu hỏi nào");
            }

            var idCauHois = model.DeThi_ChiTiets.Select(x => x.IdCauHoi).ToList();
            var lstCauHois = await _tbl_NHCH_CauHoiRepos.GetAllLazy()
                                                        .Where(x => idCauHois.Contains(x.Id))
                                                        .ToListAsync();

            var danhSachCauHoi = new List<NHCH_CauHoi_ExportModel>();
            int index = 1;
            foreach (var idCauHoi in idCauHois)
            {
                var itemCauHoi = lstCauHois.FirstOrDefault(x => x.Id == idCauHoi);
                if (itemCauHoi is null)
                {
                    continue;
                }

                var itemChiTiet = model.DeThi_ChiTiets.FirstOrDefault(x => x.IdCauHoi == idCauHoi);
                if (itemChiTiet is null)
                {
                    continue;
                }

                var exportItem = new NHCH_CauHoi_ExportModel()
                {
                    soCauHoi = index++,
                    soDiem = itemChiTiet.Diem
                };

                var sendFileObject = new ServiceFileObjectModel()
                {
                    Service = ServiceConstant.SERVICE_NAME,
                    Entity = ServiceConstant.ENTITY_TBL_NHCH_CAUHOI,
                    EntityInstanceId = itemCauHoi.InstanceId
                };

                var fileBinaryResult = await _fileClientService.GetSingleServiceFileBinary(sendFileObject);
                if (fileBinaryResult.Success && fileBinaryResult.Data != null)
                {
                    exportItem.noiDung = ConvertHelper.ByteArrayToBase64(fileBinaryResult.Data.Content);
                    if (string.IsNullOrWhiteSpace(exportItem.noiDung))
                    {
                        return MethodResult<string>.ResultWithError("ERROR_CAUHOI_NULL", 400, $"Nội dung câu hỏi {itemCauHoi.Code} không được để trống");
                    }
                }

                danhSachCauHoi.Add(exportItem);
            }

            dynamic data = new JObject();
            data.tenHocPhan = $"{hocPhanRs.Data.Code} - {hocPhanRs.Data.Ten}";
            data.danhSachCauHoi = JToken.FromObject(danhSachCauHoi);

            var rsContent = await _templateClientService.FillWordByTemplateCode("XEMTRUOCDETHI", data);
            var objModel = new FileObjectModel()
            {
                OwnedId = OwnedType.Temp.ToString()
            };
            IMethodResult<string> rs = await _fileClientService.UploadWithByteArray(rsContent.Data.Content, objModel, $"DeThi_{hocPhanRs.Data.Ten}.docx");
            return rs;
        }

        /// <summary>
        /// Sinh file đề thi => trả về idFile
        /// => Dùng trong các trường hợp insert or update đề
        /// </summary>
        /// <returns></returns>
        private async Task<IMethodResult<Guid>> SinhFileDeThi(NHCH_DeThi deThi, string fileName)
        {
            var hocPhanRs = await _tbl_HocPhanServiceSdk.GetByInstanceIdAsync(deThi.IdHocPhan.Value);
            if (!hocPhanRs.Success || hocPhanRs.Data == null)
            {
                return MethodResult<Guid>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy thông tin học phần");
            }

            var heDaoTaoRs = await _tbl_DM_NguoiHoc_HeDaoTaoServiceSdk.GetByIdAsync(hocPhanRs.Data.IdHe.Value);
            if (!heDaoTaoRs.Success || heDaoTaoRs.Data == null)
            {
                return MethodResult<Guid>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm được thông tin hệ đào tạo");
            }

            if (deThi.DeThi_ChiTiets.Count == 0)
            {
                return MethodResult<Guid>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm được câu hỏi chi tiết");
            }

            var lstCauHoiChiTiet = deThi.DeThi_ChiTiets.OrderBy(x => x.ThuTu).ToList();
            var lstIdCauHoi = lstCauHoiChiTiet.Select(x => x.IdCauHoi).ToList();

            var lstCauHoi = _tbl_NHCH_CauHoiRepos.GetAllLazy()
                                                 .Where(x => lstIdCauHoi.Contains(x.Id))
                                                 .ToList();

            var lstCauHoi_Data = new List<NHCH_CauHoi_ExportModel>();
            foreach (var chiTiet in lstCauHoiChiTiet)
            {
                var exportItem = new NHCH_CauHoi_ExportModel()
                {
                    soCauHoi = chiTiet.ThuTu,
                    soDiem = chiTiet.Diem
                };

                var sendFileObject = new ServiceFileObjectModel()
                {
                    Service = ServiceConstant.SERVICE_NAME,
                    Entity = ServiceConstant.ENTITY_TBL_NHCH_CAUHOI,
                    EntityInstanceId = lstCauHoi.FirstOrDefault(x => x.Id == chiTiet.IdCauHoi).InstanceId
                };

                var fileBinaryResult = await _fileClientService.GetSingleServiceFileBinary(sendFileObject);
                if (fileBinaryResult.Success && fileBinaryResult.Data != null)
                {
                    exportItem.noiDung = ConvertHelper.ByteArrayToBase64(fileBinaryResult.Data.Content);
                    if (string.IsNullOrWhiteSpace(exportItem.noiDung))
                    {
                        return MethodResult<Guid>.ResultWithError("ERROR_CAUHOI_NULL", 400, $"Không tìm thấy nội dung câu hỏi {chiTiet.MaCauHoi}");
                    }
                }
                lstCauHoi_Data.Add(exportItem);
            }

            dynamic data = new JObject();
            data.tenHocPhan = hocPhanRs.Data.Ten;
            data.tenHeDaoTao = heDaoTaoRs.Data.HE_Ten;
            data.thoiGianLamBai = deThi.ThoiGianLamBai;
            data.maDeThi = deThi.Code;
            data.danhSachCauHoi = JToken.FromObject(lstCauHoi_Data);
            data.fileName = fileName;
            IMethodResult<FileBinaryResult> deThiResult = await _templateClientService.FillWordByTemplateCode("DETHIMAU2020", data);

            //var objModel = new FileObjectModel()
            //{
            //    OwnedId = OwnedType.Temp.ToString()
            //};
            //IMethodResult<string> rs = await _fileClientService.UploadWithByteArray(deThiResult.Data.Content, objModel, fileName);
            //if (rs.Success && rs.Data != null)
            //{
            //    return MethodResult<Guid>.ResultWithData(Guid.Parse(rs.Data));
            //}

            if (deThiResult.Data != null)
            {
                using (var stream = new MemoryStream(deThiResult.Data.Content))
                {
                    var file = new FormFile(stream, 0, deThiResult.Data.Content.Length, "file", fileName);
                    var rs = await _fileClientService.CreateServiceFile(new ServiceFileObjectModel()
                    {
                        File = file,
                        Service = ServiceConstant.SERVICE_NAME,
                        Entity = ServiceConstant.ENTITY_TBL_NHCH_DETHI,
                        EntityInstanceId = deThi.InstanceId,
                        IsMultiple = false
                    });

                    if (rs.Success && rs.Data != null)
                    {
                        return MethodResult<Guid>.ResultWithData(rs.Data);
                    }
                }
            }
            return MethodResult<Guid>.ResultWithData(Guid.Empty);
        }

        #endregion

        #region Tổng hợp các hàm dùng cho phân hệ điểm

        public async Task<IMethodResult<NHCH_DeThi>> GetDeThi(Guid idHocPhan, Guid idToChucThi, Guid idCaThi, DateTime ngayThi)
        {
            var deThi = await _tbl_NHCH_DeThiRepos.GetAllLazy().Where(x => x.IdHocPhan == idHocPhan && x.IdToChucThi == idToChucThi
                                                                     && x.IdCaThi == idCaThi && x.NgayThi.Value.Date == ngayThi.Date)
                                                         .FirstOrDefaultAsync();

            if (deThi != null)
            {
                await GetInfoDeThiChiTiet(deThi);
            }
            return MethodResult<NHCH_DeThi>.ResultWithData(deThi);
        }

        public async Task<IMethodResult<NHCH_DeThi>> GetDeThiChiTietClo(Guid instanceIdDeThi)
        {
            var deThi = await _repos.GetByInstanceIdAsync(instanceIdDeThi);
            if (deThi.Success)
            {
                await GetInfoDeThiChiTiet(deThi.Data);
            }
            return deThi;
        }

        /// <summary>
        /// Lấy ra chi tiết đề thi -> câu hỏi -> câu hỏi clo
        /// </summary>
        /// <param name="deThi"></param>
        /// <returns></returns>
        private async Task GetInfoDeThiChiTiet(NHCH_DeThi deThi)
        {
            deThi.NHCH_DeThi_ChiTiets = await _tbl_NHCH_DeThi_ChiTietRepos.GetAllLazy().Where(x => x.IdDeThi == deThi.Id).OrderBy(x => x.ThuTu).ToListAsync();
            foreach (var item in deThi.NHCH_DeThi_ChiTiets)
            {
                var idCauHoi = item.IdCauHoi;
                item.CauHoi = _tbl_NHCH_CauHoiRepos.GetAllLazy().Where(x => x.Id == idCauHoi).FirstOrDefault();
                if (item.CauHoi != null)
                {
                    item.CauHoi.NHCH_CauHoi_Clos = _tbl_NHCH_CauHoi_CloRepos.GetAllLazy().Where(x => x.IdCauHoi == idCauHoi).ToList();
                }
            }
        }

        #endregion
        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_DeThi item)
        //    {
        //        item.MarkDirty<NHCH_DeThi>(x => new 
        //        {
        //            item.Code,
        //item.CountOfApprove,
        //item.Created,
        //item.CreatedBy,
        //item.CurrentWorkflowStep,
        //item.CurrentWorkflowType,
        //item.Entity,
        //item.EntityKey,
        //item.FileApprovedId,
        //item.FileId,
        //item.IdBoCauHoi,
        //item.IdCaThi,
        //item.IdDotThi,
        //item.IdHocKy,
        //item.IdHocPhan,
        //item.IdLichThi,
        //item.IdMaTranDeThi,
        //item.IdNamHoc,
        //item.IdToChucThi,
        //item.IsBuildIn,
        //item.IsBuildInAll,
        //item.IsDeleted,
        //item.MaDotThi,
        //item.MaHocPhan,
        //item.MetadataStatus,
        //item.Modified,
        //item.ModifiedBy,
        //item.NgayThi,
        //item.RejectReason,
        //item.ServiceCode,
        //item.Ten,
        //item.ThoiGianLamBai,
        //item.TotalCountOfApprove,
        //item.Version,
        //        });
        //        return await base.UpdateAsync(item);
        //    }
    }
}