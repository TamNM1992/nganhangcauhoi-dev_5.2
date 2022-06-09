

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///Note: Không sửa lại nội dung này của file này
///</summary>
using Microsoft.EntityFrameworkCore;
//using Shared.All.Common.Abstractions.v5;

namespace NganHangCauHoi.Repo.DataContext 
{
    public partial class NganHangCauHoiDataContext :DbContext //BaseDataContext<NganHangCauHoiDataContext>
    {
        public virtual DbSet<WorkflowPermission> WorkflowPermission { get; set; }
			
        public NganHangCauHoiDataContext(DbContextOptions<NganHangCauHoiDataContext> options) : base(options){}

        public NganHangCauHoiDataContext(): base() {}
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //        modelBuilder.Entity<WorkflowPermission>(entity => 
			 //{ 
				//entity.ToTable("WorkflowPermission", "dbo"); 
			 //});
			
    //    }
    }
}