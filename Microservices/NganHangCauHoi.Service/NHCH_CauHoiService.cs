

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
//using Shared.All.Common.Models;
//using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SharePoint.News.DataModel;
using NganHangCauHoi.Data.CustomModels;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Generated.Interfaces;
using NganHangCauHoi.Service.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_CauHoiService 
    {
        public NHCH_CauHoiService(
            NganHangCauHoiDataContext dataContext,
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_CauHoiService(
            IServiceProvider serviceProvider)
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider)
        { }
        private readonly INHCH_CauHoiRepos _repos;

        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly IUserPrincipalService _userPrincipalService;
        private readonly INHCH_DeThiRepos _tbl_NHCH_DeThiRepos;
        private readonly INHCH_DeThi_ChiTietRepos _tbl_NHCH_DeThi_ChiTietRepos;
        private readonly INHCH_CauHoi_CloRepos _tbl_NHCH_CauHoi_CloRepos;
        private readonly ITemplateClientService _templateClientService;
        private readonly Itbl_HocPhanServiceSdk _tbl_HocPhanServiceSdk;
        private readonly Itbl_DM_MucDoServiceSdk _tbl_DM_MucDoServiceSdk;
        private readonly Itbl_ChuDeServiceSdk _tbl_ChuDeServiceSdk;
        private readonly INHCH_MaTranDeThiRepos _tbl_NHCH_MaTranDeThiRepos;
        private readonly INHCH_MaTranDeThi_ChiTietRepos _tbl_NHCH_MaTranDeThi_ChiTietRepos;
        private readonly INHCH_BoCauHoi_CauHoiRepos _tbl_NHCH_BoCauHoi_CauHoiRepos;
        private readonly INHCH_BoCauHoiRepos _tbl_NHCH_BoCauHoiRepos;
        private readonly IFileClientService _fileClientService;
        private readonly INHCH_ChuDeRepos _tbl_NHCH_ChuDeRepos;
        private readonly INHCH_ChuDe_MucTieuRepos _tbl_NHCH_ChuDe_MucTieuRepos;

        private readonly INHCH_BoCauHoiService _tbl_NHCH_BoCauHoiService;
        private readonly INHCH_MaTranDeThiService _tbl_NHCH_MaTranDeThiService;

        public NHCH_CauHoiService(INHCH_CauHoiRepos repos, IServiceProvider serviceProvider,
            IUserPrincipalService userPrincipalService,
            IEntityChangedEventService entityChangedEventService,
            INHCH_DeThiRepos tbl_NHCH_DeThiRepos,
            INHCH_DeThi_ChiTietRepos tbl_NHCH_DeThi_ChiTietRepos,
            INHCH_CauHoi_CloRepos tbl_NHCH_CauHoi_CloRepos,
            ITemplateClientService templateClientService,
            Itbl_HocPhanServiceSdk tbl_HocPhanServiceSdk,
            Itbl_DM_MucDoServiceSdk tbl_DM_MucDoServiceSdk,
            Itbl_ChuDeServiceSdk tbl_ChuDeServiceSdk,
            INHCH_MaTranDeThiRepos tbl_NHCH_MaTranDeThiRepos,
            INHCH_BoCauHoiRepos tbl_NHCH_BoCauHoiRepos,
            INHCH_MaTranDeThi_ChiTietRepos tbl_NHCH_MaTranDeThi_ChiTietRepos,
            INHCH_BoCauHoi_CauHoiRepos tbl_NHCH_BoCauHoi_CauHoiRepos,
            IFileClientService fileClientService,
            INHCH_BoCauHoiService tbl_NHCH_BoCauHoiService,
            INHCH_MaTranDeThiService tbl_NHCH_MaTranDeThiService,
            INHCH_ChuDeRepos tbl_NHCH_ChuDeRepos,
            INHCH_ChuDe_MucTieuRepos tbl_NHCH_ChuDe_MucTieuRepos
            ) : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
            _userPrincipalService = userPrincipalService;
            _tbl_NHCH_DeThiRepos = tbl_NHCH_DeThiRepos;
            _tbl_NHCH_DeThi_ChiTietRepos = tbl_NHCH_DeThi_ChiTietRepos;
            _tbl_NHCH_CauHoi_CloRepos = tbl_NHCH_CauHoi_CloRepos;
            _templateClientService = templateClientService;
            _tbl_HocPhanServiceSdk = tbl_HocPhanServiceSdk;
            _tbl_DM_MucDoServiceSdk = tbl_DM_MucDoServiceSdk;
            _tbl_ChuDeServiceSdk = tbl_ChuDeServiceSdk;
            _tbl_NHCH_MaTranDeThiRepos = tbl_NHCH_MaTranDeThiRepos;
            _tbl_NHCH_BoCauHoiRepos = tbl_NHCH_BoCauHoiRepos;
            _tbl_NHCH_MaTranDeThi_ChiTietRepos = tbl_NHCH_MaTranDeThi_ChiTietRepos;
            _tbl_NHCH_BoCauHoi_CauHoiRepos = tbl_NHCH_BoCauHoi_CauHoiRepos;
            _fileClientService = fileClientService;

            _tbl_NHCH_ChuDeRepos = tbl_NHCH_ChuDeRepos;
            _tbl_NHCH_ChuDe_MucTieuRepos = tbl_NHCH_ChuDe_MucTieuRepos;
            _tbl_NHCH_BoCauHoiService = tbl_NHCH_BoCauHoiService;
            _tbl_NHCH_MaTranDeThiService = tbl_NHCH_MaTranDeThiService;
        }

        private string StripHTML(string htmlString)
        {
            string pattern = @"<(.|\n)*?>";
            return Regex.Replace(htmlString, pattern, string.Empty);
        }

        public override async Task<IMethodResult<NHCH_CauHoi>> GetByIdAsync(int id)
        {
            var result = await _repos.GetByIdAsync(id);
            if (result.Success && result.Data != null)
            {
                result.Data.tbl_NHCH_CauHoi_Clo = await _tbl_NHCH_CauHoi_CloRepos.GetAllLazy().Where(x => x.IdCauHoi == id).ToListAsync();
                if (result.Data.tbl_NHCH_CauHoi_Clo.Any())
                {
                    result.Data.DanhSachClo = string.Join(", ", result.Data.tbl_NHCH_CauHoi_Clo.Select(x => x.MaClo).ToList());
                }
                var cauHoi = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().FirstOrDefaultAsync(x => x.IdCauHoi == id);
                if (cauHoi != null)
                {
                    result.Data.IdBoCauHoi = cauHoi.IdBoCauHoi;
                }
            }
            return result;
        }

        public override async Task<IMethodResult<NHCH_CauHoi>> GetByCodeAsync(string code)
        {
            var result = await _repos.GetByCodeAsync(code);
            if (result.Success && result.Data != null)
            {
                result.Data.tbl_NHCH_CauHoi_Clo = await _tbl_NHCH_CauHoi_CloRepos.GetAllLazy().Where(x => x.IdCauHoi == result.Data.Id).ToListAsync();
                if (result.Data.tbl_NHCH_CauHoi_Clo.Any())
                {
                    result.Data.DanhSachClo = string.Join(", ", result.Data.tbl_NHCH_CauHoi_Clo.Select(x => x.MaClo).ToList());
                    result.Data.IdBoCauHoi = (await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().FirstOrDefaultAsync(x => x.IdCauHoi == result.Data.Id)).IdBoCauHoi;
                }
            }
            return result;
        }

        public override async Task<IMethodResult<int>> InsertAsync(NHCH_CauHoi item)
        {
            int index = 0;
            var itemLatestCauHoi = _repos.GetAllLazy()
                                         .Where(x => x.IdHocPhan == item.IdHocPhan
                                                     && x.Created.Date == DateTime.UtcNow.Date)
                                         .OrderByDescending(x => x.STTCauHoi)
                                         .FirstOrDefault();

            if (itemLatestCauHoi == null)
            {
                item.STTCauHoi = index + 1;
            }
            else
            {
                item.STTCauHoi = itemLatestCauHoi.STTCauHoi + 1;
            }

            item.Code = GetMaCauHoi(DateTime.UtcNow.Date, item.MaHocPhan, item.STTCauHoi);

            if (item.NHCH_CauHoi_Clos != null && item.NHCH_CauHoi_Clos.Any())
            {
                foreach (var subItem in item.NHCH_CauHoi_Clos)
                {
                    subItem.InstanceId = Guid.NewGuid();
                    subItem.Created = DateTime.UtcNow;
                    subItem.CreatedBy = _userPrincipalService.UserId.ToString();
                    subItem.Modified = DateTime.UtcNow;
                    subItem.ModifiedBy = _userPrincipalService.UserId.ToString();
                }
            }

            var result = await base.InsertAsync(item);
            if (result.Success)
            {
                if (item.IdBoCauHoi != Guid.Empty)
                {
                    var boCauHoiAndCauHoi = new NHCH_BoCauHoi_CauHoi()
                    {
                        IdBoCauHoi = item.IdBoCauHoi,
                        MaBoCauHoi = item.MaBoCauHoi,
                        IdCauHoi = result.Data,
                        MaCauHoi = item.Code,
                    };
                    await _tbl_NHCH_BoCauHoi_CauHoiRepos.InsertAsync(boCauHoiAndCauHoi);
                }
            }
            return result;
        }

        private string GetMaCauHoi(DateTime created, string maHocPhan, int index)
        {
            var strIndex = index < 10 ? $"0{index}" : $"{index}";

            // convert sang time VN
            created = created.AddHours(7);
            var dateStr = TimeExtension.GetStringDateTime(created, "ddMMyyyy");
            return $"{maHocPhan}_{dateStr}_{strIndex}";
        }

        public override async Task<IMethodResult> UpdateAsync(NHCH_CauHoi item)
        {
            item.MarkDirty(nameof(item.IdHocPhan));
            item.MarkDirty(nameof(item.MaHocPhan));
            item.MarkDirty(nameof(item.IdChuDe));
            item.MarkDirty(nameof(item.IdMucDo));
            item.MarkDirty(nameof(item.MaMucDo));
            item.MarkDirty(nameof(item.TinChi));
            item.MarkDirty(nameof(item.Diem));
            item.MarkDirty(nameof(item.KhaDung));
            item.MarkDirty(nameof(item.Modified));
            item.MarkDirty(nameof(item.ModifiedBy));
            item.MarkDirty(nameof(item.Code));
            item.MarkDirty(nameof(item.IsBuildIn));
            item.MarkDirty(nameof(item.IsBuildInAll));
            item.MarkDirty(nameof(item.ServiceCode));
            item.MarkDirty(nameof(item.Entity));
            item.MarkDirty(nameof(item.EntityKey));
            item.MarkDirty(nameof(item.Version));

            var result = await base.UpdateAsync(item);

            if (result.Success)
            {
                // Detach dữ liệu của các collection con & item cha
                if (item.NHCH_CauHoi_Clos.Any())
                {
                    foreach (var child in item.NHCH_CauHoi_Clos)
                    {
                        _tbl_NHCH_CauHoi_CloRepos.DetachModel(child);
                    }
                }
                _repos.DetachModel(item);

                // Get dữ liệu collection con
                List<NHCH_CauHoi_Clo> listUpdate = await _tbl_NHCH_CauHoi_CloRepos.GetAllLazy()
                    .Where(x => x.IdCauHoi == item.Id).AsNoTracking().ToListAsync();

                if (item.NHCH_CauHoi_Clos.Any())
                {
                    foreach (var chiTiet in item.NHCH_CauHoi_Clos)
                    {
                        var itemUpdate = listUpdate.FirstOrDefault(x => x.Id == chiTiet.Id);
                        if (itemUpdate != null)
                        {
                            itemUpdate.IdCauHoi = chiTiet.IdCauHoi;
                            itemUpdate.MaClo = chiTiet.MaClo;
                            if (itemUpdate.CreatedBy == null)
                            {
                                itemUpdate.InstanceId = Guid.NewGuid();
                                itemUpdate.Created = DateTime.UtcNow;
                                itemUpdate.CreatedBy = _userPrincipalService.UserId.ToString();
                            }
                            itemUpdate.Modified = DateTime.UtcNow;
                            itemUpdate.ModifiedBy = _userPrincipalService.UserId.ToString();
                        }
                    }
                }

                List<NHCH_CauHoi_Clo> listDelete = listUpdate.Where(x => !item.NHCH_CauHoi_Clos.Any(y => y.Id == x.Id)).ToList();

                // Cập nhật dữ liệu vào DB
                if (listUpdate.Count > 0)
                {
                    foreach (var updateItem in listUpdate)
                    {
                        await _tbl_NHCH_CauHoi_CloRepos.UpdateEntireModel(updateItem);
                    }
                }

                if (listDelete.Count > 0)
                {
                    await _tbl_NHCH_CauHoi_CloRepos.DeleteManyAsync(listDelete.Select(x => x.Id).ToArray());
                }
                Guid a = new Guid();
                if (item.IdBoCauHoi != a)
                {
                    var boCauHoiAndCauHoi = _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().FirstOrDefault(x => x.IdCauHoi == item.Id);
                    if (boCauHoiAndCauHoi == null)
                    {
                        boCauHoiAndCauHoi = new NHCH_BoCauHoi_CauHoi()
                        {
                            IdBoCauHoi = item.IdBoCauHoi,
                            MaBoCauHoi = item.MaBoCauHoi,
                            IdCauHoi = item.Id,
                            MaCauHoi = item.Code,
                        };
                        await _tbl_NHCH_BoCauHoi_CauHoiRepos.InsertAsync(boCauHoiAndCauHoi);
                    }
                    else
                    {
                        boCauHoiAndCauHoi.IdBoCauHoi = item.IdBoCauHoi;
                        boCauHoiAndCauHoi.MaBoCauHoi = item.MaBoCauHoi;
                        boCauHoiAndCauHoi.MarkDirty(nameof(boCauHoiAndCauHoi.IdBoCauHoi));
                        boCauHoiAndCauHoi.MarkDirty(nameof(boCauHoiAndCauHoi.MaBoCauHoi));

                        await _tbl_NHCH_BoCauHoi_CauHoiRepos.UpdateAsync(boCauHoiAndCauHoi);
                    }
                }

                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_CAUHOI);
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteAsync(int id)
        {
            var result = await base.DeleteAsync(id);
            if (result.Success)
            {
                var listCauHoiCloDelete = await _tbl_NHCH_CauHoi_CloRepos.GetAllLazy().Where(x => x.IdCauHoi == id).ToListAsync();
                if (listCauHoiCloDelete.Count > 0)
                {
                    await _tbl_NHCH_CauHoi_CloRepos.DeleteManyAsync(listCauHoiCloDelete.Select(x => x.Id).ToArray());
                }

                var listBoCauHoiCauHoiDelete = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().Where(x => x.IdCauHoi == id).ToListAsync();
                if (listBoCauHoiCauHoiDelete.Count > 0)
                {
                    await _tbl_NHCH_BoCauHoi_CauHoiRepos.DeleteManyAsync(listBoCauHoiCauHoiDelete.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteManyByIdsAsync(int[] ids)
        {
            var result = await base.DeleteManyByIdsAsync(ids);
            if (result.Success)
            {
                var listCauHoiCloDelete = await _tbl_NHCH_CauHoi_CloRepos.GetAllLazy()
                                                                .Where(x => ids.Contains(x.IdCauHoi))
                                                                .ToListAsync();
                if (listCauHoiCloDelete.Count > 0)
                {
                    await _tbl_NHCH_CauHoi_CloRepos.DeleteManyAsync(listCauHoiCloDelete.Select(x => x.Id).ToArray());
                }

                var listBoCauHoiCauHoiDelete = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy()
                                                                                   .Where(x => ids.Contains(x.IdCauHoi))
                                                                                   .ToListAsync();
                if (listBoCauHoiCauHoiDelete.Count > 0)
                {
                    await _tbl_NHCH_BoCauHoi_CauHoiRepos.DeleteManyAsync(listBoCauHoiCauHoiDelete.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        [IgnoreGrpcGenerate]
        public async Task<byte[]> ExportByIds(int[] idCauHois)
        {
            var cauHois = await _repos.GetAllLazy().Where(x => idCauHois.Contains(x.Id)).ToListAsync();
            if (cauHois.Count > 0)
            {
                // Create Stream
                using (MemoryStream mem = new MemoryStream())
                {
                    // Create Document
                    using (WordprocessingDocument wordDocument =
                        WordprocessingDocument.Create(mem, WordprocessingDocumentType.Document, true))
                    {
                        // Add a main document part. 
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                        // Create the document structure and add some text.
                        mainPart.Document = new Document();
                        Body docBody = new Body();

                        var cauHoiInstanceIds = cauHois.Select(x => x.InstanceId).ToList();

                        mainPart.Document.Append(docBody);
                        mainPart.Document.Save();
                    }

                    mem.Position = 0;
                    return mem.ToArray();
                }
            }
            else
            {
                return new byte[0];
            }
        }

        public async Task<IMethodResult<int>> CopyById(int id)
        {
            var query = _repos.GetAllLazy().Where(x => x.Id == id).Select(item => new NHCH_CauHoi
            {
                Id = item.Id,
                IdHocPhan = item.IdHocPhan,
                MaHocPhan = item.MaHocPhan,
                IdChuDe = item.IdChuDe,
                IdMucDo = item.IdMucDo,
                MaMucDo = item.MaMucDo,
                TinChi = item.TinChi,
                Diem = item.Diem,
                KhaDung = item.KhaDung,
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
                NHCH_CauHoi_Clos = item.NHCH_CauHoi_Clos
            });

            var item = await query.FirstOrDefaultAsync();
            if (item != null)
            {
                var cauHoiMoi = new NHCH_CauHoi()
                {
                    IdHocPhan = item.IdHocPhan,
                    MaHocPhan = item.MaHocPhan,
                    IdChuDe = item.IdChuDe,
                    IdMucDo = item.IdMucDo,
                    MaMucDo = item.MaMucDo,
                    TinChi = item.TinChi,
                    Diem = item.Diem,
                    KhaDung = item.KhaDung,
                    Created = DateTime.UtcNow,
                    CreatedBy = _userPrincipalService.UserId.ToString(),
                    Modified = DateTime.UtcNow,
                    ModifiedBy = _userPrincipalService.UserId.ToString(),
                    IsDeleted = item.IsDeleted,
                    Code = item.Code,
                    InstanceId = Guid.NewGuid(),
                    //IsBuildIn = item.IsBuildIn,
                    //IsBuildInAll = item.IsBuildInAll,
                    //ServiceCode = item.ServiceCode,
                   // Entity = item.Entity,
                   // EntityKey = item.EntityKey,
                    //Version = item.Version
                };

                if (item.NHCH_CauHoi_Clos.Any())
                {
                    foreach (var child in item.NHCH_CauHoi_Clos)
                    {
                        var cauHoi_Clo = new NHCH_CauHoi_Clo()
                        {
                            MaClo = child.MaClo,
                            Created = DateTime.UtcNow,
                            CreatedBy = _userPrincipalService.UserId.ToString(),
                            Modified = DateTime.UtcNow,
                            ModifiedBy = _userPrincipalService.UserId.ToString(),
                            IsDeleted = child.IsDeleted,
                            Code = child.Code,
                            InstanceId = child.InstanceId,
                            //IsBuildIn = child.IsBuildIn,
                            //IsBuildInAll = child.IsBuildInAll,
                            //ServiceCode = child.ServiceCode,
                            //Entity = child.Entity,
                            //EntityKey = child.EntityKey,
                            //Version = child.Version
                        };
                        cauHoiMoi.NHCH_CauHoi_Clos.Add(cauHoi_Clo);
                    }
                }


                var result = await InsertAsync(cauHoiMoi);

                if (result.Success)
                {
                    var boCauHoiAndCauHoi = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().FirstOrDefaultAsync(x => x.IdCauHoi == id);
                    if (boCauHoiAndCauHoi != null)
                    {
                        var boCauHoiAndCauHoiNew = new NHCH_BoCauHoi_CauHoi()
                        {
                            IdBoCauHoi = boCauHoiAndCauHoi.IdBoCauHoi,
                            MaBoCauHoi = boCauHoiAndCauHoi.MaBoCauHoi,
                            IdCauHoi = cauHoiMoi.Id,
                            MaCauHoi = cauHoiMoi.Code,
                        };
                        await _tbl_NHCH_BoCauHoi_CauHoiRepos.InsertAsync(boCauHoiAndCauHoiNew);
                    }

                }
                return MethodResult<int>.ResultWithData(result.Data, "");
            }

            return MethodResult<int>.ResultWithData(0, "");
        }

        public async Task<IMethodResult<int>> CloneAllByTinChi(int num, int next)
        {
            var query = _repos.GetAllLazy().Where(x => x.TinChi == num).Select(item => new NHCH_CauHoi
            {
                Id = item.Id,
                IdHocPhan = item.IdHocPhan,
                MaHocPhan = item.MaHocPhan,
                IdChuDe = item.IdChuDe,
                IdMucDo = item.IdMucDo,
                MaMucDo = item.MaMucDo,
                TinChi = item.TinChi,
                Diem = item.Diem,
                KhaDung = item.KhaDung,
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
                NHCH_CauHoi_Clos = item.NHCH_CauHoi_Clos
            });

            var items = await query.ToListAsync();
            var count = 0;
            if (items.Any())
            {
                foreach (var item in items)
                {
                    var cauHoiMoi = new NHCH_CauHoi()
                    {
                        IdHocPhan = item.IdHocPhan,
                        MaHocPhan = item.MaHocPhan,
                        IdChuDe = item.IdChuDe,
                        IdMucDo = item.IdMucDo,
                        MaMucDo = item.MaMucDo,
                        TinChi = next,
                        Diem = item.Diem,
                        KhaDung = item.KhaDung,
                        Created = DateTime.UtcNow,
                        CreatedBy = _userPrincipalService.UserId.ToString(),
                        Modified = DateTime.UtcNow,
                        ModifiedBy = _userPrincipalService.UserId.ToString(),
                        IsDeleted = item.IsDeleted,
                        Code = item.Code.Replace("TC" + num, "TC" + next),
                        InstanceId = Guid.NewGuid(),
                        //IsBuildIn = item.IsBuildIn,
                        //IsBuildInAll = item.IsBuildInAll,
                        //ServiceCode = item.ServiceCode,
                        //Entity = item.Entity,
                        //EntityKey = item.EntityKey,
                        //Version = item.Version
                    };

                    if (item.NHCH_CauHoi_Clos.Any())
                    {
                        foreach (var child in item.NHCH_CauHoi_Clos)
                        {
                            var cauHoi_Clo = new NHCH_CauHoi_Clo()
                            {
                                MaClo = child.MaClo,
                                Created = DateTime.UtcNow,
                                CreatedBy = _userPrincipalService.UserId.ToString(),
                                Modified = DateTime.UtcNow,
                                ModifiedBy = _userPrincipalService.UserId.ToString(),
                                IsDeleted = child.IsDeleted,
                                Code = child.Code,
                                InstanceId = child.InstanceId,
                                //IsBuildIn = child.IsBuildIn,
                                //IsBuildInAll = child.IsBuildInAll,
                                //ServiceCode = child.ServiceCode,
                                //Entity = child.Entity,
                                //EntityKey = child.EntityKey,
                                //Version = child.Version
                            };
                            cauHoiMoi.NHCH_CauHoi_Clos.Add(cauHoi_Clo);
                        }
                    }

                    var result = await InsertAsync(cauHoiMoi);
                    count++;
                }
                return MethodResult<int>.ResultWithData(count, "");
            }

            return MethodResult<int>.ResultWithData(0, "");
        }

        public async Task<IMethodResult<int>> CreateCauHoiFileDefault(string service, string entity, Guid? entityInstanceId)
        {
            var fileObjectModel = new ServiceFileObjectModel();
            var defaultPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var filePath = defaultPath + "\\NoiDungCauHoiTemplate.docx";

            var formFileModel = new NHCH_FormFileModel();

            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                formFileModel.FileStream = fileStream;
                formFileModel.Length = fileStream.Length;
                var temp = entityInstanceId.Value.ToString();
                formFileModel.FileName = "NoiDung_" + temp.Substring(temp.Length - 12, 12) + ".docx";

                fileObjectModel.File = formFileModel;

                fileObjectModel.Service = service;
                fileObjectModel.Entity = entity;
                fileObjectModel.EntityInstanceId = entityInstanceId;
                fileObjectModel.IsMultiple = false;

                await _fileClientService.CreateServiceFile(fileObjectModel);
            }

            return MethodResult<int>.ResultWithData(0, "");
        }

        public Task<IMethodResult<IEnumerable<NHCH_CauHoi>>> GetAllWithoutBoCauHoi(GridInfo gridInfo)
        {
            int? currentIdBoCauHoi = null;
            Guid currentIdHocPhan = Guid.Empty;

            if (gridInfo.Filters != null)
            {
                var filterCurrentIdBoCauHoi = gridInfo.Filters.FirstOrDefault(x => x.Field == "currentIdBoCauHoi");
                if (filterCurrentIdBoCauHoi != null)
                {
                    if (filterCurrentIdBoCauHoi.Value != null)
                    {
                        currentIdBoCauHoi = int.Parse(filterCurrentIdBoCauHoi.Value);
                    }
                    gridInfo.Filters.Remove(filterCurrentIdBoCauHoi);
                }

                var filterCurrentIdHocPhan = gridInfo.Filters.FirstOrDefault(x => x.Field == "currentIdHocPhan");
                if (filterCurrentIdHocPhan != null)
                {
                    if (filterCurrentIdHocPhan.Value != null)
                    {
                        currentIdHocPhan = Guid.Parse(filterCurrentIdHocPhan.Value);
                    }
                    gridInfo.Filters.Remove(filterCurrentIdHocPhan);
                }
            }

            return _repos.GetAllWithoutBoCauHoi(gridInfo, currentIdBoCauHoi, currentIdHocPhan);
        }

        public async Task<IMethodResult<object>> FindByDeThi(GridInfo gridInfo)
        {
            var idMaTranDeThiChiTiet = int.Parse(gridInfo.Filters.FirstOrDefault(x => x.Field == "idMaTranDeThiChiTiet").Value);
            var idHocPhan = Guid.Parse(gridInfo.Filters.FirstOrDefault(x => x.Field == "idHocPhan").Value);
            var idsCauHoi = gridInfo.Filters.FirstOrDefault(x => x.Field == "idsCauHoi").Value.Split(",").Select(x => int.Parse(x)).ToList(); ;
            var idBoCauHoi = 0;
            if (gridInfo.Filters.Any(x => x.Field == "idBoCauHoi"))
            {
                idBoCauHoi = int.Parse(gridInfo.Filters.FirstOrDefault(x => x.Field == "idBoCauHoi").Value);
            }

            var maTranChiTiet = _tbl_NHCH_MaTranDeThi_ChiTietRepos.GetAllLazy().FirstOrDefault(x => x.Id == idMaTranDeThiChiTiet);

            var query = _repos.GetAllLazy()
                        .Where(x => x.IdHocPhan == idHocPhan
                            && x.IdMucDo == maTranChiTiet.IdMucDo
                            && x.IdChuDe == maTranChiTiet.IdChuDe
                            && x.TinChi == maTranChiTiet.TinChi
                            && !idsCauHoi.Contains(x.Id)
                            )
                        .AsQueryable();
            if (gridInfo.Filters.Any(x => x.Field == "code"))
            {
                var code = gridInfo.Filters.FirstOrDefault(x => x.Field == "code").Value.Trim().ToLower();
                query = query.Where(x => x.Code.ToLower().Contains(code));
            }
            if (idBoCauHoi > 0)
            {
                var listCauHoiId = _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().Where(x => x.IdBoCauHoi == idBoCauHoi).Select(x => x.IdCauHoi).ToList();
                query = query.Where(x => listCauHoiId.Contains(x.Id));
            }
            var total = query.Count();

            var page = gridInfo.PageInfo.Page;
            var pageSize = gridInfo.PageInfo.PageSize;

            var result = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var lstIdCauHoi = result.Select(x => x.Id).ToList();
            var lstCauHoiClo = await _tbl_NHCH_CauHoi_CloRepos.GetAllLazy()
                                                              .Where(x => lstIdCauHoi.Contains(x.IdCauHoi))
                                                              .ToListAsync();

            result.ForEach(item =>
            {
                var lstMaCloInCauHoi = lstCauHoiClo.Where(x => x.IdCauHoi == item.Id)
                                                   .Select(x => x.MaClo)
                                                   .ToList();
                item.DanhSachClo = string.Join(",", lstMaCloInCauHoi);
            });

            return MethodResult<object>.ResultWithData(result, "", total);

        }

        // Lấy cau hoi theo mã đề thi (đảm bảo mã đề thi chỉ có một)
        public async Task<IMethodResult<IDictionary<string, List<NHCH_CauHoi>>>> GetListCauHoiByMaDeThi(string[] maDeThis)
        {
            var deThis = await _tbl_NHCH_DeThiRepos.GetAllLazy().Where(x => maDeThis.Contains(x.Code)).ToListAsync();

            IDictionary<string, List<NHCH_CauHoi>> result = new Dictionary<string, List<NHCH_CauHoi>>();
            foreach (var deThi in deThis)
            {
                var idCauhois = _tbl_NHCH_DeThi_ChiTietRepos.GetAllLazy().Where(x => x.IdDeThi == deThi.Id).Select(x => x.IdCauHoi).ToList();
                var cauHois = _repos.GetAllLazy().Where(x => idCauhois.Contains(x.Id)).Include(x => x.NHCH_CauHoi_Clos).ToList();
                result.Add(deThi.Code, cauHois);
            }

            return MethodResult<IDictionary<string, List<NHCH_CauHoi>>>.ResultWithData(result);
        }

        #region Import File câu hỏi

        public async Task<IMethodResult<int>> ImportCauHoiMaTran(
            IFormFile file, Guid idHocPhan, string maHocPhan,
            bool importMaTran, bool importCauHoi, string tienToMaTran,
            int idBoCauHoi = 0, bool isTaoBoCauHoi = false)
        {
            var initData = new InitialDataNhchImport
            {
                InstanceIdHocPhan = idHocPhan
            };
            var resultInitial = await CreateInitDataNhchImport(initData);
            if (!resultInitial.Success)
            {
                return MethodResult<int>.ResultWithError(resultInitial);
            }

            var rsImportChuDe = await ImportChuDe(file, initData);
            if (!rsImportChuDe.Success)
            {
                return MethodResult<int>.ResultWithError(Validation.ERR_BUSINESS, message: rsImportChuDe.Message);
            }

            var rsImportMaTran = await ImportMaTran(file, initData, tienToMaTran);
            if (!rsImportMaTran.Success || rsImportMaTran.Data == null || rsImportMaTran.Data.Count == 0)
            {
                return MethodResult<int>.ResultWithError(Validation.ERR_BUSINESS, message: rsImportMaTran.Message);
            }

            var rsImportCauHoi = await ImportCauHoi(file, initData, isTaoBoCauHoi, idBoCauHoi, rsImportMaTran.Data, tienToMaTran);
            if (!rsImportCauHoi.Success)
            {
                return MethodResult<int>.ResultWithError(Validation.ERR_BUSINESS, message: rsImportCauHoi.Message);
            }


            return MethodResult<int>.ResultWithData(0, "");
        }

        private async Task<IMethodResult<bool>> CreateInitDataNhchImport(InitialDataNhchImport initData)
        {
            if (initData.lstMucDo == null)
            {
                var mucDoRs = await _tbl_DM_MucDoServiceSdk.GetAllAsync();
                if (!mucDoRs.Success || mucDoRs.Data.Count() == 0)
                {
                    return MethodResult<bool>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy thông tin mức độ");
                }

                initData.lstMucDo = mucDoRs.Data.ToList();
            }
            if (initData.ItemHocPhan == null)
            {
                var hocPhanRs = await _tbl_HocPhanServiceSdk.GetByInstanceIdAsync(initData.InstanceIdHocPhan);
                if (!hocPhanRs.Success || hocPhanRs.Data == null)
                {
                    return MethodResult<bool>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy thông tin học phần");
                }
                initData.ItemHocPhan = hocPhanRs.Data;
            }
            if (initData.lstChuDe == null)
            {
                // Lấy ra list chủ đề
                initData.lstChuDe = await _tbl_NHCH_ChuDeRepos.GetAllLazy().Where(x => x.IdHocPhan == initData.ItemHocPhan.InstanceId).ToListAsync();
            }
            return MethodResult<bool>.ResultWithData(true);
        }

        public async Task<IMethodResult<bool>> ImportChuDe(
            IFormFile file, InitialDataNhchImport initData
        )
        {
            var resultInitial = await CreateInitDataNhchImport(initData);
            if (!resultInitial.Success)
            {
                return MethodResult<bool>.ResultWithError(resultInitial);
            }

            // Đại diện cho 4 cột Tín chỉ, mức độ, chủ đề, điểm
            // Do header trong mẫu đang merge thành 2 dòng
            int minCol = 4, minRow = 2;

            var dataMaTranDethi = await _templateClientService.ReadTableValues(file.OpenReadStream(), "Tín chỉ Mức độ Chủ đề");
            if (!dataMaTranDethi.Success || dataMaTranDethi.Data == null)
            {
                return MethodResult<bool>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không đọc được dữ liệu ma trận đề thi");
            }

            var dataMaTran = dataMaTranDethi.Data;
            if (dataMaTran.ColumnCount <= minCol || dataMaTran.RowCount <= minRow)
            {
                return MethodResult<bool>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không đọc được dữ liệu do dữ liệu bảng ma trận bị lỗi");
            }

            var colTinChi = 0;
            var colMucDo = 1;
            var colChuDe = 2;

            var lstChuDeInsert = new List<NHCH_ChuDe>();
            for (int row = minRow; row < dataMaTran.RowCount; row++)
            {
                // Nếu lỗi thì bỏ qua luôn

                #region tín chỉ

                int tinChi = 0;
                if (string.IsNullOrEmpty(dataMaTran.values[row][colTinChi].Trim())
                    || !int.TryParse(dataMaTran.values[row][colTinChi].Trim(), out tinChi)
                    || tinChi == 0)
                {
                    LogForFixBug($"Không đọc được tín chỉ dòng {row}");
                    continue;
                }

                #endregion

                #region mức độ

                int mucDo = 0;
                if (string.IsNullOrEmpty(dataMaTran[row][colMucDo].Trim())
                    || !int.TryParse(dataMaTran.values[row][colMucDo].Trim(), out mucDo)
                    || mucDo == 0)
                {
                    LogForFixBug($"Không đọc được mức độ dòng {row}");
                    continue;
                }

                var mucDoInfo = initData.lstMucDo.FirstOrDefault(x => x.MucDo == mucDo);
                if (mucDoInfo == null)
                {
                    LogForFixBug($"Không đọc được thông tin mức độ dòng {row}");
                    continue;
                }

                #endregion

                #region chủ đề

                int chuDe = 0;
                if (string.IsNullOrEmpty(dataMaTran[row][colChuDe].Trim())
                    || !int.TryParse(dataMaTran.values[row][colChuDe].Trim(), out chuDe)
                    || chuDe == 0)
                {
                    LogForFixBug($"Không đọc được chủ đề dòng {row}");
                    continue;
                }

                var chuDeInfo = initData.lstChuDe.FirstOrDefault(x => x.ThuTu == chuDe
                                                             && x.MucDo == mucDoInfo.MucDo
                                                             && x.TinChi == tinChi);
                if (chuDeInfo == null)
                {
                    var itemChuDeInsert = new NHCH_ChuDe
                    {
                        IdHocPhan = initData.ItemHocPhan.InstanceId,
                        MaHocPhan = initData.ItemHocPhan.Code,
                        TinChi = tinChi,
                        MucDo = mucDoInfo.MucDo,
                        InstanceIdMucDo = mucDoInfo.InstanceId,
                        ThuTu = chuDe
                    };
                    itemChuDeInsert.GenerateTen();
                    lstChuDeInsert.Add(itemChuDeInsert);
                }

                #endregion
            }
            if (lstChuDeInsert.Count > 0)
            {
                var resultInsert = await _tbl_NHCH_ChuDeRepos.InsertBulkAsync(lstChuDeInsert, opt => opt.SetOutputIdentity = true);
                if (!resultInsert.Success)
                {
                    return MethodResult<bool>.ResultWithError(resultInsert);
                }
                initData.lstChuDe.AddRange(lstChuDeInsert);
            }
            return MethodResult<bool>.ResultWithData(true);
        }

        public async Task<MethodResult<List<RowChuDe>>> ImportMaTran(
            IFormFile file, InitialDataNhchImport initData, string tienTo
        )
        {
            // Đại diện cho 4 cột Tín chỉ, mức độ, chủ đề, điểm
            // Do header trong mẫu đang merge thành 2 dòng
            int minCol = 4, minRow = 2;

            var resultInitial = await CreateInitDataNhchImport(initData);
            if (!resultInitial.Success)
            {
                return MethodResult<List<RowChuDe>>.ResultWithError(resultInitial);
            }

            var dataMaTranDethi = await _templateClientService.ReadTableValues(file.OpenReadStream(), "Tín chỉ Mức độ Chủ đề");
            if (!dataMaTranDethi.Success || dataMaTranDethi.Data == null)
            {
                return MethodResult<List<RowChuDe>>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không đọc được dữ liệu ma trận đề thi");
            }

            var dataMaTran = dataMaTranDethi.Data;
            if (dataMaTran.ColumnCount <= minCol || dataMaTran.RowCount <= minRow)
            {
                return MethodResult<List<RowChuDe>>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không đọc được dữ liệu do dữ liệu bảng ma trận bị lỗi");
            }

            var colTinChi = 0;
            var colMucDo = 1;
            var colChuDe = 2;
            var colDiem = 3;
            var colChuanDauRa = dataMaTran.ColumnCount - 1;

            #region Đọc danh sách chủ đề vs CLO

            var lstRow = new List<RowChuDe>();
            for (int row = minRow; row < dataMaTran.RowCount; row++)
            {
                // Nếu lỗi thì bỏ qua luôn

                #region tín chỉ

                int tinChi = 0;
                if (string.IsNullOrEmpty(dataMaTran.values[row][colTinChi].Trim())
                    || !int.TryParse(dataMaTran.values[row][colTinChi].Trim(), out tinChi)
                    || tinChi == 0)
                {
                    LogForFixBug($"Không đọc được tín chỉ dòng {row}");
                    continue;
                }

                #endregion

                #region mức độ

                int mucDo = 0;
                if (string.IsNullOrEmpty(dataMaTran[row][colMucDo].Trim())
                    || !int.TryParse(dataMaTran.values[row][colMucDo].Trim(), out mucDo)
                    || mucDo == 0)
                {
                    LogForFixBug($"Không đọc được mức độ dòng {row}");
                    continue;
                }

                var mucDoInfo = initData.lstMucDo.FirstOrDefault(x => x.MucDo == mucDo);
                if (mucDoInfo == null)
                {
                    LogForFixBug($"Không đọc được thông tin mức độ dòng {row}");
                    continue;
                }

                #endregion

                #region chủ đề

                int chuDe = 0;
                if (string.IsNullOrEmpty(dataMaTran[row][colChuDe].Trim())
                    || !int.TryParse(dataMaTran.values[row][colChuDe].Trim(), out chuDe)
                    || chuDe == 0)
                {
                    LogForFixBug($"Không đọc được chủ đề dòng {row}");
                    continue;
                }

                var chuDeInfo = initData.lstChuDe.FirstOrDefault(x => x.ThuTu == chuDe
                                                             && x.MucDo == mucDoInfo.MucDo
                                                             && x.TinChi == tinChi);
                if (chuDeInfo == null)
                {
                    LogForFixBug($"Không đọc được thông tin chủ đề dòng {row}");
                    continue;
                }

                #endregion

                #region điểm

                decimal diem = -1;
                if (string.IsNullOrEmpty(dataMaTran.values[row][colDiem].Trim())
                    || !decimal.TryParse(dataMaTran.values[row][colDiem].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out diem)
                    || diem < 0)
                {
                    LogForFixBug($"Không đọc được thông tin điểm dòng {row}");
                    continue;
                }

                #endregion

                #region chuẩn đầu ra
                var lstMaClo = new List<string>();
                var strClos = dataMaTran.values[row][colChuanDauRa].Trim();
                if (!string.IsNullOrEmpty(strClos))
                {
                    lstMaClo = strClos.Split(",").Select(x => x.Trim()).ToList();
                }

                #endregion

                lstRow.Add(new RowChuDe()
                {
                    Row = row,
                    TinChi = tinChi,
                    ItemMucDo = mucDoInfo,
                    ItemChuDe = chuDeInfo,
                    Diem = diem,
                    MaClos = lstMaClo
                });
            }

            #endregion

            #region Đọc dữ liệu ma trận 

            // Bỏ cột cuối là cột chuẩn đầu ra
            for (int col = minCol; col < colChuanDauRa; col++)
            {
                var lstMaTranChiTiet = new List<NHCH_MaTranDeThi_ChiTiet>();

                // Nếu lỗi thì bỏ qua luôn
                foreach (var itemRow in lstRow)
                {
                    int soCauHoi = 0;
                    if (string.IsNullOrEmpty(dataMaTran.values[itemRow.Row][col].Trim())
                       || !int.TryParse(dataMaTran.values[itemRow.Row][col].Trim(), out soCauHoi))
                    {
                        break;
                    }

                    if (itemRow.Diem > 0 && soCauHoi > 0)
                    {
                        lstMaTranChiTiet.Add(new NHCH_MaTranDeThi_ChiTiet()
                        {
                            TinChi = itemRow.TinChi,
                            IdMucDo = itemRow.ItemMucDo.Id,
                            IdChuDe = itemRow.ItemChuDe.Id,
                            SoCauHoi = soCauHoi,
                            Diem = itemRow.Diem
                        });
                    }
                }

                if (lstMaTranChiTiet.Count == 0) continue;

                var maTranDeThi = new NHCH_MaTranDeThi()
                {
                    TienTo = tienTo,
                    IdHocPhan = initData.ItemHocPhan.InstanceId,
                    MaHocPhan = initData.ItemHocPhan.Code,
                    MaTran_ChiTiets = lstMaTranChiTiet
                };

                await _tbl_NHCH_MaTranDeThiService.InsertAsync(maTranDeThi);
            }
            #endregion

            return MethodResult<List<RowChuDe>>.ResultWithData(lstRow);
        }

        public async Task<MethodResult<bool>> ImportCauHoi(
            IFormFile file, InitialDataNhchImport initData, bool isTaoBoCauHoi, int idBoCauHoi, List<RowChuDe> lstRowChuDe, string tienToBoCauHoi = ""
        )
        {
            var resultInitial = await CreateInitDataNhchImport(initData);
            if (!resultInitial.Success)
            {
                return MethodResult<bool>.ResultWithError(resultInitial);
            }

            var lstIdChuDe = lstRowChuDe.Select(x => x.ItemChuDe.Id).ToList();
            var lstChuDe_Clo = await _tbl_NHCH_ChuDe_MucTieuRepos.GetAllLazy()
                                                                 .Where(x => lstIdChuDe.Contains(x.IdChuDe))
                                                                 .ToListAsync();

            var dataCauHoiResult = await _templateClientService.ReadDocumentData(file.OpenReadStream(), new string[] {
                            "^(?i)[\\s]*tin[\\s]*chi[\\s]*([0-9]+)$", // rgTinChi
                            "^(?i)[\\s]*muc[\\s]*do[\\s]*(.+)$", // rgMucDo 
                            "^(?i)[\\s]*chu[\\s]*de[\\s]*(.*)\\((.*)[\\s]*[–|-][\\s]*(.*)\\)$", //  rgChuDe
                            "^(?i)[\\s]*cau[\\s]*.*?\\:[\\s]*$" // rgCauHoi
                        });

            if (!dataCauHoiResult.Success || dataCauHoiResult.Data == null || dataCauHoiResult.Data.Count == 0)
            {
                LogForFixBug($"Error read File: {dataCauHoiResult.Message}");
                return MethodResult<bool>.ResultWithError(Validation.ERR_BUSINESS, message: "File không chứa dữ liệu câu hỏi");
            }

            // Đọc ra giá trị số thứ tự câu hỏi của 
            var soThuTuCauHoi = 1;
            var itemLatestCauHoi = _repos.GetAllLazy()
                                         .Where(x => x.IdHocPhan == initData.ItemHocPhan.InstanceId
                                                     && x.Created.Date == DateTime.UtcNow.Date)
                                         .OrderByDescending(x => x.STTCauHoi)
                                         .FirstOrDefault();
            if (itemLatestCauHoi == null)
            {
                soThuTuCauHoi = 1;
            }
            else
            {
                soThuTuCauHoi = itemLatestCauHoi.STTCauHoi + 1;
            }

            var dataTinChi = dataCauHoiResult.Data;
            var soTinChi = dataTinChi.Count;
            var listCauHoi = new List<NHCH_CauHoi>();
            if (soTinChi > initData.ItemHocPhan.SoTinChi.Value)
            {
                return MethodResult<bool>.ResultWithError(Validation.ERR_BUSINESS, message: "Số tín chỉ import vượt quá số tín chỉ của học phần");
            }

            if (soTinChi == 0)
            {
                return MethodResult<bool>.ResultWithError(Validation.ERR_BUSINESS, message: "Không tồn tại dữ liệu tín chỉ trong file import");
            }

            foreach (var tinChi in dataTinChi)
            {
                if (tinChi.ChildNodes.Count == 0)
                {
                    LogForFixBug("Count TinChi.ChildNodes: 0");
                    continue;
                }

                // mức độ
                foreach (var mucDo in tinChi.ChildNodes)
                {
                    var mucDoInfo = initData.lstMucDo.Find(x => x.MucDo.ToString() == mucDo.ToString());
                    if (mucDo.ChildNodes.Count > lstRowChuDe.Count())
                    {
                        LogForFixBug("Số chủ đề trong file import vượt quá số chủ đề của học phần");
                        continue;
                    }

                    // chủ đề
                    foreach (var chuDe in mucDo.ChildNodes)
                    {
                        var itemRowChuDe = lstRowChuDe.FirstOrDefault(x => x.TinChi.ToString() == tinChi.ToString()
                                                                           && x.ItemMucDo.MucDo.ToString() == mucDo.ToString()
                                                                           && x.ItemChuDe.ThuTu.ToString() == chuDe.Values[0].ToString().Trim());
                        if (itemRowChuDe == null)
                        {
                            LogForFixBug($"Không tìm thấy chủ đề tương ứng với chủ đề số '{chuDe.Values[0].ToString().Trim()}'");
                            continue;
                        }

                        var danhSachClo = new List<NHCH_CauHoi_Clo>();
                        var values = chuDe.Values;
                        if (values.Count <= 1)
                        {
                            LogForFixBug("values.Count <= 1");
                            continue;
                        }

                        //if (string.IsNullOrEmpty(values[2]))
                        //{
                        //    LogForFixBug($"Chưa điền CLO cho chủ đề {itemRowChuDe.ItemChuDe.ThuTu} - mức độ {mucDoInfo.MucDo}");
                        //    continue;
                        //}

                        foreach (var cloItem in itemRowChuDe.MaClos)
                        {
                            LogForFixBug($"Tín chỉ {tinChi}, Mức độ {mucDo}, Chủ đề {chuDe.Values[0]}, {cloItem}");
                            var clo = lstChuDe_Clo.FirstOrDefault(x => x.MaClo.ToUpper() == cloItem.Trim().ToUpper()
                                                                       && x.IdChuDe == itemRowChuDe.ItemChuDe.Id);
                            if (clo == null) continue;

                            LogForFixBug($"Tín chỉ {tinChi}, Mức độ {mucDo}, Chủ đề {chuDe.Values[0]}, CLO {cloItem} - {clo.MaClo}");
                            danhSachClo.Add(new NHCH_CauHoi_Clo
                            {
                                MaClo = clo.MaClo,
                                InstanceIdClo = clo.InstanceIdClo
                            });
                        }

                        if (chuDe.ChildNodes.Count == 0)
                        {
                            LogForFixBug($"Khong tìm thấy câu hỏi cho chủ đề {itemRowChuDe.ItemChuDe.ThuTu} - mức độ {mucDoInfo.MucDo}");
                            continue;
                        }

                        foreach (var cauHoi in chuDe.ChildNodes)
                        {
                            if (string.IsNullOrEmpty(cauHoi.Base64)) continue;
                            var rawNoiDung = cauHoi.ToString();
                            var dsCLO = new List<NHCH_CauHoi_Clo>();
                            dsCLO.AddRange(danhSachClo);

                            var tblCauHoi = new NHCH_CauHoi()
                            {
                                InstanceId = Guid.NewGuid(),
                                IdHocPhan = initData.ItemHocPhan.InstanceId,
                                MaHocPhan = initData.ItemHocPhan.Code,
                                IdChuDe = itemRowChuDe.ItemChuDe.Id,
                                IdMucDo = mucDoInfo.Id,
                                MaMucDo = mucDoInfo.Code,
                                TinChi = int.Parse(tinChi.ToString()),
                                KhaDung = true,
                                STTCauHoi = soThuTuCauHoi++,
                                Code = GetMaCauHoi(DateTime.UtcNow, initData.ItemHocPhan.Code, soThuTuCauHoi),
                                DanhSachCLOs = dsCLO
                            };

                            using (var stream = ConvertHelper.Base64ToStream(cauHoi.Base64))
                            {
                                var rsCreatedFile = await CreateCauHoiFile(ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_CAUHOI, tblCauHoi.InstanceId, stream, tblCauHoi.Code);
                                LogForFixBug($"CreateCauHoi {rsCreatedFile.Success} {rsCreatedFile.Message}");
                                if (rsCreatedFile.Success)
                                {
                                    listCauHoi.Add(tblCauHoi);
                                }
                            }
                        }
                    }
                }
            }

            if (listCauHoi.Count > 0)
            {
                var lstInsertCauHoi = new List<NHCH_CauHoi>();
                lstInsertCauHoi.AddRange(listCauHoi);

                var rsInsertCauHoi = await _repos.InsertBulkAsync(lstInsertCauHoi, action =>
                {
                    action.SetOutputIdentity = true;
                });
                if (!rsInsertCauHoi.Success)
                {
                    LogForFixBug($"InsertCauHoi: {rsInsertCauHoi.Error} {rsInsertCauHoi.Message}");
                    return MethodResult<bool>.ResultWithError(rsInsertCauHoi.Error, rsInsertCauHoi.Status, rsInsertCauHoi.Message);
                }

                var lstCauHoiCLO = new List<NHCH_CauHoi_Clo>();
                lstInsertCauHoi.ForEach(item =>
                {
                    var itemMapping = listCauHoi.FirstOrDefault(x => x.InstanceId == item.InstanceId);
                    if (itemMapping != null)
                    {
                        itemMapping.Id = item.Id;
                        itemMapping.DanhSachCLOs.ForEach(itemClo =>
                        {
                            lstCauHoiCLO.Add(new NHCH_CauHoi_Clo()
                            {
                                IdCauHoi = item.Id,
                                MaClo = itemClo.MaClo,
                                InstanceIdClo = itemClo.InstanceIdClo
                            });
                        });
                    }
                });

                if (lstCauHoiCLO.Count > 0)
                {
                    var rs = await _tbl_NHCH_CauHoi_CloRepos.InsertBulkAsync(lstCauHoiCLO);
                    LogForFixBug($"Result Insert CauHoiClo {rs.Success}, {rs.Message}");
                }
            }

            // Insert bộ bộ câu hỏi
            if (isTaoBoCauHoi && idBoCauHoi <= 0)
            {
                var soThuTu = 1;
                var lastItemBoCauHoi = _tbl_NHCH_BoCauHoiRepos.GetAllLazy()
                                             .Where(x => x.Created.Date == DateTime.UtcNow.Date
                                                         && x.IdHocPhan == initData.ItemHocPhan.InstanceId)
                                             .OrderByDescending(x => x.SoThuTu)
                                             .FirstOrDefault();

                if (lastItemBoCauHoi != null)
                {
                    soThuTu = lastItemBoCauHoi.SoThuTu + 1;
                }

                var strDate = TimeExtension.GetStringDateTime(DateTime.UtcNow.AddHours(7), "ddMMyyyy");
                var tblBoCauHoi = new NHCH_BoCauHoi()
                {
                    IdHocPhan = initData.ItemHocPhan.InstanceId,
                    MaHocPhan = initData.ItemHocPhan.Code,
                    Ten = $"Bộ câu hỏi {initData.ItemHocPhan.Code}_{strDate}_{soThuTu}",
                    TienTo = tienToBoCauHoi,
                    LstCauHoi = listCauHoi.Select(x => new NHCH_BoCauHoi_CauHoi
                    {
                        IdCauHoi = x.Id,
                        MaCauHoi = x.Code
                    }).ToList()
                };

                await _tbl_NHCH_BoCauHoiService.InsertAsync(tblBoCauHoi);
            }

            if (idBoCauHoi > 0)
            {
                var itemBoCauHoi = await _tbl_NHCH_BoCauHoiRepos.GetAllLazy().FirstOrDefaultAsync(x => x.Id == idBoCauHoi);
                if (itemBoCauHoi != null)
                {
                    itemBoCauHoi.LstCauHoi = listCauHoi.Select(x => new NHCH_BoCauHoi_CauHoi
                    {
                        IdBoCauHoi = itemBoCauHoi.Id,
                        MaBoCauHoi = itemBoCauHoi.Code,
                        IdCauHoi = x.Id,
                        MaCauHoi = x.Code
                    }).ToList();

                    if (itemBoCauHoi.LstCauHoi.Count > 0)
                    {
                        await _tbl_NHCH_BoCauHoi_CauHoiRepos.InsertBulkAsync(itemBoCauHoi.LstCauHoi);
                    }
                }
            }

            return MethodResult<bool>.ResultWithData(true);
        }

        public async Task<IMethodResult<bool>> CreateCauHoiFile(string service, string entity, Guid? entityInstanceId, Stream fileStream, string fileName = "")
        {
            var fileObjectModel = new ServiceFileObjectModel();
            var formFileModel = new NHCH_FormFileModel();
            formFileModel.FileStream = fileStream;
            formFileModel.Length = fileStream.Length;
            var temp = entityInstanceId.Value.ToString();
            formFileModel.FileName = string.IsNullOrEmpty(fileName) ? "NoiDung_" + temp.Substring(temp.Length - 12, 12) + ".docx" : $"{fileName}.docx";
            fileObjectModel.File = formFileModel;

            fileObjectModel.Service = service;
            fileObjectModel.Entity = entity;
            fileObjectModel.EntityInstanceId = entityInstanceId;
            fileObjectModel.IsMultiple = false;

            var rsCreateCauHoi = await _fileClientService.CreateServiceFile(fileObjectModel);
            return MethodResult<bool>.ResultWithData(rsCreateCauHoi.Success, message: rsCreateCauHoi.Message);
        }

        public class RowChuDe
        {
            public int TinChi { get; set; }
            public tbl_DM_MucDo ItemMucDo { get; set; }
            public tbl_NHCH_ChuDe ItemChuDe { get; set; }
            public int Row { get; set; }
            public List<string> MaClos { get; set; }
            public decimal Diem { get; set; }
        }

        #endregion
        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_CauHoi item)
        //    {
        //        item.MarkDirty<NHCH_CauHoi>(x => new 
        //        {
        //            item.Code,
        //item.Created,
        //item.CreatedBy,
        //item.Diem,
        //item.Entity,
        //item.EntityKey,
        //item.IdChuDe,
        //item.IdHocPhan,
        //item.IdMucDo,
        //item.IsBuildIn,
        //item.IsBuildInAll,
        //item.IsDeleted,
        //item.KhaDung,
        //item.MaHocPhan,
        //item.MaMucDo,
        //item.Modified,
        //item.ModifiedBy,
        //item.NoiDung,
        //item.NoiDungRutGon,
        //item.ServiceCode,
        //item.STTCauHoi,
        //item.TinChi,
        //item.Version,
        //        });
        //        return await base.UpdateAsync(item);
        //    }
    }
}