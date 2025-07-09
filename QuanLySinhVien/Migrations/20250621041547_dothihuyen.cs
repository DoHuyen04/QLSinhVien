using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLySinhVien.Migrations
{
    /// <inheritdoc />
    public partial class dothihuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinhViens",
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
                    table.PrimaryKey("PK_SinhViens", x => x.masv);
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "masv", "gioitinh", "lop", "ngaysinh", "tensv" },
                values: new object[,]
                {
                    { 1, "Nữ", "Tina4", new DateTime(2004, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huyền" },
                    { 2, "Nam", "Tina22", new DateTime(2004, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trọng" },
                    { 3, "Nữ", "QTMa3", new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhViens");
        }
    }
}
