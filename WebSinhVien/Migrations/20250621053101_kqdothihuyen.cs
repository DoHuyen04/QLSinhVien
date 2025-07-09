using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebSinhVien.Migrations
{
    /// <inheritdoc />
    public partial class kqdothihuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    masv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tensv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lop = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.masv);
                });

            migrationBuilder.CreateTable(
                name: "KetQua",
                columns: table => new
                {
                    makq = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    masv = table.Column<int>(type: "int", nullable: false),
                    SinhVienmasv = table.Column<int>(type: "int", nullable: true),
                    monhoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diem = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQua", x => x.makq);
                    table.ForeignKey(
                        name: "FK_KetQua_SinhVien_SinhVienmasv",
                        column: x => x.SinhVienmasv,
                        principalTable: "SinhVien",
                        principalColumn: "masv");
                });

            migrationBuilder.InsertData(
                table: "KetQua",
                columns: new[] { "makq", "SinhVienmasv", "diem", "masv", "monhoc" },
                values: new object[,]
                {
                    { 1, null, 8.5f, 1, "Toán" },
                    { 2, null, 7f, 2, "Văn" },
                    { 3, null, 6.8f, 1, "Lý" },
                    { 4, null, 9f, 3, "Hóa" },
                    { 5, null, 7.5f, 2, "Anh" }
                });

            migrationBuilder.InsertData(
                table: "SinhVien",
                columns: new[] { "masv", "gioitinh", "lop", "ngaysinh", "tensv" },
                values: new object[,]
                {
                    { 1, "Nữ", "Tina4", new DateTime(2004, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huyền" },
                    { 2, "Nam", "Tina22", new DateTime(2004, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trọng" },
                    { 3, "Nữ", "QTMa3", new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_SinhVienmasv",
                table: "KetQua",
                column: "SinhVienmasv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KetQua");

            migrationBuilder.DropTable(
                name: "SinhVien");
        }
    }
}
