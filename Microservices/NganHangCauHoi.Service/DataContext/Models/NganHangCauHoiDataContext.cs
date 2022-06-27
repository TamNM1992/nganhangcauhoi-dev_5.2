

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///Note: Không sửa lại nội dung này của file này
///</summary>
using Microsoft.EntityFrameworkCore;
//using Shared.All.Common.Abstractions.v5;

namespace NganHangCauHoi.Data.Models
{
    public partial class NganHangCauHoiDataContext :DbContext //BaseDataContext<NganHangCauHoiDataContext>
    {
        public virtual DbSet<WorkflowPermission> WorkflowPermission { get; set; }
			
        public NganHangCauHoiDataContext(DbContextOptions options) : base(options)
        {

        }

        public NganHangCauHoiDataContext(): base() {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkflowPermission>(entity =>
             {
                 entity.ToTable("WorkflowPermission", "dbo");
             });

        }
        public DbSet<WorkflowPermission> WorkflowPermissions { get; set; }
        public DbSet<NHCH_BoCauHoi> NHCH_BoCauHois { get; set; }
        public DbSet<NHCH_BoCauHoi_CauHoi> NHCH_BoCauHoi_CauHois { get; set; }
        public DbSet<NHCH_CauHoi> NHCH_CauHois { get; set; }
        public DbSet<NHCH_CauHoi_Clo> NHCH_CauHoi_Clos { get; set; }
        public DbSet<NHCH_Clo> NHCH_Clos { get; set; }
        public DbSet<NHCH_ChuDe> NHCH_ChuDes { get; set; }
        public DbSet<NHCH_ChuDe_MucTieu> NHCH_ChuDe_MucTieus { get; set; }
        public DbSet<NHCH_DeThi> NHCH_DeThis { get; set; }
        public DbSet<NHCH_DeThi_ChiTiet> NHCH_DeThi_ChiTiets { get; set; }
        public DbSet<NHCH_MaTranDeThi> NHCH_MaTranDeThis { get; set; }
        public DbSet<NHCH_MaTranDeThi_ChiTiet> NHCH_MaTranDeThi_ChiTiets { get; set; }
        public DbSet<NHCH_MucDo> NHCH_MucDos { get; set; }
        public DbSet<NHCH_MucTieu> NHCH_MucTieus { get; set; }
        public DbSet<NHCH_MucTieu_Clo> NHCH_MucTieu_Clos { get; set; }

    }
}