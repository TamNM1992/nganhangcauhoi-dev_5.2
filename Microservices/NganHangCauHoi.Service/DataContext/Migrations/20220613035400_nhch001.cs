using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NganHangCauHoi.Data.Migrations
{
    public partial class nhch001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "NHCH_BoCauHois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHocPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_BoCauHois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_CauHois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdChuDe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHocPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMucDo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    KhaDung = table.Column<bool>(type: "bit", nullable: false),
                    MaHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaMucDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungRutGon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STTCauHoi = table.Column<int>(type: "int", nullable: false),
                    TinChi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_CauHois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_Clos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_Clos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_ChuDes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHocPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMucDo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDo = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    TinChi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_ChuDes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_DeThis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfApprove = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentWorkflowStep = table.Column<int>(type: "int", nullable: true),
                    CurrentWorkflowType = table.Column<int>(type: "int", nullable: true),
                    FileApprovedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdBoCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdCaThi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDotThi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHocKy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHocPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdLichThi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdMaTranDeThi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNamHoc = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdToChucThi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaDotThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetadataStatus = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayThi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianLamBai = table.Column<int>(type: "int", nullable: false),
                    TotalCountOfApprove = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_DeThis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_MaTranDeThis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHocPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_MaTranDeThis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_MucDos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDo = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_MucDos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_MucTieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_MucTieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowPermission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HemisCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HemisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHistory = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotInWorkflow = table.Column<bool>(type: "bit", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    PersistedId = table.Column<int>(type: "int", nullable: true),
                    RoleIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synced = table.Column<bool>(type: "bit", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserIdCreated = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdsCombine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_BoCauHoi_CauHois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBoCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaBoCauHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaCauHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NHCH_BoCauHoiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_BoCauHoi_CauHois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NHCH_BoCauHoi_CauHois_NHCH_BoCauHois_NHCH_BoCauHoiId",
                        column: x => x.NHCH_BoCauHoiId,
                        principalTable: "NHCH_BoCauHois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_CauHoi_Clos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NHCH_CauHoiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_CauHoi_Clos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NHCH_CauHoi_Clos_NHCH_CauHois_NHCH_CauHoiId",
                        column: x => x.NHCH_CauHoiId,
                        principalTable: "NHCH_CauHois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_ChuDe_MucTieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChuDe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NHCH_ChuDeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_ChuDe_MucTieus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NHCH_ChuDe_MucTieus_NHCH_ChuDes_NHCH_ChuDeId",
                        column: x => x.NHCH_ChuDeId,
                        principalTable: "NHCH_ChuDes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_DeThi_ChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCauHoi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDeThi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdMaTranDeThiChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    NHCH_DeThiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_DeThi_ChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NHCH_DeThi_ChiTiets_NHCH_DeThis_NHCH_DeThiId",
                        column: x => x.NHCH_DeThiId,
                        principalTable: "NHCH_DeThis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_MaTranDeThi_ChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdChuDe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMaTranDeThi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMucDo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoCauHoi = table.Column<int>(type: "int", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    TinChi = table.Column<int>(type: "int", nullable: false),
                    NHCH_MaTranDeThiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_MaTranDeThi_ChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NHCH_MaTranDeThi_ChiTiets_NHCH_MaTranDeThis_NHCH_MaTranDeThiId",
                        column: x => x.NHCH_MaTranDeThiId,
                        principalTable: "NHCH_MaTranDeThis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHCH_MucTieu_Clos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdMucTieu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaClo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NHCH_MucTieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHCH_MucTieu_Clos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NHCH_MucTieu_Clos_NHCH_MucTieus_NHCH_MucTieuId",
                        column: x => x.NHCH_MucTieuId,
                        principalTable: "NHCH_MucTieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NHCH_BoCauHoi_CauHois_NHCH_BoCauHoiId",
                table: "NHCH_BoCauHoi_CauHois",
                column: "NHCH_BoCauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_NHCH_CauHoi_Clos_NHCH_CauHoiId",
                table: "NHCH_CauHoi_Clos",
                column: "NHCH_CauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_NHCH_ChuDe_MucTieus_NHCH_ChuDeId",
                table: "NHCH_ChuDe_MucTieus",
                column: "NHCH_ChuDeId");

            migrationBuilder.CreateIndex(
                name: "IX_NHCH_DeThi_ChiTiets_NHCH_DeThiId",
                table: "NHCH_DeThi_ChiTiets",
                column: "NHCH_DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_NHCH_MaTranDeThi_ChiTiets_NHCH_MaTranDeThiId",
                table: "NHCH_MaTranDeThi_ChiTiets",
                column: "NHCH_MaTranDeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_NHCH_MucTieu_Clos_NHCH_MucTieuId",
                table: "NHCH_MucTieu_Clos",
                column: "NHCH_MucTieuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NHCH_BoCauHoi_CauHois");

            migrationBuilder.DropTable(
                name: "NHCH_CauHoi_Clos");

            migrationBuilder.DropTable(
                name: "NHCH_Clos");

            migrationBuilder.DropTable(
                name: "NHCH_ChuDe_MucTieus");

            migrationBuilder.DropTable(
                name: "NHCH_DeThi_ChiTiets");

            migrationBuilder.DropTable(
                name: "NHCH_MaTranDeThi_ChiTiets");

            migrationBuilder.DropTable(
                name: "NHCH_MucDos");

            migrationBuilder.DropTable(
                name: "NHCH_MucTieu_Clos");

            migrationBuilder.DropTable(
                name: "WorkflowPermission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NHCH_BoCauHois");

            migrationBuilder.DropTable(
                name: "NHCH_CauHois");

            migrationBuilder.DropTable(
                name: "NHCH_ChuDes");

            migrationBuilder.DropTable(
                name: "NHCH_DeThis");

            migrationBuilder.DropTable(
                name: "NHCH_MaTranDeThis");

            migrationBuilder.DropTable(
                name: "NHCH_MucTieus");
        }
    }
}
