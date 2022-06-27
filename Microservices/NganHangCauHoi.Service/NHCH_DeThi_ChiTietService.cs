

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CamlBuilder;
//using Shared.All.Common.Models;
//using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SharePoint.Client.Search.Query;
using NganHangCauHoi.Data.CustomModels;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Interfaces;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_DeThi_ChiTietService 
    {
        public NHCH_DeThi_ChiTietService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) //: base(dataContext, serviceProvider)
        {

        }

        protected NHCH_DeThi_ChiTietService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}

        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly IUserPrincipalService _userPrincipalService;
        private readonly INHCH_MaTranDeThiRepos _tbl_NHCH_MaTranDeThiRepos;
        private readonly INHCH_MaTranDeThi_ChiTietRepos _tbl_NHCH_MaTranDeThi_ChiTietRepos;
        private readonly INHCH_CauHoiRepos _tbl_NHCH_CauHoiRepos;
        private readonly INHCH_BoCauHoi_CauHoiRepos _tbl_NHCH_BoCauHoi_CauHoiRepos;
        private readonly INHCH_CauHoi_CloRepos _tbl_NHCH_CauHoi_CloRepos;
        private readonly INHCH_DeThiRepos _tbl_NHCH_DeThiRepos;
        private readonly Itbl_HeThong_NamHocServiceSdk _tbl_HeThong_NamHocServiceSdk;
        private readonly INHCH_DeThi_ChiTietRepos _repos;


        public NHCH_DeThi_ChiTietService(
                    INHCH_DeThi_ChiTietRepos repos,
                    IServiceProvider serviceProvider,
                    IEntityChangedEventService entityChangedEventService,
                    IUserPrincipalService userPrincipalService,
                    INHCH_MaTranDeThiRepos tbl_NHCH_MaTranDeThiRepos,
                    INHCH_MaTranDeThi_ChiTietRepos tbl_NHCH_MaTranDeThi_ChiTietRepos,
                    INHCH_CauHoiRepos tbl_NHCH_CauHoiRepos,
                    INHCH_CauHoi_CloRepos tbl_NHCH_CauHoi_CloRepos,
                    INHCH_DeThiRepos tbl_NHCH_DeThiRepos,
                    Itbl_HeThong_NamHocServiceSdk tbl_HeThong_NamHocServiceSdk,
                    INHCH_BoCauHoi_CauHoiRepos tbl_NHCH_BoCauHoi_CauHoiRepos
            )
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
            _userPrincipalService = userPrincipalService;
            _tbl_NHCH_MaTranDeThiRepos = tbl_NHCH_MaTranDeThiRepos;
            _tbl_NHCH_MaTranDeThi_ChiTietRepos = tbl_NHCH_MaTranDeThi_ChiTietRepos;
            _tbl_NHCH_CauHoiRepos = tbl_NHCH_CauHoiRepos;
            _tbl_NHCH_CauHoi_CloRepos = tbl_NHCH_CauHoi_CloRepos;
            _tbl_NHCH_DeThiRepos = tbl_NHCH_DeThiRepos;
            _tbl_HeThong_NamHocServiceSdk = tbl_HeThong_NamHocServiceSdk;
            _tbl_NHCH_BoCauHoi_CauHoiRepos = tbl_NHCH_BoCauHoi_CauHoiRepos;
        }

        public override async Task<IMethodResult> UpdateAsync(NHCH_DeThi_ChiTiet item)
        {
            item.MarkDirty(nameof(item.IdDeThi));
            item.MarkDirty(nameof(item.IdCauHoi));
            item.MarkDirty(nameof(item.IdMaTranDeThiChiTiet));
            item.MarkDirty(nameof(item.ThuTu));
            item.MarkDirty(nameof(item.Modified));
            item.MarkDirty(nameof(item.ModifiedBy));
            item.MarkDirty(nameof(item.Code));
            //item.MarkDirty(nameof(item.IsBuildIn));
            //item.MarkDirty(nameof(item.IsBuildInAll));
            //item.MarkDirty(nameof(item.ServiceCode));
            //item.MarkDirty(nameof(item.Entity));
            //item.MarkDirty(nameof(item.EntityKey));
            //item.MarkDirty(nameof(item.Version));

            var result = await base.UpdateAsync(item);
            if (result.Success)
            {
                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_DETHI_CHITIET);
            }
            return result;
        }

        public async Task<IMethodResult<List<NHCH_DeThi_ChiTiet>>> GenerateExam(NHCH_DeThi_ChiTiet_GenerateExamModel data)
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
                    var tbl_NHCH_MaTranDeThi_ChiTiet = maTranDeThiDeepResult.Data.tbl_NHCH_MaTranDeThi_ChiTiet.OrderBy(x => x.ThuTu).ToList();
                    var g_soThuTu = 1;

                    //Danh sách câu hỏi đã bốc trong năm hiện tại và 1 năm trước;
                    var listCauHoiLoaiTru = await GetCauHoiDaBocTheoNamHoc(data.IdHocPhan, data.IdNamHoc);
                    foreach (var maTranDeThiChiTiet in tbl_NHCH_MaTranDeThi_ChiTiet)
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
                                return MethodResult<List<NHCH_DeThi_ChiTiet>>.ResultWithData(null, "Số câu hỏi khả dụng không đủ để chọn thuộc Tín chỉ: "
                                    + maTranDeThiChiTiet.TinChi);
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
                                            Diem = maTranDeThiChiTiet.Diem ?? 0,
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
                                        return MethodResult<List<NHCH_DeThi_ChiTiet>>.ResultWithData(null, "Số câu hỏi khả dụng không đủ để chọn");
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

            var query = await (from x in _tbl_NHCH_DeThiRepos.GetAllLazy()
                               join a in _repos.GetAllLazy() on x.Id equals a.IdDeThi
                               where listNamHoc.Contains(x.IdNamHoc.Value) && x.IdHocPhan == idHocPhan
                               select a.IdCauHoi.Value).Distinct().ToListAsync();
            return query;
        }

        public async Task<IMethodResult<NHCH_DeThi_ChiTiet>> ChangeQuestion(NHCH_DeThi_ChiTiet_ChangeQuestionModel data)
        {
            var deThiChiTiet = new NHCH_DeThi_ChiTiet();
            if (data != null)
            {
                //Lấy câu hỏi theo bộ câu hỏi
                var listCauHoiTheoBoCauHoi = new List<int>();
                if (data.IdBoCauHoi != Guid.Empty)
                {
                    listCauHoiTheoBoCauHoi = _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().Where(x => x.IdBoCauHoi == data.IdBoCauHoi).Select(x => x.IdCauHoi).ToList();
                }

                var listCauHoiPicked = new List<Guid>();
                if (data.IdDeThi != null)
                {
                    var idCauHois = await _repos.GetIdCauHoiByIdDeThiAsync(data.IdDeThi.Value);
                    if (idCauHois.Any())
                    {
                        listCauHoiPicked.AddRange(idCauHois);
                    }
                }
                if (!listCauHoiPicked.Exists(x => x == data.IdCauHoi))
                {
                    listCauHoiPicked.Add(data.IdCauHoi);
                }
                var dethi = await _tbl_NHCH_DeThiRepos.GetAllLazy().FirstOrDefaultAsync(x => x.Id == data.IdDeThi);
                var maTranDeThiChiTietResult = await _tbl_NHCH_MaTranDeThi_ChiTietRepos.GetByIdAsync(data.IdMaTranDeThiChiTiet);
                if (maTranDeThiChiTietResult.Success)
                {
                    //Danh sách câu hỏi đã bốc trong năm hiện tại và 1 năm trước;
                    var listCauHoiLoaiTru = new List<int>();
                    if (dethi != null)
                    {
                        listCauHoiLoaiTru = await GetCauHoiDaBocTheoNamHoc(dethi.IdHocPhan.Value, dethi.IdNamHoc.Value);
                    }
                    else
                    {
                        listCauHoiLoaiTru = data.ListCauHoiLoaiTru.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                    }

                    var maTranDeThiChiTiet = maTranDeThiChiTietResult.Data;
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
                            return MethodResult<NHCH_DeThi_ChiTiet>.ResultWithData(null, "Số câu hỏi khả dụng không đủ để chọn");
                        }
                        else
                        {
                            Random random = new Random();
                            var maxValue = listCauHoiKhaThiResult.Count;

                            var cauHoiPick = new NHCH_CauHoi();
                            do
                            {
                                // Lấy ngẫu nhiên 1 câu hỏi
                                cauHoiPick = listCauHoiKhaThiResult[random.Next(maxValue)];

                                // Đoạn này có thể chạy vĩnh viễn do hết câu hỏi để chọn
                                // Còn chọn tiếp khi câu hỏi đã được chọn hoặc toàn bộ câu hỏi khả thi chưa được chọn
                            }
                            while (listCauHoiPicked.Exists(x => x == cauHoiPick.Id));
                            //listCauHoiKhaThiResult.Intersect(listCauHoiPicked).Count() != listCauHoiKhaThiResult.Count()

                            if (cauHoiPick.Id != Guid.Empty)
                            {
                                deThiChiTiet = new NHCH_DeThi_ChiTiet()
                                {
                                    IdCauHoi = cauHoiPick.Id,
                                    InstanceIdCauHoi = cauHoiPick.InstanceId,
                                    NoiDungRutGon = cauHoiPick.NoiDungRutGon,
                                    NoiDung = cauHoiPick.NoiDung,
                                    ThuTu = data.ThuTu,
                                    IdMaTranDeThiChiTiet = maTranDeThiChiTiet.Id,
                                    MaCauHoi = cauHoiPick.Code
                                };

                                if (cauHoiPick.NHCH_CauHoi_Clos.Any())
                                {
                                    deThiChiTiet.DanhSachClo = String.Join(", ", cauHoiPick.NHCH_CauHoi_Clos.Select(x => x.MaClo).ToList());
                                }
                            }
                            else
                            {
                                // Cần confirm trường hợp hết câu hỏi để bốc
                                return MethodResult<NHCH_DeThi_ChiTiet>.ResultWithData(null, "Số câu hỏi khả dụng không đủ để chọn");
                            }
                        }
                    }
                }
            }

            return MethodResult<NHCH_DeThi_ChiTiet>.ResultWithData(deThiChiTiet, "");
        }

        public async Task<IMethodResult<NHCH_DeThi_ChiTiet>> ChangeQuestionTo(NHCH_DeThi_ChiTiet data)
        {
            var deThiChiTiet = await _repos.GetAllLazy().FirstOrDefaultAsync(x => x.Id == data.Id);
            deThiChiTiet.IdCauHoi = data.IdCauHoi;
            deThiChiTiet.MarkDirty(nameof(deThiChiTiet.IdCauHoi));

            await _repos.UpdateAsync(deThiChiTiet);
            var cauHoi = await _tbl_NHCH_CauHoiRepos.GetAllLazy().FirstOrDefaultAsync(x => x.Id == data.IdCauHoi);
            deThiChiTiet.MaCauHoi = cauHoi.Code;
            deThiChiTiet.NoiDung = cauHoi.NoiDung;
            deThiChiTiet.NoiDungRutGon = cauHoi.NoiDungRutGon;
            deThiChiTiet.InstanceIdCauHoi = cauHoi.InstanceId;
            var listCauHoiClo = _tbl_NHCH_CauHoi_CloRepos.GetAllLazy()
                                                         .Where(x => x.IdCauHoi == data.IdCauHoi)
                                                         .Select(x => x.MaClo).ToList();
            deThiChiTiet.DanhSachClo = string.Join(", ", listCauHoiClo);

            return MethodResult<NHCH_DeThi_ChiTiet>.ResultWithData(deThiChiTiet, "");
        }
        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_DeThi_ChiTiet item)
        //    {
        //        item.MarkDirty<NHCH_DeThi_ChiTiet>(x => new 
        //        {
        //            item.Code,
        //item.Created,
        //item.CreatedBy,
        //item.Diem,
        //item.Entity,
        //item.EntityKey,
        //item.IdCauHoi,
        //item.IdDeThi,
        //item.IdMaTranDeThiChiTiet,
        //item.IsBuildIn,
        //item.IsBuildInAll,
        //item.IsDeleted,
        //item.Modified,
        //item.ModifiedBy,
        //item.ServiceCode,
        //item.ThuTu,
        //item.Version,
        //        });
        //        return await base.UpdateAsync(item);
        //    }
    }
}