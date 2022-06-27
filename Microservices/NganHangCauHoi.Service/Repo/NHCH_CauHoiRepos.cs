using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NganHangCauHoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_CauHoiRepos
    {
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;

        public NHCH_CauHoiRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider)
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;

        }

        public async Task<List<NHCH_CauHoi>> GetByMaTranDeThiChiTiet(NHCH_MaTranDeThi_ChiTiet maTranDeThiChiTiet, List<Guid> listCauHoiLoaiTru)
        {
            // Tín chỉ
            // Mức độ
            // Chủ đề
            // Điểm
            // Danh sách CLO

            var queryCauHoi = _dataContext.Set<NHCH_CauHoi>().Include(x => x.NHCH_CauHoi_Clos).AsQueryable();
            if(listCauHoiLoaiTru != null && listCauHoiLoaiTru.Any())
            {
                queryCauHoi = queryCauHoi.Where(x => !listCauHoiLoaiTru.Contains(x.Id));
            }

            var items = await queryCauHoi
                .Where(x => x.KhaDung == true && x.TinChi == maTranDeThiChiTiet.TinChi
                && x.IdMucDo == maTranDeThiChiTiet.IdMucDo
                && x.IdChuDe == maTranDeThiChiTiet.IdChuDe)
                .Select(item => new NHCH_CauHoi
                {
                    Id = item.Id,
                    IdHocPhan = item.IdHocPhan,
                    MaHocPhan = item.MaHocPhan,
                    IdChuDe = item.IdChuDe,
                    IdMucDo = item.IdMucDo,
                    MaMucDo = item.MaMucDo,
                    NoiDungRutGon = item.NoiDungRutGon,
                    TinChi = item.TinChi,
                    Diem = item.Diem,
                    KhaDung = item.KhaDung,
                    Code = item.Code,
                    InstanceId = item.InstanceId,
                    NHCH_CauHoi_Clos = item.NHCH_CauHoi_Clos
                }).ToListAsync();

            // && x.Diem == maTranDeThiChiTiet.Diem
            if (items.Any())
            {
                var removeIds = new List<Guid>();
                //if (!string.IsNullOrEmpty(maTranDeThiChiTiet.DanhSachClo))
                //{
                //    var cloIdTexts = maTranDeThiChiTiet.DanhSachClo.Split(",").ToList();
                //    if (cloIdTexts.Count > 0)
                //    {
                //        var cloIds = new List<Guid>();
                //        foreach (var cloIdText in cloIdTexts)
                //        {
                //            cloIds.Add(Guid.Parse(cloIdText));
                //        }

                //        foreach (var item in items)
                //        {
                //            var removeFlag = true;
                //            foreach(var cloId in cloIds)
                //            {
                //                if (item.tbl_NHCH_CauHoi_Clo.FirstOrDefault(x => x.IdClo == cloId) != null)
                //                {
                //                    removeFlag = false;
                //                }
                //            }
                //            if (removeFlag)
                //            {
                //                removeIds.Add(item.Id);
                //            }
                //        }
                //    }
                //}

                if (removeIds.Count > 0)
                {
                    foreach (var removeId in removeIds)
                    {
                        var item = items.FirstOrDefault(x => x.Id == removeId);
                        if (item != null)
                        {
                            items.Remove(item);
                        }
                    }
                }
            }

            return items;
        }

        public async Task<IMethodResult<IEnumerable<NHCH_CauHoi>>> GetAllWithoutBoCauHoi(GridInfo gridInfo, Guid? currentIdBoCauHoi, 
            Guid currentIdHocPhan)
        {
            var items = (from ch in _dataContext.Set<NHCH_CauHoi>()
                         join bchch in _dataContext.Set<NHCH_BoCauHoi_CauHoi>() on ch.Id equals bchch.IdCauHoi into leftjoin
                         from bchch in leftjoin.DefaultIfEmpty()
                         where currentIdHocPhan != Guid.Empty && ch.IdHocPhan == currentIdHocPhan && ((bchch.IdBoCauHoi == null && currentIdBoCauHoi == null) || 
                         (currentIdBoCauHoi != null && (bchch.IdBoCauHoi == null || bchch.IdBoCauHoi == currentIdBoCauHoi.Value)))
                         select new NHCH_CauHoi
                         {
                             Id = ch.Id,
                             IdHocPhan = ch.IdHocPhan,
                             MaHocPhan = ch.MaHocPhan,
                             IdChuDe = ch.IdChuDe,
                             IdMucDo = ch.IdMucDo,
                             MaMucDo = ch.MaMucDo,
                             NoiDung = ch.NoiDung,
                             NoiDungRutGon = ch.NoiDungRutGon,
                             TinChi = ch.TinChi,
                             Diem = ch.Diem,
                             KhaDung = ch.KhaDung,
                             Created = ch.Created,
                             CreatedBy = ch.CreatedBy,
                             Modified = ch.Modified,
                             ModifiedBy = ch.ModifiedBy,
                             IsDeleted = ch.IsDeleted,
                             Code = ch.Code,
                             InstanceId = ch.InstanceId,
                             //IsBuildIn = ch.IsBuildIn,
                             //IsBuildInAll = ch.IsBuildInAll,
                             //ServiceCode = ch.ServiceCode,
                             //Entity = ch.Entity,
                             //EntityKey = ch.EntityKey,
                             //Version = ch.Version
                         });

            var results = await items.GetPaged(gridInfo);
            return MethodResult<IEnumerable<NHCH_CauHoi>>.ResultWithData(results.Data, totalRecord: results.Total);
        }


       
    }
}

