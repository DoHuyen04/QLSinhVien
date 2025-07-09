using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSinhVien.Models;

    public class AppDataContext : DbContext
    {
        public AppDataContext (DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<WebSinhVien.Models.SinhVien> SinhVien { get; set; } = default!;

public DbSet<WebSinhVien.Models.KetQua> KetQua { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source = HUYENPEA; Initial Catalog = sinhvien; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<KetQua>().HasData(
       new KetQua { makq = 1, masv = 1, monhoc = "Toán", diem = 8.5f },
       new KetQua { makq = 2, masv = 2, monhoc = "Văn", diem = 7.0f },
       new KetQua { makq = 3, masv = 1, monhoc = "Lý", diem = 6.8f },
       new KetQua { makq = 4, masv = 3, monhoc = "Hóa", diem = 9.0f },
       new KetQua { makq = 5, masv = 2, monhoc = "Anh", diem = 7.5f }
   );
        modelBuilder.Entity<SinhVien>().HasData(
               new SinhVien { masv = 1, tensv = "Huyền", ngaysinh = new DateTime(2004, 04, 03), gioitinh = "Nữ", lop = "Tina4" },
                new SinhVien { masv = 2, tensv = "Trọng", ngaysinh = new DateTime(2004, 09, 26), gioitinh = "Nam", lop = "Tina22" },
                 new SinhVien { masv = 3, tensv = "Hoa", ngaysinh = new DateTime(2025, 12, 03), gioitinh = "Nữ", lop = "QTMa3" }
               );
    }
}
