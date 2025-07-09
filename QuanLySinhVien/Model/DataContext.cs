using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLySinhVien.Model
{
    public class DataContext : DbContext
    {

        public DbSet<SinhVien> SinhViens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>().HasData(
                new SinhVien{masv = 1 , tensv="Huyền" , ngaysinh = new DateTime(2004, 04,03) , gioitinh = "Nữ" , lop="Tina4"}   ,
                 new SinhVien { masv = 2, tensv = "Trọng", ngaysinh = new DateTime(2004, 09, 26), gioitinh = "Nam", lop = "Tina22" },
                  new SinhVien { masv = 3, tensv = "Hoa", ngaysinh = new DateTime(2025, 12, 03), gioitinh = "Nữ", lop = "QTMa3" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = HUYENPEA; Initial Catalog = sinhvien; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
        }

        //public DataContext(DbContextOptions options) : base(options)
        //{
        //}

       
    }
}
